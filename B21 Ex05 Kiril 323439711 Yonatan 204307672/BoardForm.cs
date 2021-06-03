using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    public partial class BoardForm : Form
    {
        private Button[,] m_GameBoard;
        private Control[] m_GameBoardControls;
        private readonly int r_SquareSize = 50;

        private Label m_LabelPlayer1Name = new Label();
        private Label m_Score1 = new Label();
        private Label m_LabelPlayer2Name = new Label();
        private Label m_Score2 = new Label();

        public BoardForm(int i_BoardSize)
        {
            int frameWidth, frameHeight;
            frameWidth = i_BoardSize*100;
            frameHeight = i_BoardSize*100;
            this.Size = new Size(frameWidth, frameHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            int width = (int)((this.Width * 0.6) / i_BoardSize);

            this.m_GameBoard = new Button[i_BoardSize, i_BoardSize];
            m_GameBoardControls = new Control[i_BoardSize * i_BoardSize];
            int controlsCounter = 0;

            for (int indexRow = 0; indexRow < i_BoardSize; indexRow++)
            {
                for(int indexCol = 0; indexCol < i_BoardSize; indexCol++)
                {
                    m_GameBoard[indexRow, indexCol] = new Button();
                    m_GameBoard[indexRow, indexCol].Enabled = true;
                    m_GameBoard[indexRow, indexCol].Size = new Size(new Point(r_SquareSize , r_SquareSize));
                    m_GameBoard[indexRow, indexCol].AutoSize = false;
                    m_GameBoard[indexRow, indexCol].Location = new Point((indexRow + 1)* width, (indexCol+1) * width);
                    m_GameBoard[indexRow, indexCol].Text = string.Empty;
                    m_GameBoard[indexRow, indexCol].Tag = new int[2] { indexRow, indexCol }; // For later use, when pressing button to mark X/O
                    m_GameBoard[indexRow, indexCol].Click += new EventHandler(m_GameBoardButton_Clicked);
                    m_GameBoardControls[controlsCounter++] = m_GameBoard[indexRow, indexCol];
                }
            }
      
            this.Controls.AddRange(m_GameBoardControls);

            //Players score
            this.m_LabelPlayer1Name.Text = "Player 1:";
            this.m_LabelPlayer1Name.AutoSize = true;
            this.m_LabelPlayer1Name.Location = new Point(this.Width / 2 - this.m_LabelPlayer1Name.Width, this.Bottom - 50);
            this.Controls.Add(this.m_LabelPlayer1Name);

            this.m_Score1.Text = "0";
            this.m_Score1.AutoSize = true;
            this.m_Score1.Location = new Point(this.m_LabelPlayer1Name.Right, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_Score1);

            //Depends on game mode
            this.m_LabelPlayer2Name.Text = "Player 2:";
            this.m_Score2.Text = "0";

            this.ShowDialog();
        }

        private void m_GameBoardButton_Clicked(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            int[] pressedButtonIndex = pressedButton.Tag as int[];
            this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Enabled = false; //Disabled after being taken

            //Should listener be removed if button is disabled? 
            string output = string.Format(@"Pressed button at ({0},{1})", pressedButtonIndex[0], pressedButtonIndex[1]);
            MessageBox.Show(output, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
