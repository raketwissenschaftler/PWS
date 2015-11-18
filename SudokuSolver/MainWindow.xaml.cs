using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SudokuChecker;
using SudokuSolver;
using System.Diagnostics;

namespace SudokuSolverProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Checker checker;
        private static string exampleSudoku = "000836009005090000600170040003600002070000918000050000050019400000460000009000037";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkSudokuButton_Click(object sender, RoutedEventArgs e)
        {
            string sudoku = sudokuTextBox.Text;
            if (sudoku == "test")
            {
                sudoku = exampleSudoku;
            }
            checker = new Checker(sudoku);
            outputTextBlock.Text = checker.FormatSudoku();
            Solver solver = new Solver(sudoku);
            outputTextBlock.Text = String.Join(",", solver.GetEmptyPlacesPerSquare());
        }
    }
}
