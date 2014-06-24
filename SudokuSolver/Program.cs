using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter Suduko here:");
            var input = Console.ReadLine();
            var sudoku = new Sudoku(input);
            var displayer = new Displayer();
            displayer.Show(sudoku);
            Console.WriteLine();
            Console.WriteLine("Show solve? (y/n)");
            var showSolve = Console.ReadLine() == "y";
            var solver = new Solver(sudoku, showSolve);
            Console.WriteLine();
            Console.WriteLine("***SOLVING***");
            Console.WriteLine();
            solver.Solve();
            Console.WriteLine("SOLUTION:");
            Console.WriteLine();
            displayer.Show(sudoku);
            Console.ReadLine();
        }
    }
}
