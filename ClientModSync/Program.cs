// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;

if (!Directory.Exists(".minecraft")) {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Error.WriteLine("请将本程序放置在.minecraft的同级目录下！");
    Console.ReadKey();
    return;
}

string ServerName;
if (args.Length == 0 && !File.Exists("server.txt")) {
    Console.WriteLine("输入服务器名称：");
    ServerName = Console.ReadLine() ?? "";
} else if (args.Length == 1) {
    ServerName = args[0];
} else {
    ServerName = File.ReadAllText("server.txt");
}
ServerName = ServerName.ToLower();
if (!Regex.IsMatch(ServerName, "^[0-9a-z]+$")) {
    if (File.Exists("server.txt")) {
        File.Delete("server.txt");
    }
    Console.Error.WriteLine("请正确输入服务器名称！");
    Console.ReadKey();
    return;
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("已选择服务器名称：" + ServerName);
Console.WriteLine("正在获取服务端mod列表");
HttpClient client = new();
string filelist;
try {
    filelist = await client.GetStringAsync($"http://mcmod.lq0.tech/filelist-{ServerName}.csv");
} catch (HttpRequestException ex) {
    if (ex.StatusCode == System.Net.HttpStatusCode.NotFound) {
        if (File.Exists("server.txt")) {
            File.Delete("server.txt");
        }
        Console.Error.WriteLine("该服务器不存在！");
    } else {
        Console.Error.WriteLine("出现未知错误");
        Console.WriteLine(ex);
    }
    Console.ReadKey();
    return;
}
File.WriteAllText("server.txt", ServerName);
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("正在检测本地mod");
Console.ForegroundColor = ConsoleColor.White;
var sha = SHA256.Create();
Dictionary<string, string> files = new();
List<string> rec = new();
if (!Directory.Exists(".minecraft/mods")) {
    Directory.CreateDirectory(".minecraft/mods");
}
DirectoryInfo d = new(".minecraft/mods");
var mods = d.GetFiles();
int count = 0;
foreach (var f in mods) {
    FileStream fs = File.OpenRead(f.FullName);
    var hash = sha.ComputeHash(fs);
    fs.Close();
    string strHash = "";
    foreach (var b in hash) {
        strHash += Convert.ToString(b, 16).PadLeft(2, '0').ToUpper();
    }
    files.Add(f.Name, strHash);
    rec.Add(f.Name + "," + strHash);

    count++;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"\r[{count}/{mods.Length}] ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(f.Name + " ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(strHash);
}
Console.WriteLine();

List<string> downloadList = new();
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
            downloadList.Add(filename);
        }
    }
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
foreach (var key in files.Keys) {
    Console.WriteLine("正在删除" + key);
    File.Delete(".minecraft/mods/" + key);
}
Console.ForegroundColor = ConsoleColor.Cyan;

count = 0;
int width = downloadList.Count.ToString().Length * 2 + 4;
foreach (var name in downloadList) {
    count++;
    Console.ForegroundColor = ConsoleColor.Green;
    string progress = $"[{ count}/{ downloadList.Count}]";
    Console.Write(progress.PadRight(width, ' '));
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"正在下载 ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(name + "\n");
    Thread.Sleep(50);
    string url = $"http://mcmod.lq0.tech/{ServerName}/{HttpUtility.UrlEncode(name)}";
    var content = await client.GetByteArrayAsync(url);
    File.WriteAllBytes(".minecraft/mods/" + name, content);
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("同步完成！按任意键退出");
Console.ReadKey();
