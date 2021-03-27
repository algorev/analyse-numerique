using System;

namespace analyse_numerique
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem(
                (x) => x,
                (_) => 1);
            var solver = new BisectionMethod(
                problem,
                -10,
                5);
            solver.EpsilonSolve(0.001, 30, 0);
        }
    }
}