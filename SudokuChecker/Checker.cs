using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SudokuChecker
{
    public class Checker
    {
        private static string exampleSudoku = "000836009005090000600170040003600002070000918000050000050019400000460000009000037";
        private int[] sudokuArray;

        public Checker(string sudoku)
        {
            if (sudoku == "test")
            {
                sudoku = exampleSudoku;
            }
            // Parse sudoku chars into Array
            sudokuArray = sudoku.ToCharArray().Select(i => Int32.Parse(i.ToString())).ToArray();
            // Check if full sudoku 
            if (sudokuArray.Length != 81)
            {
                throw new Exception("Invalid sudoku string");
            }
        }
        public string FormatSudoku()
        {
            string row = "------------\n";
            string formattedSudoku = "";
            for (int i = 0; i < 81; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    if (i % 9 == 0)
                    {
                        formattedSudoku += "|\n";
                    }
                    else
                    {
                        formattedSudoku += "|";
                    }
                }
                if (i % 27 == 0)
                {
                    formattedSudoku += row;
                }
                formattedSudoku += sudokuArray[i].ToString();
            }
            formattedSudoku += "|\n" + row;
            return formattedSudoku;
        }

        public bool CheckColumns()
        {
            int[][] columnsArray = GetColumns();
            foreach (int[] column in columnsArray)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!column.Contains(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckRows()
        {
            int[][] rowsArray = GetRows();
            foreach (int[] row in rowsArray)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!row.Contains(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckSquares()
        {
            int[][] squaresArray = GetSquares();
            foreach (int[] square in squaresArray)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!square.Contains(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get an array with the rows of the sudoku
        /// </summary>
        /// <returns>An array with int arrays. Each array contains one row</returns>
        private int[][] GetRows()
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
        private int[][] GetColumns()
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

        private int[][] GetSquares()
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
    }
}
