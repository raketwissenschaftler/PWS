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
        private int[][] squaresArray, horizontalColumns, verticalColumns;

        public Checker(string sudoku)
        {
            if (sudoku == "test")
            {
                sudoku = exampleSudoku;
            }
            sudokuArray = sudoku.ToCharArray().Select(i => Int32.Parse(i.ToString())).ToArray();
            if (sudokuArray.Length != 81)
            {
                throw new Exception("Invalid sudoku string");
            }
            GetRows();
        }

        private int[][] GetRows()
        {
            int[][] rowsList = new int[9][];
            for(int i=0; i < 9; i++)
            {
                rowsList[i] = new List<int>(sudokuArray).GetRange(i * 9, 9).ToArray();
            }
            return rowsList;
        }
    }
}
