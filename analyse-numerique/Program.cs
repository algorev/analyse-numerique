using System;

namespace analyse_numerique
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem(
                (x) => x*x - 2,
                (x) => 2*x);

            Console.WriteLine("\nTesting out BisectionMethod:");
            ISolver solver = new BisectionMethod(
                problem,
                0,
                5);
            solver.EpsilonSolve(0.001, 30, 0);
            solver.IterSolve(10, 0);

            Console.WriteLine("\nTesting out NewtonsMethod:");
            solver = new NewtonsMethod(
                problem);
            solver.EpsilonSolve(0.001, 30, 6);
            solver.IterSolve(10, 6);

            Console.WriteLine("\nTesting out FixedPointMethod:");
            solver = new FixedPointMethod(
                problem);
            solver.EpsilonSolve(0.001, 30, 0.1);
            solver.IterSolve(10, 0.1);
        }
    }
}