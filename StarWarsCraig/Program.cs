using StarWarsCraig.ValidationPattern;
using System;

namespace StarWarsCraig
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            ISolution solution = new Solution();

            try
            {
                var result = solution.GetSolution(array);
                Console.WriteLine("El resultado es {0}.", result);
            }
            catch (ValidableException vex)
            {
                Console.WriteLine(vex);
                throw;
            }

            Console.ReadLine();
        }
    }
}
