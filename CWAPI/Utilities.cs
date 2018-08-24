using System;

namespace CWAPI
{
    public static class Utilities
    {
        public static string RowFromNumber(int number)
        {
            string rowString = "";
            int rowNumber = number;
            while (rowNumber > 0)
            {
                int currentLetterNumber = (rowNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                rowString = currentLetter + rowString;
                rowNumber = (rowNumber - (currentLetterNumber + 1)) / 26;
            }

            return rowString;
        }

        public static int NumberFromRow(string row)
        {
            int returnVal = 0;
            string rowString = row.ToUpper();
            for (int iChar = rowString.Length - 1; iChar >= 0; iChar--)
            {
                char rowPiece = rowString[iChar];
                int rowNum = rowPiece - 64;
                returnVal = returnVal + rowNum * (int)Math.Pow(26, rowString.Length - (iChar + 1));
            }

            return returnVal;
        }
    }
}
