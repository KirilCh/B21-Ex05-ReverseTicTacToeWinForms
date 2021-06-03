using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GameSettingsForm gameSetting = new GameSettingsForm();
            gameSetting.ShowDialog();
        }
    }
}
