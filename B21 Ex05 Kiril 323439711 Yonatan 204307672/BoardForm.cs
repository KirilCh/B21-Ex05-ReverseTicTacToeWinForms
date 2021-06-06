using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GameLogic;


namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    public partial class BoardForm : Form
    {
        private Button[,] m_GameBoard;
        private Control[] m_GameBoardControls;
        private int m_BoardSize;
        private readonly int r_SquareSize = 50;

        private Label m_LabelPlayer1Name = new Label();
        private Label m_Score1 = new Label();
        private Label m_LabelPlayer2Name = new Label();
        private Label m_Score2 = new Label();

        private GamePlay m_GamePlay;
        private Board m_Board;

        private GamePlay.ePlayingVersus m_PlayingVersus;

        //Default
        private GamePlay.eWhosTurn m_WhosTurn = GamePlay.eWhosTurn.Player1;
        //private Board.eIcons m_CurrentIcon = Board.eIcons.X;

        public BoardForm(int i_BoardSize, string i_Player1Name, GamePlay.ePlayingVersus i_PlayingVs, string i_Player2Name)
        {
            m_Board = new Board(i_BoardSize);
            m_GamePlay = new GamePlay(m_Board, (int)i_PlayingVs);
            m_PlayingVersus = i_PlayingVs;

            int frameWidth, frameHeight;
            m_BoardSize = i_BoardSize;
            frameWidth = m_BoardSize * 100;
            frameHeight = m_BoardSize * 100;
            this.Size = new Size(frameWidth, frameHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            int width = (int)((this.Width * 0.6) / m_BoardSize);

            this.m_GameBoard = new Button[m_BoardSize, m_BoardSize];
            m_GameBoardControls = new Control[m_BoardSize * m_BoardSize];
            int controlsCounter = 0;

            for (int indexRow = 0; indexRow < m_BoardSize; indexRow++)
            {
                for(int indexCol = 0; indexCol < m_BoardSize; indexCol++)
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
            this.m_LabelPlayer1Name.Text = i_Player1Name + ": ";
            this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            this.m_LabelPlayer1Name.AutoSize = true;
            this.m_LabelPlayer1Name.Location = new Point(this.Width / 2 - this.m_LabelPlayer1Name.Width/2 - 10, this.Bottom - 50);
            this.Controls.Add(this.m_LabelPlayer1Name);

            this.m_Score1.Text = "0";
            this.m_Score1.AutoSize = true;
            this.m_Score1.Location = new Point(this.m_LabelPlayer1Name.Right, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_Score1);

            //Depends on game mode
            this.m_LabelPlayer2Name.Text = i_Player2Name;
            this.m_LabelPlayer2Name.AutoSize = true;
            this.m_LabelPlayer2Name.Location = new Point(this.m_Score1.Right + 2, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_LabelPlayer2Name);

            this.m_Score2.Text = "0";
            this.m_Score2.AutoSize = true;
            this.m_Score2.Location = new Point(this.m_LabelPlayer2Name.Right, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_Score2);

            this.ShowDialog();
        }

        private void m_GameBoardButton_Clicked(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            int[] pressedButtonIndex = pressedButton.Tag as int[];
            this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Enabled = false; //Disabled after being taken
            if(this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Text = Board.eIcons.X.ToString();
            }
            else if(this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player2)
            {
                this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Text = Board.eIcons.O.ToString();
            }

            //Should listener be removed if button is disabled? 
            //string output = string.Format(@"Pressed button at ({0},{1})", pressedButtonIndex[0], pressedButtonIndex[1]);
            //MessageBox.Show(output, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Switch bold player label
            
            m_GamePlay.GamingMove(m_WhosTurn, pressedButtonIndex[0], pressedButtonIndex[1]);
            GameOver();
            turnChangedHandler(sender, e);
        }

        public void GameOver()
        {
            if (this.m_Board.IsGameOver == true)
            {
                if(this.m_Board.IsWinner == true)
                {
                    this.gameOverWin();
                }
                else
                {
                    this.gameOverTie();
                }
                /*if (this.m_Board.IsBoardFull() == true)
                {
                    if(this.m_Board.IsWinner == true)
                    {

                    }
                    this.gameOverTie();
                }
                else
                {
                    this.gameOverWin();
                }    */
            }
           
        }

        private void gameOverWin()
        {
            //Should receive the winner as an enum/string
            string tempWinner;
            if(m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                tempWinner = this.m_LabelPlayer1Name.Text;
            }
            else
            {
                tempWinner = this.m_LabelPlayer2Name.Text;
            }

            string output = string.Format("The winner is {0}!" + Environment.NewLine + "Would you like to play another round?", tempWinner);
            DialogResult gameOverDialogResult = MessageBox.Show(output, "A Win!", MessageBoxButtons.YesNo);

            if(gameOverDialogResult == DialogResult.Yes)
            {
                //Play again, with the same settings
                this.Hide();
                new BoardForm(m_BoardSize, m_LabelPlayer1Name.Text, m_PlayingVersus, m_LabelPlayer2Name.Text).Show();
            }
            else
            {
                //Open game settings menu
                this.Hide();
                new GameSettingsForm().ShowDialog();
            }
        }

        private void gameOverTie()
        {
            string output = string.Format("Tie!" + Environment.NewLine + "Would you like to play another round?");
            DialogResult gameOverDialogResult = MessageBox.Show(output, "A Win!", MessageBoxButtons.YesNo);

            if (gameOverDialogResult == DialogResult.Yes)
            {
                //Play again, with the same settings
                this.Hide();
                new BoardForm(m_BoardSize, m_LabelPlayer1Name.Text, m_PlayingVersus, m_LabelPlayer2Name.Text).Show();
            }
            else
            {
                //Open game settings menu
                this.Hide();
                new GameSettingsForm().ShowDialog();
            }
        }

        private void turnChangedHandler(object sender, EventArgs e)
        {
            m_WhosTurn = m_GamePlay.WhosTurn;

            if (m_WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                this.m_LabelPlayer2Name.Font = new Font(Label.DefaultFont, FontStyle.Regular);
            }
            else
            {
                if(m_WhosTurn == GamePlay.eWhosTurn.Computer)
                {
                    int[] computersPlay = this.m_GamePlay.ComputersMove();
                    computerMadeAMove(computersPlay[0], computersPlay[1], Board.eIcons.O);
                    m_WhosTurn = m_GamePlay.WhosTurn;
                }
                else
                {
                    this.m_LabelPlayer2Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                }
            }
        }

        public void computerMadeAMove(int i_indexRow, int i_indexCol, Board.eIcons i_Icon)
        {
            //Consider adding a delegate
            //COnsider making the computer turn function to return the indexes of selected box here

            m_GameBoard[i_indexRow, i_indexCol].Enabled = false;
            m_GameBoard[i_indexRow, i_indexCol].Text = i_Icon.ToString();
            GameOver();
        }
    }
}
