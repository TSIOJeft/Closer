using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Closer.array;
using Closer.util;
using Newtonsoft.Json;

namespace Closer.page;

public partial class DeviceEditPage
{
    private DeviceArray deviceArray;
    public CallBackHandler handler;

    public DeviceEditPage()
    {
        InitializeComponent();
    }

    private void import_right_click(object sender, MouseButtonEventArgs e)
    {
        // throw new System.NotImplementedException();
    }

    // private void export_task_bu(object sender, RoutedEventArgs e)
    // {
    //     throw new System.NotImplementedException();
    // }

    public void setDeviceData(DeviceArray deviceArray)
    {
        this.deviceArray = deviceArray;
        DeviceName.Text = this.deviceArray.DeviceName;
        DeviceType.Text = this.deviceArray.DeviceType.ToString();
        DeviceToken.Text = this.deviceArray.DeviceToken;
    }

    private void save_task_bu(object sender, RoutedEventArgs e)
    {
        DeviceArray deviceArray = new DeviceArray();
        if (DeviceType.Text.Length == 0)
        {
            DeviceType.BorderBrush = (System.Windows.Media.Brush)new BrushConverter().ConvertFromString("#EF5350");
            return;
        }

        if (DeviceName.Text.Length == 0)
        {
            DeviceName.BorderBrush = (System.Windows.Media.Brush)new BrushConverter().ConvertFromString("#EF5350");
            return;
        }

        if (DeviceToken.Text.Length == 0)
        {
            DeviceToken.BorderBrush = (System.Windows.Media.Brush)new BrushConverter().ConvertFromString("#EF5350");
            return;
        }

        deviceArray.DeviceToken = DeviceToken.Text;
        deviceArray.DeviceName = DeviceName.Text;
        deviceArray.DeviceType = Int32.Parse(DeviceType.Text);
        new DeviceUtil().addDevice(deviceArray);
        Close();
        handler.Invoke(deviceArray);
    }

    public delegate void CallBackHandler(DeviceArray deviceArray);

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
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
        Close();
        //Close();
    }

    private void DeviceTypeSliderDragCompleted(object sender, DragCompletedEventArgs e)
    {
        DeviceType.Text = DeviceTypeSlider.Value.ToString();
    }
}