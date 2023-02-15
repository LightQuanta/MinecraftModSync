namespace ClientModSyncGUI {
    public class Config {
        public static readonly string ConfigVersion = "1.0";
        public static readonly string ClientVersion = "1.0.1";

        public enum AfterSyncAction {
            Exit,
            DoNothing,
            ExecuteCommand,
            ExecuteCommandAndExit
        }

        public string Version { get; set; }
        public string ServerName { get; set; }

        public bool AutoSync { get; set; }

        public AfterSyncAction ActionAfterSync { get; set; }
        public string Command { get; set; }
        public bool AutoUpdate { get; set; }

        public static Config CreateDefaultConfig() => new() {
            Version = ConfigVersion,
            ServerName = "",
            AutoSync = false,
            ActionAfterSync = AfterSyncAction.DoNothing,
            Command = "",
            AutoUpdate = false,
        };
    }
}
