using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Board
    {
        private readonly int[,] r_GameBoard;
        private static int s_TurnCount = 0;

        private int m_SizeOfBoard;
        private bool m_IsGameOver;
        private bool m_IsThereWinner = false;

        public enum eIcons
        {
            Empty, // 0
            X,     // 1
            O, // 2
        }

        public int SizeOfBoard
        {
            get
            {
                return this.m_SizeOfBoard;
            }

            set
            {
                this.m_SizeOfBoard = value;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return this.m_IsGameOver;
            }

            set
            {
                this.m_IsGameOver = value;
            }
        }

        public bool IsWinner
        {
            get
            {
                return this.m_IsThereWinner;
            }

            set
            {
                this.m_IsThereWinner = value;
            }
        }

        public Board(int i_BoardSize)
        {
            this.m_SizeOfBoard = i_BoardSize;
            this.r_GameBoard = new int[this.m_SizeOfBoard, this.m_SizeOfBoard]; // 2D array to contain the board for the game
            this.m_IsGameOver = false;
        }

        public bool MakeMove(int i_PositionRow, int i_PositionColumn, eIcons i_Icon) // True if move is legal, false if illegal
        {
            bool o_validMove = false;

            if (this.isLocationEmpty(i_PositionRow, i_PositionColumn))
            {
                this.r_GameBoard[i_PositionRow, i_PositionColumn] = (int)i_Icon;
                o_validMove = true;
                s_TurnCount++;

                // Check for game over situations here once min number of moves were made to create a streak by a player -> 2*SizeOfBoard - 1
                // Provide with the latest move made (the x,y location)
                if (s_TurnCount >= ((this.m_SizeOfBoard * 2) - 1))
                {
                    this.checkForWinStreak(i_PositionRow, i_PositionColumn);
                }
            }

            return o_validMove;
        }

        // Check if picked square is available to make a move at
        private bool isLocationEmpty(int i_PositionRow, int i_PositionColumn)
        {
            bool o_isPositionAvailable = false;

            if (this.r_GameBoard[i_PositionRow, i_PositionColumn] == (int)eIcons.Empty)
            {
                o_isPositionAvailable = true;
            }

            return o_isPositionAvailable;
        }

        // Function to check board for a winner, win streak is of board size length (Column, Row, Diagonal)
        private void checkForWinStreak(int i_PositionRow, int i_PositionColumn)
        {
            if (this.checkForRowStreak(i_PositionRow, i_PositionColumn))
            {
                this.IsGameOver = true;
                this.m_IsThereWinner = true;
            }
            else if (this.checkForColumnStreak(i_PositionRow, i_PositionColumn))
            {
                this.IsGameOver = true;
                this.m_IsThereWinner = true;
            }
            else if (i_PositionRow == 0 || i_PositionRow - 1 == (this.m_SizeOfBoard - 1) || i_PositionColumn == 0 ||
                i_PositionColumn - 1 == (this.m_SizeOfBoard - 1) || i_PositionRow == i_PositionColumn)
            {
                if (this.checkForDiagonalStreak() || this.checkForReverseDiagonalStreak())
                {
                    this.IsGameOver = true;
                    this.m_IsThereWinner = true;
                }
            }
        }

        // Function to go over all rows and check if theres a winning (losing, in this case) streak
        private bool checkForRowStreak(int i_PositionRow, int i_PositionColumn)
        {
            bool o_rowStreak = true;
            int cellIcon = this.r_GameBoard[i_PositionRow, i_PositionColumn];

            for (int index = 0; index < this.m_SizeOfBoard; index++)
            {
                if (this.r_GameBoard[i_PositionRow, index] != cellIcon)
                {
                    o_rowStreak = false;
                    break;
                }
            }

            return o_rowStreak;
        }

        // Function to go over all columns and check if theres a winning (losing, in this case) streak
        private bool checkForColumnStreak(int i_PositionRow, int i_PositionColumn)
        {
            bool o_columnStreak = true;
            int cellIcon = this.r_GameBoard[i_PositionRow, i_PositionColumn];

            for (int index = 0; index < this.m_SizeOfBoard; index++)
            {
                if (this.r_GameBoard[index, i_PositionColumn] != cellIcon)
                {
                    o_columnStreak = false;
                    break;
                }
            }

            return o_columnStreak;
        }

        // Function to go over diagonal and check if theres a winning (losing, in this case) streak
        private bool checkForDiagonalStreak()
        {
            bool o_diagonalStreak = true;
            int cellIcon = this.r_GameBoard[0, 0];

            if (cellIcon != 0)
            {
                for (int diagonalIndex = 1; diagonalIndex < this.m_SizeOfBoard; diagonalIndex++)
                {
                    if (cellIcon != this.r_GameBoard[diagonalIndex, diagonalIndex])
                    {
                        o_diagonalStreak = false;
                        break;
                    }
                }
            }
            else
            {
                o_diagonalStreak = false;
            }

            return o_diagonalStreak;
        }

        // Function to go over reverse diagonal and check if theres a winning (losing, in this case) streak
        private bool checkForReverseDiagonalStreak()
        {
            bool o_diagonalStreak = true;
            int cellIcon = this.r_GameBoard[0, this.m_SizeOfBoard - 1];

            if (cellIcon != 0)
            {
                for (int indexRow = 0, indexColumn = this.m_SizeOfBoard - 1; indexRow < this.m_SizeOfBoard; indexRow++, indexColumn--)
                {
                    if (cellIcon != this.r_GameBoard[indexRow, indexColumn])
                    {
                        o_diagonalStreak = false;
                        break;
                    }
                }
            }
            else
            {
                o_diagonalStreak = false;
            }

            return o_diagonalStreak;
        }

        // Function to check if game board is full
        public bool IsBoardFull()
        {
            bool o_isFull = true;

            for (int indexRow = 0; indexRow < this.m_SizeOfBoard; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < this.m_SizeOfBoard; indexColumn++)
                {
                    if (this.r_GameBoard[indexRow, indexColumn] == (int)eIcons.Empty)
                    {
                        o_isFull = false;
                        break;
                    }
                }

                if (o_isFull == false)
                {
                    break;
                }
            }

            return o_isFull;
        }
    }
}
