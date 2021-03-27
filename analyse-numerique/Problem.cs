using System;
namespace analyse_numerique
{
    public class Problem
    {
        public Func<double, double> equation;
        public Func<double, double> derivative;

        public Problem(Func<double, double> equat, Func<double, double> deriv)
        {
            equation = equat;
            derivative = deriv;
        }
    }
}
