using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Closer.array;
using Newtonsoft.Json;
using QRCoder;

namespace Closer.page;

public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
        initView();
    }

    private void initView()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        string ipaddress = "";
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipaddress = ip.ToString();
            }
        }

        DeviceArray deviceArray = new DeviceArray();
        deviceArray.DeviceType = 6;
        deviceArray.DeviceName = "家庭电脑";
        deviceArray.DeviceToken = "http://" + ipaddress + ":9696";
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData =
            qrGenerator.CreateQrCode(JsonConvert.SerializeObject(deviceArray), QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        qrimage.Source = ConvertBitmap(qrCodeImage);
        address.Text = "http://" + ipaddress + ":9696";
    }

    public BitmapImage ConvertBitmap(System.Drawing.Bitmap bitmap)
    {
        MemoryStream ms = new MemoryStream();
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        ms.Seek(0, SeekOrigin.Begin);
        image.StreamSource = ms;
        image.EndInit();

        return image;
    }
}