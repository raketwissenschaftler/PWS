using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Solver;

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
            int[][] columnsArray = Utility.GetColumns(sudokuArray);
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
            int[][] rowsArray = Utility.GetRows(sudokuArray);
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
            int[][] squaresArray = Utility.GetSquares(sudokuArray);
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
    }
}
