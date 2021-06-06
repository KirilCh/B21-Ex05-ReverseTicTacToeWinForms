using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameMenu
    {
        private const int s_GameBoardMinSize = 3;
        private static int s_GameBoardMaxSize = 9;
        private StringBuilder m_BoardString;
        private Board m_GameBoard;

        private readonly int r_WhoToPlayAgainst;
        private readonly int r_GameBoardSize;

        public static int GameBoardMinSize
        {
            get
            {
                return s_GameBoardMinSize;
            }
        }

        public static int GameBoardMaxSize
        {
            get
            {
                return s_GameBoardMaxSize;
            }
        }

        public GameMenu()
        {
            //r_WhoToPlayAgainst = WhoToPlayAgainst();

            //r_WhoToPlayAgainst = This comes from m_CheckBoxPlayer2_StateChanged, if its checked its vs Player, else its vs Computer
            //r_GameBoardSize = GetBoardSize();
            m_GameBoard = new Board(r_GameBoardSize);

            //Ex02.ConsoleUtils.Screen.Clear();
            //InitDrawBoard(m_GameBoard.SizeOfBoard);

            // Start game according to game mode
            //GamePlay gamePlay = new GamePlay(m_GameBoard, /*this,*/ m_WhoToPlayAgainst);
            while (true)
            {
                //PlayAgainOrExit();
            }
        }

        public void ScoreResult(string i_PlayerOne, string i_PlayerTwo, int i_PlayerOneScore, int i_PlayerTwoScore)
        {
            string scoreResult = string.Format(
                "The score results are: " + Environment.NewLine +
                "{0}`s score is: {1}" + Environment.NewLine +
                "{2}`s score is: {3}" + Environment.NewLine,
                i_PlayerOne,
                i_PlayerOneScore,
                i_PlayerTwo,
                i_PlayerTwoScore);

            Console.WriteLine(scoreResult);
        }
    }
}
