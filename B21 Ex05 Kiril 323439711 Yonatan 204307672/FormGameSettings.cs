using GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    public partial class FormGameSettings : Form
    {
        // Check if theres Player1 name present, if not - alert the user
        private GamePlay.ePlayingVersus m_PlayingVs = GamePlay.ePlayingVersus.Computer; // Default option

        public FormGameSettings()
        {
            this.InitializeComponent();
            this.Parent = null;
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            this.m_TextBoxPlayer2Name.Enabled = this.m_CheckBoxPlayer2.Checked;
            this.m_TextBoxPlayer2Name.Text = this.m_TextBoxPlayer2Name.Enabled ? string.Empty : "[Computer]";

            // Playing against selection
            this.m_PlayingVs = this.m_CheckBoxPlayer2.Checked ? GamePlay.ePlayingVersus.Player : GamePlay.ePlayingVersus.Computer;
        }

        private void m_ButtonStartGame_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(Math.Round(this.m_NumercUpDownRows.Value, 0));
            int cols = Convert.ToInt32(Math.Round(this.m_NumercUpDownColumns.Value, 0));

            if (rows == cols)
            {
                int o_boardSize = Convert.ToInt32(Math.Round(this.m_NumercUpDownRows.Value, 0));

                string player1Name = this.m_TextBoxPlayer1Name.Text;
                if (this.isPlayerNameEmpty(player1Name))
                {
                    MessageBox.Show("Player1 name is empty, please verify players name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GamePlay.ePlayingVersus playingVs = this.m_PlayingVs;
                    string player2Name = this.m_TextBoxPlayer2Name.Text;
                    if (this.isPlayerNameEmpty(player2Name))
                    {
                        MessageBox.Show("Player2 name is empty, please verify players name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                        new BoardForm(o_boardSize, player1Name, playingVs, player2Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cant create board with current rows and columns size", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isPlayerNameEmpty(string i_Player1Name)
        {
            bool o_PlayerNameEmpty = false;

            if (string.IsNullOrEmpty(i_Player1Name))
            {
                o_PlayerNameEmpty = true;
            }

            return o_PlayerNameEmpty;
        }
    }
}
