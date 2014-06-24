using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Displayer
    {
        public void Show(Sudoku sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("_________________________");
                    Console.WriteLine();
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(sudoku[i, j] == 0 ? " " : sudoku[i, j].ToString());
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("_________________________");
        }
    }
}
