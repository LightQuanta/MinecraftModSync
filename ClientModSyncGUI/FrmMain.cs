using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
using System.Web;

namespace ClientModSyncGUI {
    public partial class FrmMain : Form {
        private static Config SyncConfig = Config.CreateDefaultConfig();
        private static readonly string ConfigFileName = $"mcsyncconfig-{Config.ConfigVersion}.json";
        private static bool Loaded = false;

        private static readonly JsonSerializerOptions JsonConfig = new() {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false,
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public FrmMain() {
            InitializeComponent();
            ReadConfig();
            if (SyncConfig.AutoUpdate) {
                UpdateProgram();
            }
        }

        private static void ReadConfig() {
            try {
                if (!File.Exists(ConfigFileName)) {
                    WriteConfig();
                }
                string Json = File.ReadAllText(ConfigFileName);
                Config? Temp = JsonSerializer.Deserialize<Config>(Json, JsonConfig);
                if (Temp == null) {
                    if (MessageBox.Show("�����ļ���ȡ�����Ƿ��������������ļ���\n�⽫�����֮ǰ������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        ResetConfig();
                    } else {
                        MessageBox.Show("���ֶ��޸������ļ�" + ConfigFileName + "�����������ļ����ݽ��ᶪʧ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {
                    SyncConfig = Temp;
                }
            } catch {
                if (MessageBox.Show("�����ļ���ȡ�����Ƿ��������������ļ���\n�⽫�����֮ǰ������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    ResetConfig();
                } else {
                    MessageBox.Show("���ֶ��޸������ļ�" + ConfigFileName + "�����������ļ����ݽ��ᶪʧ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private static void WriteConfig() {
            File.WriteAllText(ConfigFileName, JsonSerializer.Serialize(SyncConfig, JsonConfig));
        }

        private static void ResetConfig() {
            SyncConfig = Config.CreateDefaultConfig();
            WriteConfig();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            SetState();
            if (SyncConfig.AutoSync) {
                SyncMods();
            }
            Loaded = true;
        }

        private void SetState() {
            ChkAutoSyncMod.Checked = SyncConfig.AutoSync;
            ChkAutoUpdate.Checked = SyncConfig.AutoUpdate;
            TxtServerName.Text = SyncConfig.ServerName;
            ComboAction.SelectedIndex = (int) SyncConfig.ActionAfterSync;
            TxtCommand.Text = SyncConfig.Command;
            TxtCommand.Enabled = BtnSelectProgram.Enabled = ComboAction.SelectedIndex == 2 || ComboAction.SelectedIndex == 3;
        }

        private void BtnResetConfig_Click(object sender, EventArgs e) {
            if (MessageBox.Show("��ȷ��Ҫ���������ļ����⽫�����֮ǰ����������", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                ResetConfig();
                SetState();
                MessageBox.Show("�����������ļ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChkAutoSyncMod_CheckedChanged(object sender, EventArgs e) {
            if (Loaded && (ComboAction.SelectedIndex == 0 || ComboAction.SelectedIndex == 3) && ChkAutoSyncMod.Checked) {
                if (MessageBox.Show(
                    "ͬʱѡ���Զ�ͬ��mod��ͬ�����˳��ᵼ�³���������к��Զ��˳���ȷ��Ҫͬʱ��ѡ��\n���������������ÿ����������ļ�" + ConfigFileName + "���޸�"
                    , "����", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                ) == DialogResult.Cancel) {
                    ChkAutoSyncMod.Checked = false;
                    return;
                }
            }
            SyncConfig.AutoSync = ChkAutoSyncMod.Checked;
        }

        private void ComboAction_SelectedIndexChanged(object sender, EventArgs e) {
            if (Loaded && (ComboAction.SelectedIndex == 0 || ComboAction.SelectedIndex == 3) && SyncConfig.AutoSync) {
                if (MessageBox.Show(
                    "ͬʱѡ���Զ�ͬ��mod��ͬ�����˳��ᵼ�³������к��Զ��˳���ȷ��Ҫͬʱ��ѡ��\n���������������ÿ����������ļ�" + ConfigFileName + "���޸�"
                    , "����", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                ) == DialogResult.Cancel) {
                    ComboAction.SelectedIndex = 1;
                    return;
                }
            }
            TxtCommand.Enabled = BtnSelectProgram.Enabled = ComboAction.SelectedIndex == 2 || ComboAction.SelectedIndex == 3;

            SyncConfig.ActionAfterSync = ComboAction.SelectedIndex switch {
                0 => Config.AfterSyncAction.Exit,
                1 => Config.AfterSyncAction.DoNothing,
                2 => Config.AfterSyncAction.ExecuteCommand,
                3 => Config.AfterSyncAction.ExecuteCommandAndExit,
                _ => Config.AfterSyncAction.DoNothing,
            };
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e) {
            WriteConfig();
        }

        private void TxtServerName_TextChanged(object sender, EventArgs e) {
            SyncConfig.ServerName = TxtServerName.Text;
        }

        private void BtnSelectProgram_Click(object sender, EventArgs e) {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                TxtCommand.Text = OpenFileDialog.FileName;
            }
        }

        private void TxtCommand_TextChanged(object sender, EventArgs e) {
            SyncConfig.Command = TxtCommand.Text;
        }

        private void ChkAutoUpdate_CheckedChanged(object sender, EventArgs e) {
            SyncConfig.AutoUpdate = ChkAutoUpdate.Checked;
        }

        private void BtnSync_Click(object sender, EventArgs e) {
            SyncMods();
        }
        private void Log(string Text) {
            TxtLog.Text += Text + "\r\n";
        }
        private void SyncMods() {
            (new Thread(new ThreadStart(async () => {
                GroupSync.Enabled = false;
                GroupConfig.Enabled = false;
                string ServerName = SyncConfig.ServerName;
                Log("��ѡ����������ƣ�" + ServerName);
                Log("���ڻ�ȡ�����mod�б�");
                HttpClient client = new();
                string filelist;
                try {
                    filelist = await client.GetStringAsync($"http://mcmod.lq0.tech/filelist-{ServerName}.csv");
                } catch (HttpRequestException ex) {
                    if (ex.StatusCode == HttpStatusCode.NotFound) {
                        Log("�÷����������ڣ�");
                    } else {
                        Log("����δ֪����");
                        Log(ex.ToString());
                    }
                    GroupSync.Enabled = true;
                    GroupConfig.Enabled = true;
                    return;
                }
                Log("���ڼ�Ȿ��mod");
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
                    Log($"[{count}/{mods.Length}] " + f.Name + " " + strHash);
                    Progress.Value = (int) ((double) count / mods.Length * 100);
                }
                Log("");
                Progress.Value = 0;

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
                Log("");
                foreach (var key in files.Keys) {
                    Log("����ɾ��" + key);
                    File.Delete(".minecraft/mods/" + key);
                }

                count = 0;
                int width = downloadList.Count.ToString().Length * 2 + 4;
                foreach (var name in downloadList) {
                    count++;
                    string progress = $"[{count}/{ downloadList.Count}]";
                    Log(progress.PadRight(width, ' ') + $"�������� " + name + "\n");
                    Progress.Value = (int) ((double) count / downloadList.Count * 100);
                    string url = $"http://mcmod.lq0.tech/{ServerName}/{HttpUtility.UrlEncode(name)}";
                    var content = await client.GetByteArrayAsync(url);
                    File.WriteAllBytes(".minecraft/mods/" + name, content);
                }
                Log("ͬ����ɣ�");
                GroupSync.Enabled = true;
                GroupConfig.Enabled = true;

                if (SyncConfig.ActionAfterSync == Config.AfterSyncAction.Exit) {
                    Application.Exit();
                }
                if (SyncConfig.ActionAfterSync == Config.AfterSyncAction.ExecuteCommand) {
                    try {
                        Process.Start(SyncConfig.Command);
                    } catch (Exception ex) {
                        MessageBox.Show("����������ִ������������������\n" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtCommand.Focus();
                    }
                }
                if (SyncConfig.ActionAfterSync == Config.AfterSyncAction.ExecuteCommandAndExit) {
                    try {
                        Process.Start(SyncConfig.Command);
                        Application.Exit();
                    } catch (Exception ex) {
                        MessageBox.Show("����������ִ������������������\n" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtCommand.Focus();
                    }
                }
            }))).Start();
        }

        private async void BtnUpdate_Click(object sender, EventArgs e) {
            Enabled = false;
            HttpClient hc = new();
            string RemoteVersion = await hc.GetStringAsync("http://mcmod.lq0.tech/clientuiversion.txt");
            if (RemoteVersion == Config.ClientVersion) {
                MessageBox.Show("��ǰ�汾" + RemoteVersion + "�Ѿ������°棡", "��ʾ");
            } else {
                if (MessageBox.Show($"���ڿ��ø���\n��ǰ�汾��{Config.ClientVersion}\n���°汾��{RemoteVersion}\n\n�Ƿ���£�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    UpdateProgram();
                }
            }
            Enabled = true;
        }

        private static async void UpdateProgram() {
            HttpClient Client = new();
            string RemoteVersion = await Client.GetStringAsync("http://mcmod.lq0.tech/clientuiversion.txt");
            if (RemoteVersion == Config.ClientVersion) {
                return;
            }
            var Content = await Client.GetByteArrayAsync("http://mcmod.lq0.tech/clientui.exe");
            File.WriteAllBytes("clientui.exe.temp", Content);
            string ProgramName = Application.ExecutablePath[(Application.ExecutablePath.LastIndexOf("\\") + 1)..];
            if (File.Exists(ProgramName + ".old")) {
                File.Delete(ProgramName + ".old");
            }
            File.Move(ProgramName, ProgramName + ".old");
            File.Move("clientui.exe.temp", ProgramName);
            Process.Start(ProgramName);
            Application.Exit();
        }

        private void TxtLog_TextChanged(object sender, EventArgs e) {
            TxtLog.SelectionStart = TxtLog.Text.Length;
            TxtLog.ScrollToCaret();
        }
    }
}