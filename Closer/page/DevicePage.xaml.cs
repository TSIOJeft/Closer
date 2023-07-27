using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Closer.array;
using Closer.util;

namespace Closer.page;

public partial class DevicePage : Page
{
    public DeviceEditPage deviceEditPage;
    private HistoryPage historyPage;
    private List<DeviceItemArray> _deviceItemArrays;

    public DevicePage()
    {
        InitializeComponent();
        initData();
        initView();
    }

    private void initData()
    {
        List<DeviceArray> deviceArrays = new DeviceUtil().getDevice();
        foreach (var deviceArray in deviceArrays)
        {
            deviceList.Items.Add(new DeviceItemArray(deviceArray));
        }
        // DeviceItemArray deviceItemArray = new DeviceItemArray();
        // deviceItemArray.DeviceName = "小牛";
        // deviceList.Items.Add(deviceItemArray);
        // frame.Navigate(new DeviceEditPage());
    }

    private void initView()
    {
        historyPage = HistoryPage.getInstance();
        frame.Navigate(historyPage);
    }

    private void ListOnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // throw new System.NotImplementedException();
    }

    public class DeviceItemArray : DeviceArray
    {
        public DeviceArray deviceArray;

        public DeviceItemArray(DeviceArray deviceArray)
        {
            this.DeviceName = deviceArray.DeviceName;
            this.DeviceToken = deviceArray.DeviceToken;
            this.DeviceType = deviceArray.DeviceType;
            this.deviceArray = deviceArray;
        }

        public string DeviceName { get; set; }

        public int DeviceType { get; set; }

        public string DeviceToken { get; set; }

        public string Icon
        {
            get
            {
                if (DeviceType != 1) return "/icon/phone.png";
                else
                {
                    return "/icon/phone.png";
                }
            }
        }
    }

    private void listItemRightClick(object sender, MouseButtonEventArgs e)
    {
        MenuItem menuItem = (MenuItem)deviceList.ContextMenu.Items[0];
        ListViewItem listViewItem = (ListViewItem)sender;
        DeviceItemArray fileItem = (DeviceItemArray)listViewItem.Content;
        DeviceArray deviceArray = fileItem.deviceArray;
        new DeviceUtil().removeDevice(deviceArray);
        menuItem.Click += (s, r) =>
        {
            deviceList.Items.Remove(fileItem);
            deviceList.Items.Refresh();
        };
    }


    private void addClick(object sender, RoutedEventArgs e)
    {
        DeviceEditPage deviceEditPage = new DeviceEditPage();
        deviceEditPage.Show();
        deviceEditPage.handler = onDeviceAdd;
        // deviceEditPage = new DeviceEditPage();

        // frame.Navigate(deviceEditPage);
    }

    public void onDeviceAdd(DeviceArray deviceArray)
    {
        deviceList.Items.Add(new DeviceItemArray(deviceArray));
    }
}