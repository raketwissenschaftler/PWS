using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solver
{
    public class Solver
    {
        public string sudoku;
        public int[] sudokuArray;
        public int[][] columns, rows, squares;

        public Solver(string sudoku)
        {
            this.sudoku = sudoku;
            sudokuArray = Utility.SudokuToArray(sudoku);
            columns = Utility.GetColumns(sudokuArray);
            rows = Utility.GetRows(sudokuArray);
            squares = Utility.GetSquares(sudokuArray);

        }
    }
}
