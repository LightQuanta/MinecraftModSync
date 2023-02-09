// See https://aka.ms/new-console-template for more information
using ServerModSync;
using System.Security.Cryptography;
using Flurl.Http;
using System.Text.RegularExpressions;

string ServerName;
if (args.Length == 0) {
    Console.WriteLine("Input server name:");
    ServerName = Console.ReadLine() ?? "";
} else {
    ServerName = args[0];
}
ServerName = ServerName.ToLower();
if (!Regex.IsMatch(ServerName, "^[0-9a-z]+$")) {
    Console.Error.WriteLine("please input a correct server name!");
    return;
}
Console.WriteLine("Server name: " + ServerName);

if (!Directory.Exists("mods/" + ServerName)) {
    Console.Error.WriteLine("server do not exist!");
    return;
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("check local file");

var sha = SHA256.Create();

Dictionary<string, string> files = new();
List<string> rec = new();
DirectoryInfo d = new("mods/" + ServerName);
foreach (var f in d.GetFiles()) {
    FileStream fs = File.OpenRead(f.FullName);
    var hash = sha.ComputeHash(fs);
    fs.Close();
    string strHash = "";
    foreach (var b in hash) {
        strHash += Convert.ToString(b, 16).PadLeft(2, '0').ToUpper();
    }
    files.Add(f.Name, strHash);
    rec.Add(f.Name + "," + strHash);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(f.Name + " ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(strHash);
    Console.WriteLine();
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("filelist fetch");
string filelist = "";
try {
    filelist = await $"http://mcmod.lq0.tech/filelist-{ServerName}.csv".GetStringAsync();
} catch (Exception) { }

if (filelist != "") {
    foreach (var str in filelist.Split("\n")) {
        string filename = str.Split(",")[0];
        string filehash = str.Split(",")[1];

        if (files.ContainsValue(filehash)) {
            foreach (var key in files.Keys) {
                if (files.TryGetValue(key, out var val) && val == filehash) {
                    files.Remove(key);
                }
            }
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("delete " + filename);
            OssUtils.DeleteFile($"{ServerName}/{filename}");
        }
    }
}
Console.ForegroundColor = ConsoleColor.DarkYellow;
foreach (var key in files.Keys) {
    Console.WriteLine("uploading " + key + "...");
    OssUtils.UploadFile($"mods/{ServerName}/{key}", $"{ServerName}/{key}");
}
File.WriteAllText("filelist.csv", string.Join("\n", rec));
OssUtils.UploadFile("filelist.csv", $"filelist-{ServerName}.csv");
File.Delete("filelist.csv");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("sync completed");
Console.ResetColor();
