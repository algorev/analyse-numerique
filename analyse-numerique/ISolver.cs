using System;
namespace analyse_numerique
{
    public interface ISolver
    {
        public double IterSolve(int iterations, double start);
        public double EpsilonSolve(double epsilon, int maxIter, double start);
    }
}
