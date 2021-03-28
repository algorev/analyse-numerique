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
            var solver = new NewtonsMethod(
                problem);
            //solver.EpsilonSolve(0.001, 30, 6);
            solver.IterSolve(10, 6);
        }
    }
}