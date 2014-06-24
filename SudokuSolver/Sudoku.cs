using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Sudoku
    {
        private readonly int[] grid;

        public Sudoku(string input)
        {
            grid = input.Select(x => (int)Char.GetNumericValue(x)).ToArray();
        }

        public IEnumerable<IEnumerable<int>> Rows
        {
            get { return SudokuSet(Row); }
        }

        public IEnumerable<int> Row(int rowNum)
        {
            for (int i = 0; i < 9; i++)
            {
                yield return this[rowNum, i];
            }
        }

        public IEnumerable<IEnumerable<int>> Columns
        {
            get { return SudokuSet(Column); }
        }

        public IEnumerable<int> Column(int columnNum)
        {
            for (int i = 0; i < 9; i++)
            {
                yield return this[i, columnNum];
            }
        }

        public IEnumerable<IEnumerable<int>> Squares
        {
            get { return SudokuSet(Square); }
        }

        public IEnumerable<int> Square(int squareNum)
        {
            var baseRow = (squareNum / 3) * 3;
            var baseColumn = (squareNum % 3) * 3;
            for (int i = baseRow; i < baseRow + 3; i++)
            {
                for (int j = baseColumn; j < baseColumn + 3; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        public int this[int i]
        {
            get { return grid[i]; }
            set { grid[i] = value; }
        }

        public int this[int row, int column]
        {
            get { return grid[9*row + column]; }
            set { grid[9*row + column] = value; }
        }

        public int FirstBlankIndex()
        {
            return Array.IndexOf(grid, 0);
        }

        private IEnumerable<IEnumerable<int>> SudokuSet(Func<int, IEnumerable<int>> setGenerator)
        {
            for (int i = 0; i < 9; i++)
            {
                yield return setGenerator(i);
            }
        }
    }
}