using System;
namespace analyse_numerique
{
    public interface ISolver
    {
        double IterSolve(int iterations, double start);
        double EpsilonSolve(double epsilon, int maxIter, double start);
    }
}
