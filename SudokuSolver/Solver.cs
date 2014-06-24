using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SudokuSolver
{
    public class Solver
    {
        private readonly Sudoku sudoku;
        private readonly bool showSolve;
        private readonly Validator validator = new Validator();
        private readonly Displayer displayer = new Displayer();

        public Solver(Sudoku sudoku, bool showSolve = false)
        {
            this.sudoku = sudoku;
            this.showSolve = showSolve;
        }

        public Sudoku Solve()
        {
            try
            {
                BruteForce();
            }
            catch (SolvedIt)
            {
                return sudoku;
            }
            throw new Exception("Couldn't solve this one!");
        }

        private void BruteForce()
        {
            Show();
            int blankIndex = sudoku.FirstBlankIndex();
            if (blankIndex == -1)
            {
                throw new SolvedIt();
            }
            for (int i = 1; i <= 9; i++)
            {
                sudoku[blankIndex] = i;
                if (validator.IsValid(sudoku))
                {
                    BruteForce();
                }
            }
            sudoku[blankIndex] = 0;
        }

        private void Show()
        {
            if (showSolve)
            {
                displayer.Show(sudoku);
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    internal class SolvedIt : Exception
    {
    }
}
