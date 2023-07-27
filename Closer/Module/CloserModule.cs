using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using Closer.array;
using Closer.callback;
using Microsoft.Toolkit.Uwp.Notifications;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;

namespace Closer.Module;

public class CloserModule : NancyModule
{
    public static NancyCallback nancyCallback;
    public static string filePath = "";
    public static string clipText = "";

    public CloserModule()
    {
        Get("/hello/{name}", args =>
        {
            string name = args.name;
            var response = string.Format("Hello {0} ! ", name);
            return response;
        });
        Get("/getClip", args =>
        {
            MyMessage myMessage = new MyMessage();
            myMessage.what = 3;
            nancyCallback.onCallBack(myMessage);
            System.Threading.Thread.Sleep(1000);
            return clipText;
        });
        Get("/getFileMes", args =>
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                data["fileName"] = Path.GetFileName(filePath);
                data["filePath"] = filePath;
                return JsonConvert.SerializeObject(data);
            }

            return "";
        });
        Post("/text", args =>
        {
            var data = Request.Body.AsString();
            try
            {
                dynamic ob = JsonConvert.DeserializeObject((string)data);
                MyMessage myMessage = new MyMessage();
                myMessage.what = 2;
                MessageArray messageArray = new MessageArray();
                messageArray.MessageContent = (string)ob["text"];
                messageArray.MessageTitle = (string)ob["from"];
                messageArray.MessageType = 1;
                myMessage.obj = messageArray;
                if (nancyCallback != null) nancyCallback.onCallBack(myMessage);
                new ToastContentBuilder().AddText("咫尺").AddText("已复制")
                    .Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "400";
            }

            return "100";
        });
        Post("/receive", args =>
        {
            var data = this.Request.Body.AsString();
            try
            {
                dynamic ob = JsonConvert.DeserializeObject(data);
                MyMessage myMessage = new MyMessage();
                myMessage.what = ob["what"];
                myMessage.obj = (string)ob["data"];
                if (nancyCallback != null) nancyCallback.onCallBack(myMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "400";
            }

            return "100";
        });
        Get("/getFile", args =>
        {
            string path = (string)this.Request.Query["Path"];
            Console.WriteLine(path);
            if (string.IsNullOrEmpty(path)) path = filePath;
            // string path = filePath;
            if (string.IsNullOrEmpty(path)) return "404";
            var file = new FileStream(path, FileMode.Open);
            string fileName = new FileInfo(path).Name;
            var response = new StreamResponse(() => file, MimeTypes.GetMimeType(fileName));
            return response.AsAttachment(fileName);
        });
        Get("/alive", args => { return 100; });


        Post("/uploadFile", args =>
        {
            Console.WriteLine((string)this.Request.Query["fileName"]);
            if (!Directory.Exists(ConfigUtil.configArray.saveFilePath))
                Directory.CreateDirectory(ConfigUtil.configArray.saveFilePath);
            var file = this.Request.Files.First();
            if (file == null) return "404";
            var outFile =
                File.Create(ConfigUtil.configArray.saveFilePath + "/" + ((string)this.Request.Query["fileName"]));
            byte[] buffer = new byte[1024];
            int length;
            while ((length = file.Value.Read(buffer, 0, buffer.Length)) != 0)
            {
                outFile.Write(buffer, 0, length);
            }
            outFile.Flush();
            outFile.Close();
            file.Value.Flush();
            file.Value.Close();
            new ToastContentBuilder().AddText("咫尺").AddText("已下载: "+outFile.Name)
                .Show();
            MyMessage myMessage = new MyMessage();
            myMessage.what = 4;
            MessageArray messageArray = new MessageArray();
            messageArray.MessageContent = outFile.Name;
            messageArray.MessageTitle ="文件下载";
            messageArray.MessageType = 2;
            myMessage.obj = messageArray;
            if (nancyCallback != null) nancyCallback.onCallBack(myMessage);
            return "100";
        });
    }
}