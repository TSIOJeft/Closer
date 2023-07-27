using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Closer.array;
using Closer.callback;
using Closer.Module;
using Closer.page;
using Closer.ui;
using Closer.util;
using Nancy.Hosting.Self;
using Nancy.Bootstrapper;
using NetFwTypeLib;
using Newtonsoft.Json;
using Button = System.Windows.Controls.Button;
using Clipboard = System.Windows.Forms.Clipboard;
using MessageBox = System.Windows.MessageBox;
using TextDataFormat = System.Windows.Forms.TextDataFormat;

namespace Closer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NancyCallback
    {
        private static NancyHost _server;
        private DevicePage devicePage;
        private DashboardPage dashboardPage;
        private HistoryPage historyPage;
        private SettingPage settingPage;

        public MainWindow()
        {
            InitializeComponent();
            initData();
            // AppDomain.CurrentDomain.BaseDirectory + @"/img/logo.ico"
            NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon(AppDomain.CurrentDomain.BaseDirectory + @"/icon.ico");
            ni.Visible = true;
            ni.Text = "咫尺";
            ni.Click +=
                delegate(object sender, EventArgs args)
                {
                    this.WindowState = WindowState.Minimized;
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            MenuItem menuHome = new MenuItem();
            menuHome.Text = "主面板";
            menuHome.Click += menuHomeClick;
            MenuItem menuExit = new MenuItem();
            menuExit.Text = "退出";
            menuExit.Click += menuExitClick;
            ni.ContextMenu = new ContextMenu(new System.Windows.Forms.MenuItem[] { menuHome, menuExit });
            Console.WriteLine("listen");
            listenPort();
            devicePage = new DevicePage();
            historyPage = HistoryPage.getInstance();
            FrameWork.Navigate(devicePage);
        }

        private void listenPort()
        {
            var configuration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            CloserModule.nancyCallback = this;
            _server = new NancyHost(configuration, new Uri("http://localhost:9696"));
            try
            {
                _server.Start();
            }
            catch (Exception e)
            {
                //port occur
                Console.WriteLine(e);
                // throw;
            }
        }

        private void initData()
        {
            Config.BasePath =
                AppDomain.CurrentDomain.BaseDirectory;
            new ConfigUtil().getConfig();
            new FileUtil().copyIco();
            if (ConfigUtil.configArray.firstUse)
            {
                addFirePort();
            }

            if (!File.Exists(Config.BasePath + "/data/tempFilePath.txt"))
            {
                new FileUtil().saveTextFile(Config.BasePath + "/data/tempFilePath.txt", "temp");
            }

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Config.BasePath + "/data";
            watcher.Filter = "tempFilePath.txt";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += OnTempFilePathChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void addFirePort()
        {
            if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                //add port 
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;
                INetFwRule2 inboundRule =
                    (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inboundRule.Enabled = true;
                inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                inboundRule.Protocol = 6;
                inboundRule.LocalPorts = "9696";
                inboundRule.Name = "咫尺端口";
                inboundRule.Profiles = currentProfiles;
                INetFwPolicy2 firewallPolicy =
                    (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(inboundRule);
                ConfigUtil.configArray.firstUse = false;
                new ConfigUtil().saveConfig();
            }
            else
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;
                proc.Verb = "runas";
                try
                {
                    Process.Start(proc);
                }
                catch (Exception ex)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void OnTempFilePathChanged(object sender, FileSystemEventArgs e)
        {
            Dispatcher.Invoke(delegate
            {
                Screen screen = Screen.PrimaryScreen;
                Rectangle rect = screen.Bounds;
                ToolTipWPFWindow wpfWindow = new ToolTipWPFWindow("已发送文件", 10, 10, 3000);
                wpfWindow.Show();
            });

            CloserModule.filePath = new FileUtil().readTextFile(e.FullPath).Replace("\r", "").Replace("\n", "");
        }

        private void menuExitClick(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void menuHomeClick(object sender, EventArgs e)
        {
            this.Show();
            Activate();
            Focus();
        }

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        void Application_ThreadException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message,
                ex.StackTrace));
        }

        private void min_window(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void max_window(object sender, RoutedEventArgs e)
        {
        }

        private void close_window(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            this.WindowState = WindowState.Minimized;
            //Close();
        }

        // Minimize to system tray when application is minimized.
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized) this.Hide();

            base.OnStateChanged(e);
        }

        // Minimize to system tray when application is closed.
        protected override void OnClosing(CancelEventArgs e)
        {
            // setting cancel to true will cancel the close request
            // so the application is not closed
            e.Cancel = true;

            this.Hide();

            base.OnClosing(e);
        }

        private void NavigationView_OnnavigationItemClick(object sender, EventArgs e)
        {
            Button buttton = (Button)sender;
            string id = buttton.Tag.ToString();
            if (id == "dashboard")
            {
                if (dashboardPage == null) dashboardPage = new DashboardPage();
                FrameWork.Navigate(dashboardPage);
            }

            if (id == "device")
            {
                FrameWork.Navigate(devicePage);
            }

            if (id == "history")
            {
                if (historyPage == null) historyPage = HistoryPage.getInstance();
                FrameWork.Navigate(historyPage);
            }

            if (id == "setting")
            {
                if (settingPage == null) settingPage = new SettingPage();
                FrameWork.Navigate(settingPage);
            }
        }

        public void onCallBack(MyMessage myMessage)
        {
            if (myMessage.what == 1)
            {
                Dispatcher.Invoke(delegate
                {
                    DeviceEditPage deviceEditPage = new DeviceEditPage();
                    DeviceArray deviceArray =
                        JsonConvert.DeserializeObject<DeviceArray>((string)myMessage.obj);
                    deviceEditPage.setDeviceData(deviceArray);
                    deviceEditPage.handler = devicePage.onDeviceAdd;
                    deviceEditPage.Show();
                });
            }
            else if (myMessage.what == 2)
            {
                Dispatcher.Invoke(delegate
                {
                    MessageArray messageArray = (MessageArray)myMessage.obj;
                    Clipboard.SetText(messageArray.MessageContent);
                    new HistoryUtil().addHistory(messageArray);
                    if (historyPage != null) historyPage.addHistory(messageArray);
                });
            }
            else if (myMessage.what == 3)
            {
                Dispatcher.Invoke(delegate { CloserModule.clipText = Clipboard.GetText(TextDataFormat.Text); });
            }
            else if (myMessage.what == 4)
            {
                MessageArray messageArray = (MessageArray)myMessage.obj;
                new HistoryUtil().addHistory(messageArray);
                if (historyPage != null) historyPage.addHistory(messageArray);
            }
        }
    }
}