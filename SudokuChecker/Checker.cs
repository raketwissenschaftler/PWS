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
        private int[][] GetColumns()
        {
            int[][] columnsList = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                int[] column = new int[9];
                for (int c = 0; c < 9; c++)
                {
                    column[c] = sudokuArray[i + (c * 9)];
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
