using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class Extensions
    {
        public static bool AllAreValidSudokuSets(this IEnumerable<IEnumerable<int>> set)
        {
            return set.All(IsValidSudokuSet);
        }

        public static bool IsValidSudokuSet(IEnumerable<int> set)
        {
            var withoutZeroes = set.Where(x => x != 0).ToList();
            return withoutZeroes.Distinct().Count() == withoutZeroes.Count();
        }
    }
}
