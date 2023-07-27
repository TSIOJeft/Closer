using System.Collections.Generic;
using System.Windows.Documents;
using Closer.array;
using Newtonsoft.Json;

namespace Closer.util;

public class DeviceUtil
{
    public static List<DeviceArray> devices;

    public void addDevice(DeviceArray deviceArray)
    {
        devices.Add(deviceArray);
        new FileUtil().saveTextFile(Config.BasePath + "/data/Device.json", JsonConvert.SerializeObject(devices));
    }

    public void saveDevice(List<DeviceArray> deviceArrays)
    {
        new FileUtil().saveTextFile(Config.BasePath + "/data/Device.json", JsonConvert.SerializeObject(deviceArrays));
    }

    public void removeDevice(DeviceArray deviceArray)
    {
        devices.Remove(deviceArray);
        new FileUtil().saveTextFile(Config.BasePath + "/data/Device.json", JsonConvert.SerializeObject(devices));
    }

    public List<DeviceArray> getDevice()
    {
        if (devices != null) return devices;
        string device_json = new FileUtil().readTextFile(Config.BasePath + "/data/Device.json");
        List<DeviceArray> deviceArrays = null;
        if (device_json != null)
        {
            deviceArrays = JsonConvert.DeserializeObject<List<DeviceArray>>(device_json);
        }

        if (deviceArrays == null) deviceArrays = new List<DeviceArray>();
        devices = deviceArrays;
        return devices;
    }
}