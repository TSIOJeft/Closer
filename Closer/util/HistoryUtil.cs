using System.Collections.Generic;
using Closer.array;
using Newtonsoft.Json;

namespace Closer.util;

public class HistoryUtil
{
    public void addHistory(MessageArray messageArray)
    {
        string history_json = new FileUtil().readTextFile(Config.BasePath + "/data/History.json");
        List<MessageArray> historyArrays = null;
        if (history_json != null)
        {
            historyArrays = JsonConvert.DeserializeObject<List<MessageArray>>(history_json);
        }

        if (historyArrays == null) historyArrays = new List<MessageArray>();
        historyArrays.Add(messageArray);
        new FileUtil().saveTextFile(Config.BasePath + "/data/History.json", JsonConvert.SerializeObject(historyArrays));
    }

    public List<MessageArray> getHistory()
    {
        string history_json = new FileUtil().readTextFile(Config.BasePath+"/data/History.json");
        List<MessageArray> historyArrays = null;
        if (history_json != null)
        {
            historyArrays = JsonConvert.DeserializeObject<List<MessageArray>>(history_json);
        }

        if (historyArrays == null) historyArrays = new List<MessageArray>();
        return historyArrays;
    }
}