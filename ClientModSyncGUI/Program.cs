namespace ClientModSyncGUI {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            if (!Directory.Exists(".minecraft")) {
                MessageBox.Show("请将本程序置于.minecraft同级目录下！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
        }
    }
}