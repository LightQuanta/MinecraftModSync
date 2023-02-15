namespace ClientModSyncGUI {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            if (!Directory.Exists(".minecraft")) {
                MessageBox.Show("�뽫����������.minecraftͬ��Ŀ¼�£�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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