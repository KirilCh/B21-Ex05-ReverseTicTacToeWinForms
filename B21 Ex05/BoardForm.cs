using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace B21_Ex05
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

        private string m_PlayerOneName;
        private string m_PlayerTwoName;

        private GamePlay m_GamePlay;
        private Board m_Board;

        private GamePlay.ePlayingVersus m_PlayingVersus;
        private GamePlay.eWhosTurn m_WhosTurn = GamePlay.eWhosTurn.Player1;

        public BoardForm(int i_BoardSize, string i_Player1Name, GamePlay.ePlayingVersus i_PlayingVs, string i_Player2Name)
        {
            this.m_Board = new Board(i_BoardSize);

            this.m_GamePlay = new GamePlay(this.m_Board, (int)i_PlayingVs);
            this.m_PlayingVersus = i_PlayingVs;

            this.m_PlayerOneName = i_Player1Name;
            this.m_PlayerTwoName = i_Player2Name;

            int frameWidth, frameHeight;

            this.m_BoardSize = i_BoardSize;
            frameWidth = (this.m_BoardSize * this.r_SquareSize) + (this.m_BoardSize * (this.m_BoardSize + 3));
            frameHeight = (this.m_BoardSize * this.r_SquareSize) + (this.m_BoardSize * 20);
            this.Size = new Size(frameWidth, frameHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            int spaceBetweenButtons = (int)frameWidth / this.r_SquareSize;
            int xPosition = spaceBetweenButtons, yPosition = spaceBetweenButtons;

            this.m_GameBoard = new Button[this.m_BoardSize, this.m_BoardSize];
            this.m_GameBoardControls = new Control[this.m_BoardSize * this.m_BoardSize];
            int controlsCounter = 0;

            for (int indexRow = 0; indexRow < this.m_BoardSize; indexRow++)
            {
                for (int indexCol = 0; indexCol < this.m_BoardSize; indexCol++)
                {
                    this.m_GameBoard[indexRow, indexCol] = new Button
                    {
                        Enabled = true,
                        Size = new Size(new Point(this.r_SquareSize, this.r_SquareSize)),
                        AutoSize = false,
                        Location = new Point(xPosition, yPosition),
                    };
                    xPosition += spaceBetweenButtons + this.r_SquareSize;
                    this.m_GameBoard[indexRow, indexCol].Text = string.Empty;
                    this.m_GameBoard[indexRow, indexCol].Tag = new int[2] { indexRow, indexCol };
                    this.m_GameBoard[indexRow, indexCol].Click += new EventHandler(this.m_GameBoardButton_Clicked);
                    this.m_GameBoardControls[controlsCounter++] = this.m_GameBoard[indexRow, indexCol];
                }

                xPosition = spaceBetweenButtons;
                yPosition += spaceBetweenButtons + this.r_SquareSize;
            }

            this.Controls.AddRange(this.m_GameBoardControls);

            // Players score
            this.m_LabelPlayer1Name.Text = this.m_PlayerOneName + ": ";
            this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            this.m_LabelPlayer1Name.AutoSize = true;
            this.m_LabelPlayer1Name.Location = new Point((this.Width / 2) - (this.m_LabelPlayer1Name.Width / 2) - 10, this.Bottom - 50);
            this.Controls.Add(this.m_LabelPlayer1Name);

            this.m_Score1.Text = GamePlay.FirstPlayerScore.ToString();
            this.m_Score1.AutoSize = true;
            this.m_Score1.Location = new Point(this.m_LabelPlayer1Name.Right, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_Score1);

            // Depends on game mode
            this.m_LabelPlayer2Name.Text = this.m_PlayerTwoName + ": ";
            this.m_LabelPlayer2Name.AutoSize = true;
            this.m_LabelPlayer2Name.Location = new Point(this.m_Score1.Right + 2, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_LabelPlayer2Name);

            this.m_Score2.Text = GamePlay.SecondPlayerScore.ToString();
            this.m_Score2.AutoSize = true;
            this.m_Score2.Location = new Point(this.m_LabelPlayer2Name.Right, this.m_LabelPlayer1Name.Top);
            this.Controls.Add(this.m_Score2);

            this.ShowDialog();
        }

        private void m_GameBoardButton_Clicked(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            int[] pressedButtonIndex = pressedButton.Tag as int[];
            this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Enabled = false; // Disabled after being taken
            if (this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Text = Board.eIcons.X.ToString();
            }
            else if (this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player2)
            {
                this.m_GameBoard[pressedButtonIndex[0], pressedButtonIndex[1]].Text = Board.eIcons.O.ToString();
            }

            this.m_GamePlay.GamingMove(this.m_WhosTurn, pressedButtonIndex[0], pressedButtonIndex[1]);

            if (!this.gameOver())
            {
                this.turnChanged(sender, e);
            }
        }

        private bool gameOver()
        {
            bool o_isGameOver = false;
            if (this.m_Board.IsGameOver == true)
            {
                if (this.m_Board.IsWinner == true)
                {
                    this.gameOverWin();
                    o_isGameOver = true;
                }
                else
                {
                    this.gameOverTie();
                    o_isGameOver = true;
                }
            }
            else if (this.m_Board.IsBoardFull() == true)
            {
                this.gameOverTie();
                o_isGameOver = true;
            }
            else
            {
                o_isGameOver = false;
            }

            return o_isGameOver;
        }

        private void gameOverWin()
        {
            string tempWinner;
            if (this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                tempWinner = this.m_PlayerOneName;
                GamePlay.FirstPlayerScore++;
            }
            else
            {
                tempWinner = this.m_PlayerTwoName;
                if (this.m_GamePlay.WhosTurn == GamePlay.eWhosTurn.Computer)
                {
                    GamePlay.SecondPlayerScore++;
                }
                else
                {
                    GamePlay.SecondPlayerScore++;
                }
            }

            string output = string.Format("The winner is {0}!" + Environment.NewLine + "Would you like to play another round?", tempWinner);
            DialogResult gameOverDialogResult = MessageBox.Show(output, "A Win!", MessageBoxButtons.YesNo);

            if (gameOverDialogResult == DialogResult.Yes)
            {
                // Play again, with the same settings
                this.Dispose();
                new BoardForm(this.m_BoardSize, this.m_PlayerOneName, this.m_PlayingVersus, this.m_PlayerTwoName);
            }
            else
            {
                // Open game settings menu
                this.Dispose();
                this.Parent = null;
                new FormGameSettings().ShowDialog();
            }
        }

        private void gameOverTie()
        {
            string output = string.Format("Tie!" + Environment.NewLine + "Would you like to play another round?");
            DialogResult gameOverDialogResult = MessageBox.Show(output, "A Win!", MessageBoxButtons.YesNo);

            if (gameOverDialogResult == DialogResult.Yes)
            {
                this.Dispose();
                new BoardForm(this.m_BoardSize, this.m_PlayerOneName, this.m_PlayingVersus, this.m_PlayerTwoName);
            }
            else
            {
                this.Dispose();
                new FormGameSettings().ShowDialog();
            }
        }

        private void turnChanged(object sender, EventArgs e)
        {
            this.m_WhosTurn = this.m_GamePlay.WhosTurn;

            if (this.m_WhosTurn == GamePlay.eWhosTurn.Player1)
            {
                this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                this.m_LabelPlayer2Name.Font = new Font(Label.DefaultFont, FontStyle.Regular);
            }
            else
            {
                if (this.m_WhosTurn == GamePlay.eWhosTurn.Computer)
                {
                    int[] computersPlay = this.m_GamePlay.ComputersMove();
                    this.computerMadeAMove(computersPlay[0], computersPlay[1], Board.eIcons.O);
                    this.m_WhosTurn = this.m_GamePlay.WhosTurn;
                }
                else
                {
                    this.m_LabelPlayer2Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    this.m_LabelPlayer1Name.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                }
            }
        }

        private void computerMadeAMove(int i_indexRow, int i_indexCol, Board.eIcons i_Icon)
        {
            this.m_GameBoard[i_indexRow, i_indexCol].Enabled = false;
            this.m_GameBoard[i_indexRow, i_indexCol].Text = i_Icon.ToString();
            this.gameOver();
        }
    }
}
