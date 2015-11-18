using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
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

        public int[] GetEmptyPlacesPerSquare()
        {
            int[] emptyPlacesArray = new int[9];
            int counter = 0;
            foreach (int[] square in squares)
            {
                emptyPlacesArray[counter] = square.Count(x => x == 0);
                counter++;
            }
            return emptyPlacesArray;
        }
        public int[] GetPossibilitiesForPlace(int placeIndex)
        {
            int[] placeSquare = squares[Utility.GetSquare(placeIndex)];
            int[] numbersInSudoku = Enumerable.Range(0, 9).ToArray();
            List<int> resultsList = new List<int>();
            foreach (int sudokuNumber in numbersInSudoku)
            {
                if (!placeSquare.Contains(sudokuNumber))
                {
                    resultsList.Add(sudokuNumber);
                }
            }
            return resultsList.ToArray();
        }
    }
}
