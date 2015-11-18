using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class Utility
    {
        /// <summary>
        /// Get an array with the rows of the sudoku
        /// </summary>
        /// <returns>An array with int arrays. Each array contains one row</returns>
        public static int[][] GetRows(int[] sudokuArray)
        {
            // This is the array that stores all the rows
            int[][] rowsArray = new int[9][];
            // We need a list because an array doesn't have the getRange method.
            List<int> sudokuArrayList = new List<int>(sudokuArray);
            for (int i = 0; i < 9; i++)
            {
                // There are 9 rows, get the content of each row and add it to the array
                rowsArray[i] = sudokuArrayList.GetRange(i * 9, 9).ToArray(); // i*9 gets the index of the first item in that row, and after that it takes the 9 elements after that.
            }
            return rowsArray;
        }
        /// <summary>
        /// Get an array with the columns of the sudoku
        /// </summary>
        /// <returns>An array with int arrays. Each array contains one column</returns>
        public static int[][] GetColumns(int[] sudokuArray)
        {
            // This list stores all columns
            int[][] columnsList = new int[9][];
            for (int i = 0; i < 9; i++) // Iterate through the 9 columns. I is the index of the first number of each column
            {
                // Create a list for each column
                int[] column = new int[9];
                for (int r = 0; r < 9; r++) // Iterate through the 9 numbers in each column
                {
                    column[r] = sudokuArray[i + (r * 9)]; // Startindex + 9 is the next number in each column
                }
                columnsList[i] = column;
            }
            return columnsList;
        }

        public static int[][] GetSquares(int[] sudokuArray)
        {
            int[][] squares = new int[9][];
            int[] startIndices = new int[9] { 0, 3, 6, 27, 30, 33, 54, 47, 60 };
            int counter = 0;
            foreach (int startIndex in startIndices)
            {
                List<int> squareList = new List<int>();
                for (int i = startIndex; i < startIndex + 27; i = i + 9)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        squareList.Add(sudokuArray[i + c]);
                    }
                }
                squares[counter] = squareList.ToArray();
                counter++;
            }
            return squares;
        }

        public static int[] SudokuToArray(string sudoku)
        {
            return sudoku.ToCharArray().Select(i => Int32.Parse(i.ToString())).ToArray();
        }

        public static int GetColumn(int index)
        {
            return index % 9;
        }

        public static int GetRow(int index)
        {
            return index / 9;
        }

        public static int GetSquare(int index)
        {
            int[] startIndices = new int[9] { 0, 3, 6, 27, 30, 33, 54, 47, 60 };
            int startIndex =  startIndices.First(x => index > x);
            return Array.IndexOf(startIndices, startIndex);
        }
    }
}
