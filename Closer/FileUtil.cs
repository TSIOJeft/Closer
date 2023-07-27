using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Closer;

public class FileUtil
{
    public void copyIco()
    {
        if (File.Exists(Config.BasePath+"/icon.ico")) return;
        using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("Closer.icon.icon.ico"))
        {
            using (var file = new FileStream(Config.BasePath+"/icon.ico", FileMode.Create, FileAccess.Write))
            {
                resource.CopyTo(file);
            }
        }
    }

    public void saveTextFile(string path, string text)
    {
        if (!File.Exists(path))
        {
            createParentDirs(path);
        }

        StreamWriter streamWriter = File.CreateText(path);
        streamWriter.Write(text);
        streamWriter.Flush();
        streamWriter.Close();
    }

    public string readTextFile(string path)
    {
        if (!File.Exists(path)) return null;
        StreamReader streamReader = File.OpenText(path);
        StringBuilder stringBuilder = new StringBuilder();
        string line = "";
        while ((line = streamReader.ReadLine()) != null)
        {
            stringBuilder.AppendLine(line);
        }
        streamReader.Close();
        return stringBuilder.ToString();
    }

    public void createParentDirs(string path)
    {
        var parent = Directory.GetParent(path);
        Directory.CreateDirectory(parent.FullName);
    }
}