using System;
using System.Linq;
using NUnit.Framework;

namespace EulerCS
{
    public class Problem108
    {
        public static long CountDistinctSolutions(int n, int[] primes)
        {
            var primeFactors = Problem12.GetPrimeFactors(n, primes);

            if (!primeFactors.Any())
                return 0;

            if (primeFactors.Count == 1)
                return primeFactors.Values.First() + 1;

            var result = primeFactors.Values
                .Select(v => 2 * v) // v => 2*v as we calculate result for n^2
                .Aggregate((v1, v2) => (v1 + 1) * (v2 + 1));

            result = result / 2 + 1;
            return result;
        }

        public static void Main()
        {
            var n = 1;
            var primes = new ESieve(10000).GetPrimes().ToArray();

            while (CountDistinctSolutions(n, primes) <= 1000)
                n++;

            Console.WriteLine(n);
        }
    }

    [TestFixture]
    public class Tests108
    {
        int[] primes = new ESieve(1000).GetPrimes().ToArray();

        [TestCase(4, 3)]
        [TestCase(12, 8)]
        [TestCase(1, 0)]
        public void TestFindingNumberOfDistinctSolutions(int n, long solutions)
        {
            Assert.That(Problem108.CountDistinctSolutions(n, primes), Is.EqualTo(solutions));
        }
    }
}
