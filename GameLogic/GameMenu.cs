using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameMenu
    {
        private static readonly int sr_GameBoardMinSize = 3;
        private static readonly int sr_GameBoardMaxSize = 9;
        private readonly int r_GameBoardSize;
        private Board m_GameBoard;

        public static int GameBoardMinSize
        {
            get
            {
                return sr_GameBoardMinSize;
            }
        }

        public static int GameBoardMaxSize
        {
            get
            {
                return sr_GameBoardMaxSize;
            }
        }

        public GameMenu()
        {
            this.m_GameBoard = new Board(this.r_GameBoardSize);
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
