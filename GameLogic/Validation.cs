using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Validation
    {
        public static bool IsValidGameBoardSize(int i_BoardSize)
        {
            bool o_isValidSize = true;

            if (!(i_BoardSize >= GameMenu.GameBoardMinSize && i_BoardSize <= GameMenu.GameBoardMaxSize))
            {
                o_isValidSize = false;
            }

            return o_isValidSize;
        }

        public static bool IsValidIndexEntry(string i_UserInput, int i_BoardSize)
        {
            bool o_isValidEntry = true;

            if (int.TryParse(i_UserInput, out int output))
            {
                if (output < 0 || output > i_BoardSize)
                {
                    o_isValidEntry = false;
                }
            }
            else
            {
                o_isValidEntry = false;
            }

            return o_isValidEntry;
        }

        public static bool IsValidIcon(Board.eIcons i_Icon)
        {
            bool o_isValidIcon = true;

            if (!Enum.IsDefined(typeof(Board.eIcons), i_Icon))
            {
                o_isValidIcon = false;
            }

            return o_isValidIcon;
        }
    }
}
