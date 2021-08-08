using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            FormGameSettings formGameSettings = new FormGameSettings();
            formGameSettings.ShowDialog();
        }
    }
}
