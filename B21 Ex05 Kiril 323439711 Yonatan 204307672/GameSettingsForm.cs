using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    class GameSettingsForm : Form
    {
        Label m_LabelPlayers = new Label();
        Label m_LabelPlayer1 = new Label();
        Label m_LabelPlayer2 = new Label();
        Label m_LabelBoardSize = new Label();
        Label m_LabelRows = new Label();
        Label m_LabelColumns = new Label();

        CheckBox m_CheckBoxPlayer2 = new CheckBox();

        TextBox m_TextBoxPlayer1Name = new TextBox();
        TextBox m_TextBoxPlayer2Name = new TextBox(); //Should initiate to disabled state

        NumericUpDown m_NumercUpDownRows = new NumericUpDown();
        NumericUpDown m_NumercUpDownColumns = new NumericUpDown();

        Button m_ButtonStartGame = new Button();

        public GameSettingsForm()
        {
            this.Text = "Game Settings";
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(250, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowIcon = false;

            this.m_LabelPlayers.Text = "Players:";
            this.m_LabelPlayers.Location = new Point(10, 10);
            this.Controls.Add(this.m_LabelPlayers);

            this.m_LabelPlayer1.Text = "Player 1:";
            this.m_LabelPlayer1.Location = new Point(20, 35);
            this.m_LabelPlayer1.AutoSize = true;
            this.Controls.Add(this.m_LabelPlayer1);

            this.m_TextBoxPlayer1Name.Text = string.Empty;
            this.m_TextBoxPlayer1Name.Location = new Point(this.m_LabelPlayer1.Right + 20, this.m_LabelPlayer1.Top - 2);
            this.Controls.Add(this.m_TextBoxPlayer1Name);

            this.m_CheckBoxPlayer2.Checked = false;
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new Point(this.m_LabelPlayer1.Left, this.m_LabelPlayer1.Bottom + 5);
            this.m_CheckBoxPlayer2.Click += new EventHandler(m_CheckBoxPlayer2_StateChanged);
            this.Controls.Add(this.m_CheckBoxPlayer2);

            this.m_LabelPlayer2.Text = "Player 2:";
            this.m_LabelPlayer2.AutoSize = true;
            this.m_LabelPlayer2.Location = new Point(this.m_CheckBoxPlayer2.Right+2, this.m_CheckBoxPlayer2.Top);
            this.Controls.Add(this.m_LabelPlayer2);

            this.m_TextBoxPlayer2Name.Text = "[Computer]";
            this.m_TextBoxPlayer2Name.Enabled = false;
            this.m_TextBoxPlayer2Name.Location = new Point(this.m_TextBoxPlayer1Name.Left, this.m_CheckBoxPlayer2.Top);
            this.Controls.Add(this.m_TextBoxPlayer2Name);

            this.m_LabelBoardSize.Text = "Board Size";
            this.m_LabelBoardSize.Location = new Point(this.m_LabelPlayers.Left, this.m_CheckBoxPlayer2.Bottom + 25);
            this.Controls.Add(this.m_LabelBoardSize);

            this.m_LabelRows.Text = "Rows:";
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new Point(this.m_LabelBoardSize.Left + 10, this.m_LabelBoardSize.Bottom + 5);
            this.Controls.Add(this.m_LabelRows);

            this.m_NumercUpDownRows.Location = new Point(this.m_LabelRows.Right+10, this.m_LabelRows.Top-2);
            this.m_NumercUpDownRows.Width = 40;
            this.m_NumercUpDownRows.Value = 3;
            this.m_NumercUpDownRows.Minimum = 3;
            this.m_NumercUpDownRows.Maximum = 9;
            this.Controls.Add(this.m_NumercUpDownRows);

            this.m_LabelColumns.Text = "Cols:";
            this.m_LabelColumns.AutoSize = true;
            this.m_LabelColumns.Location = new Point(this.m_NumercUpDownRows.Right + 10, this.m_LabelRows.Top);
            this.Controls.Add(this.m_LabelColumns);

            this.m_NumercUpDownColumns.Location = new Point(this.m_LabelColumns.Right + 10, this.m_LabelRows.Top - 2);
            this.m_NumercUpDownColumns.Width = 40;
            this.m_NumercUpDownColumns.Value = 3;
            this.m_NumercUpDownColumns.Minimum = 3;
            this.m_NumercUpDownColumns.Maximum = 9;
            this.Controls.Add(this.m_NumercUpDownColumns);

            this.m_ButtonStartGame.Text = "Start!";
            this.m_ButtonStartGame.TextAlign = ContentAlignment.MiddleCenter;

            this.m_ButtonStartGame.Location = new Point(this.m_LabelBoardSize.Left, this.m_LabelRows.Bottom + 25);
            this.m_ButtonStartGame.Width = this.Size.Width - 30;
            this.m_ButtonStartGame.Click += new EventHandler(m_ButtonStartGame_Clicked);
            this.Controls.Add(this.m_ButtonStartGame);

        }

        private void m_CheckBoxPlayer2_StateChanged(object sender, EventArgs e)
        {
            m_TextBoxPlayer2Name.Enabled = m_CheckBoxPlayer2.Checked;
        }

        private void m_ButtonStartGame_Clicked(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(Math.Round(m_NumercUpDownRows.Value, 0));
            int cols = Convert.ToInt32(Math.Round(m_NumercUpDownColumns.Value, 0));

            if (rows == cols)
            {
                int o_boardSize = Convert.ToInt32(Math.Round(m_NumercUpDownRows.Value, 0));
                new BoardForm(o_boardSize);
            }
            else
            {
                MessageBox.Show("Cant create board with current rows and columns size", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


