namespace Closer.array;

public class MessageArray
{
    public int MessageType { get; set; }

    public string MessageIcon
    {
        get
        {
            if (MessageType == 1) return "/icon/text.png";
            if (MessageType == 2) return "/icon/file.png";
            return "/icon/text.png";
        }
    }

    public string MessageContent { get; set; }
    public string MessageTitle { get; set; }
}