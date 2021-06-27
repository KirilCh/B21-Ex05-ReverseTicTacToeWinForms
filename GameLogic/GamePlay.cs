using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GamePlay
    {
        public enum eWhosTurn
        {
            Player1,
            Player2,
            Computer,
        }

        public enum ePlayingVersus
        {
            Player,
            Computer,
        }

        private static int s_PlayerOneScore;
        private static int s_PlayerTwoScore;
        private static int s_ComputerScore;
        private eWhosTurn m_WhosTurn;
        private ePlayingVersus m_PlayingVersus;
        private Board.eIcons m_Icon;
        private Board m_GameBoard;
        private GameMenu m_GameMenu;
        private Random m_Random = new Random();

        public static int FirstPlayerScore
        {
            get
            {
                return s_PlayerOneScore;
            }

            set
            {
                s_PlayerOneScore = value;
            }
        }

        public static int SecondPlayerScore
        {
            get
            {
                return s_PlayerTwoScore;
            }

            set
            {
                s_PlayerTwoScore = value;
            }
        }

        public static int ComputerPlayerScore
        {
            get
            {
                return s_ComputerScore;
            }

            set
            {
                s_ComputerScore = value;
            }
        }

        public eWhosTurn WhosTurn
        {
            get
            {
                return this.m_WhosTurn;
            }

            set
            {
                this.m_WhosTurn = value;
            }
        }

        public ePlayingVersus PlayingVersus
        {
            get
            {
                return this.m_PlayingVersus;
            }

            set
            {
                this.m_PlayingVersus = value;
            }
        }

        public Board.eIcons CurrentIcon
        {
            get
            {
                return this.m_Icon;
            }

            set
            {
                this.m_Icon = value;
            }
        }

        public GamePlay(Board i_GameBoard, int i_VsSelection)
        {
            this.m_GameBoard = i_GameBoard;
            this.m_PlayingVersus = (ePlayingVersus)i_VsSelection;
            this.m_WhosTurn = eWhosTurn.Player1;
            this.m_Icon = Board.eIcons.X;
        }

        public void GamingMove(eWhosTurn i_whosTurn, int i_rowIndex, int i_colIndex)
        {
            Board.eIcons iconToPlace;
            if (i_whosTurn == eWhosTurn.Player1)
            {
                iconToPlace = Board.eIcons.X;
            }
            else
            {
                iconToPlace = Board.eIcons.O;
            }

            if (this.m_GameBoard.IsBoardFull() == false && this.m_GameBoard.IsGameOver == false)
            {
                this.m_GameBoard.MakeMove(i_rowIndex, i_colIndex, iconToPlace);
                this.SwapPlayersTurn();
                this.SwapCurrentIcon();
            }
        }

        public int[] ComputersMove()
        {
            int selectedRow = 0, selectedColumn = 0;
            int[] o_computersMove = new int[2];

            if (this.m_GameBoard.IsBoardFull() == false && this.m_GameBoard.IsGameOver == false)
            {
                this.ComputerPlay(ref selectedRow, ref selectedColumn);

                while (this.m_GameBoard.MakeMove(selectedRow, selectedColumn, this.m_Icon) != true)
                {
                    this.ComputerPlay(ref selectedRow, ref selectedColumn);
                }

                o_computersMove[0] = selectedRow;
                o_computersMove[1] = selectedColumn;

                this.SwapPlayersTurn();
                this.SwapCurrentIcon();
            }

            return o_computersMove;
        }

        protected void StartGame()
        {
            int selectedRow = 0, selectedColumn = 0;

            while (this.m_GameBoard.IsBoardFull() == false && this.m_GameBoard.IsGameOver == false)
            {
                if (this.m_WhosTurn.ToString().Equals(ePlayingVersus.Computer.ToString()))
                {
                    this.ComputerPlay(ref selectedRow, ref selectedColumn);
                }

                if (this.m_GameBoard.MakeMove(selectedRow - 1, selectedColumn - 1, this.m_Icon) == true)
                {
                    this.SwapPlayersTurn();
                    this.SwapCurrentIcon();
                }
            }

            if (this.m_GameBoard.IsGameOver == true)
            {
                this.UpdateScore(this.m_WhosTurn);
                this.ProvideUiWithScore();
            }
        }

        protected void ComputerPlay(ref int i_SelectedRow, ref int i_SelectedColumn) // Computer makes a random move
        {
            i_SelectedRow = this.m_Random.Next(0, this.m_GameBoard.SizeOfBoard);
            i_SelectedColumn = this.m_Random.Next(0, this.m_GameBoard.SizeOfBoard);
        }

        protected void SwapPlayersTurn()
        {
            switch (this.m_PlayingVersus)
            {
                case ePlayingVersus.Computer:
                    if (this.WhosTurn == eWhosTurn.Player1)
                    {
                        this.WhosTurn = eWhosTurn.Computer;
                    }
                    else
                    {
                        this.WhosTurn = eWhosTurn.Player1;
                    }

                    break;

                case ePlayingVersus.Player:
                    if (this.WhosTurn == eWhosTurn.Player1)
                    {
                        this.WhosTurn = eWhosTurn.Player2;
                    }
                    else
                    {
                        this.WhosTurn = eWhosTurn.Player1;
                    }

                    break;

                default:
                    break;
            }
        }

        protected void SwapCurrentIcon()
        {
            switch (this.CurrentIcon)
            {
                case Board.eIcons.X:
                    this.CurrentIcon = Board.eIcons.O;
                    break;

                case Board.eIcons.O:
                    this.CurrentIcon = Board.eIcons.X;
                    break;
            }
        }

        protected void UpdateScore(eWhosTurn i_Winner)
        {
            switch (i_Winner)
            {
                case eWhosTurn.Player1:
                    FirstPlayerScore++;
                    break;

                case eWhosTurn.Player2:
                    SecondPlayerScore++;
                    break;

                case eWhosTurn.Computer:
                    ComputerPlayerScore++;
                    break;

                default:
                    break;
            }
        }

        protected void ProvideUiWithScore()
        {
            switch (this.m_PlayingVersus)
            {
                case ePlayingVersus.Player:
                    this.m_GameMenu.ScoreResult(eWhosTurn.Player1.ToString(), eWhosTurn.Player2.ToString(), FirstPlayerScore, SecondPlayerScore);
                    break;

                case ePlayingVersus.Computer:
                    this.m_GameMenu.ScoreResult(eWhosTurn.Player1.ToString(), eWhosTurn.Computer.ToString(), FirstPlayerScore, ComputerPlayerScore);
                    break;

                default:
                    break;
            }
        }

        public int[] GetScores()
        {
            int[] playerScores = new int[2];
            switch (this.m_PlayingVersus)
            {
                case ePlayingVersus.Player:
                    playerScores[0] = FirstPlayerScore;
                    playerScores[1] = SecondPlayerScore;
                    break;

                case ePlayingVersus.Computer:
                    playerScores[0] = FirstPlayerScore;
                    playerScores[1] = ComputerPlayerScore;
                    break;

                default:
                    break;
            }

            return playerScores;
        }
    }
}