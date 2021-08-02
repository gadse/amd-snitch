using System.Collections.Generic;
using System.IO;

using Reaction;

public class Config {
    public string UrlFilePath = @"./urls.txt";
    public string NotificationTarget = "READ FROM NON-COMMITED CONFIG";
    public IEnumerable<string> UrlsToWatch = new List<string>();

    public Config() {
        UrlsToWatch = ReadUrls(UrlFilePath);
        NotificationTarget = ReadWebHook();
    }

    private IEnumerable<string> ReadUrls(string path) {
        List<string> buffer = new();
        
        string line;
        using (var fileStream = File.OpenRead(path))
        using (var reader = new StreamReader(fileStream)) {
            while ((line = reader.ReadLine()) != null) {
                if (line.Trim().StartsWith("#")) {
                    continue;
                } else {
                    buffer.Add(line.Trim());
                }
            }
        }

        return buffer;
    }

    private string ReadWebHook() {
        return File.ReadAllText("webhook.txt").Trim();
    }
}