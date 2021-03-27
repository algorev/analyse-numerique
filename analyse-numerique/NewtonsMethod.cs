using System;
namespace analyse_numerique
{
    public class NewtonsMethod : ISolver
    {
        private readonly Problem problem;

        public NewtonsMethod(Problem problem)
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
                bounds = Iterate(result);
                Console.Write(i);
                Console.Write(". ");
                Console.WriteLine((bounds.Item1 + bounds.Item2) / 2);
            }
            Console.Write("Final result: ");
            Console.WriteLine((bounds.Item1 + bounds.Item2) / 2);
            return (bounds.Item1 + bounds.Item2) / 2;
        }

        public double EpsilonSolve(double epsilon, int maxIter, double start)
        {
            (double, double) bounds = startingbounds;
            double currentEstimate;
            double previousEstimate = double.PositiveInfinity;
            double delta = double.PositiveInfinity; // Make sure delta is greater than epsilon ;)

            Console.Write("Starting with: ");
            Console.Write(bounds);
            Console.WriteLine();
            Console.Write("Epsilon = ");
            Console.WriteLine(epsilon);

            for (int i = 0; (delta > epsilon) && (i < maxIter); i++)
            {
                bounds = Iterate(bounds);
                currentEstimate = (bounds.Item1 + bounds.Item2) / 2;

                Console.Write(i);
                Console.Write(". ");
                Console.WriteLine(currentEstimate);

                delta = Math.Abs(previousEstimate - currentEstimate);
                previousEstimate = currentEstimate;

                Console.Write("Current delta is: ");
                Console.WriteLine(delta);
            }
            Console.Write("Final result: ");
            Console.WriteLine((bounds.Item1 + bounds.Item2) / 2);
            return (bounds.Item1 + bounds.Item2) / 2;
        }

        private (double, double) Iterate((double, double) bounds)
        {
            double lowerbound = bounds.Item1;
            double upperbound = bounds.Item2;
            double testvalue = (lowerbound + upperbound) / 2;
            if (problem.equation(testvalue) < 0)
            {
                return (testvalue, upperbound);
            }
            else
            {
                return (lowerbound, testvalue);
            }
        }
    }
}
