using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Win32;
using Application = System.Windows.Forms.Application;

namespace Closer.page;

public partial class SettingPage : Page
{
    public SettingPage()
    {
        InitializeComponent();
        folderPath.Text = ConfigUtil.configArray.saveFilePath;
    }

    private void changeFolder(object sender, RoutedEventArgs e)
    {
        using (var fbd = new FolderBrowserDialog())
        {
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                folderPath.Text = fbd.SelectedPath;
                ConfigUtil.configArray.saveFilePath = fbd.SelectedPath;
                new ConfigUtil().saveConfig();
            }
        }
    }

    private void startUpClick(object sender, RoutedEventArgs e)
    {
        RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (ConfigUtil.configArray.startUp)
        {
            ConfigUtil.configArray.startUp = false;
            startupStatus.Text = "关闭";
            rk.DeleteValue("Closer",false);    
        }
        else
        {
            ConfigUtil.configArray.startUp = true;
            rk.SetValue("Closer", Application.ExecutablePath);
            startupStatus.Text = "开启";
        }
        new ConfigUtil().saveConfig();
    }
}