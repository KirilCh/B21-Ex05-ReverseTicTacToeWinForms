using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{


    /// <summary>
    /// assigments:
    /// 1. Need to fix the GameOver function (In BoardForm.cs), after that things will be clear and the windows should be working perfectly (hope).
    /// 2. Adding and calculte the winning of each player. 
    /// 3. After a tie the computer play one more move and the game doesnt finish.
    /// 4. Consider to move in 'BoardForm.cs' some decleration in the ctor to the InitializeComponent in 'BoardForm.Designer.cs'.
    /// 4. Testing ... ( ^^^  1,2,3)
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormGameSettings formGameSettings = new FormGameSettings();
            formGameSettings.ShowDialog();
            //GameSettingsForm gameSetting = new GameSettingsForm();
            //gameSetting.ShowDialog();
        }
    }
}
