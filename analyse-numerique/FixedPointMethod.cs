using System;
namespace analyse_numerique
{
    public class FixedPointMethod : ISolver
    {
        private readonly Problem problem;

        public FixedPointMethod(Problem problem)
        {
            this.problem = problem;
        }

        public double IterSolve(int iterations, double start)
        {
            double result = start;
            Console.Write("Starting with: ");
            Console.Write(start);
            Console.WriteLine();

            for (int i = 0; i < iterations; i++)
            {
                result = Iterate(result);
                Console.Write(i);
                Console.Write(". ");
                Console.WriteLine(result);
            }
            Console.Write("Final result: ");
            Console.WriteLine(result);
            return result;
        }

        public double EpsilonSolve(double epsilon, int maxIter, double start)
        {
            double currentEstimate = start;
            double previousEstimate = double.PositiveInfinity;
            double delta = double.PositiveInfinity; // Make sure delta is greater than epsilon ;)

            Console.Write("Starting with: ");
            Console.Write(start);
            Console.WriteLine();
            Console.Write("Epsilon = ");
            Console.WriteLine(epsilon);

            for (int i = 0; (delta > epsilon) && (i < maxIter); i++)
            {
                currentEstimate = Iterate(currentEstimate);

                Console.Write(i);
                Console.Write(". ");
                Console.WriteLine(currentEstimate);

                delta = Math.Abs(previousEstimate - currentEstimate);
                previousEstimate = currentEstimate;

                Console.Write("Current delta is: ");
                Console.WriteLine(delta);
            }
            Console.Write("Final result: ");
            Console.WriteLine(currentEstimate);
            return currentEstimate;
        }

        private double Iterate(double attempt)
        {
            return problem.equation(attempt);
        }
    }
}
