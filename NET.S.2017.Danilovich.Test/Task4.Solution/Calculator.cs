using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    class Calculator
    {
        public double CalculateAvarage(List<double> values, ICalculator calculator) => calculator.CalculateAverage(values);
    }
    public class MeanCalculator : ICalculator
    {
        public double CalculateAverage(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"{(nameof(values))} musnt be a null");
            }

            return values.Sum() / values.Count;
        }
    }
    public class MedianCalculator : ICalculator
    {
        public double CalculateAverage(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

                    int n = sortedValues.Count;

                    if (n % 2 == 1)
                    {
                        return sortedValues[(n - 1) / 2];
                    }

                    return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }
    }
}
