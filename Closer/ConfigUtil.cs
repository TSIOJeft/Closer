using Newtonsoft.Json;

namespace Closer;

public class ConfigUtil
{
    public static ConfigArray configArray;

    public ConfigArray getConfig()
    {
        if (configArray != null) return configArray;
        string config_json = new FileUtil().readTextFile(Config.BasePath + "/data/config.json");
        if (string.IsNullOrEmpty(config_json))
        {
            configArray = new ConfigArray();
        }
        else
        {
            configArray = JsonConvert.DeserializeObject<ConfigArray>(config_json);
        }

        return configArray;
    }

    public void saveConfig()
    {
        new FileUtil().saveTextFile(Config.BasePath + "/data/config.json", JsonConvert.SerializeObject(configArray));
    }

    public class ConfigArray
    {
        public string saveFilePath = "./Download";
        public bool startUp = false;
        public bool firstUse = true;
    }
}