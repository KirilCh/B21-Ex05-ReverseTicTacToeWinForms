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
        GamePlay.ePlayingVersus m_PlayingVs = GamePlay.ePlayingVersus.Computer; //Default option

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            m_TextBoxPlayer2Name.Enabled = m_CheckBoxPlayer2.Checked;
            m_TextBoxPlayer2Name.Text = m_TextBoxPlayer2Name.Enabled ? "" : "[Computer]";
            //Playing against selection
            m_PlayingVs = m_CheckBoxPlayer2.Checked ? GamePlay.ePlayingVersus.Player : GamePlay.ePlayingVersus.Computer;
        }

        private void m_ButtonStartGame_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(Math.Round(m_NumercUpDownRows.Value, 0));
            int cols = Convert.ToInt32(Math.Round(m_NumercUpDownColumns.Value, 0));

            if (rows == cols)
            {
                int o_boardSize = Convert.ToInt32(Math.Round(m_NumercUpDownRows.Value, 0));
                //this.Hide();
                //this.Close();
                this.Dispose();
                new BoardForm(o_boardSize, this.m_TextBoxPlayer1Name.Text, m_PlayingVs, this.m_TextBoxPlayer2Name.Text);
                //this.Show();
            }
            else
            {
                MessageBox.Show("Cant create board with current rows and columns size", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
