using System;
using NUnit.Framework;

namespace EulerCS
{
    public class Problem3
    {
        public static void Main()
        {
            Console.WriteLine(LargestPrimeFactorFast(600851475143));
        }

        public static int LargestPrimeFactor(long n)
        {
            var sieve = new ESieve((int)Math.Sqrt(n));
            var primes = sieve.GetPrimes();
            var largestPrime = 0;

            foreach (var prime in primes)
            {
                if (n % prime == 0)
                    largestPrime = prime;

                while (n % prime == 0)
                    n /= prime;

                if (n == 1)
                    break;
            }

            return largestPrime;
        }

        public static int LargestPrimeFactorFast(long n)
        {
            var largestPrime = 0;
            var limit = n;
            for (var fact = 2; fact * fact <= limit && n != 1; fact++)
            {
                if (n % fact == 0)
                    largestPrime = fact;
                while (n % fact == 0)
                    n /= fact;
            }
            return largestPrime;
        }
    }

    [TestFixture]
    class Problem3Test
    {
        [Test]
        public void TestFindingTheLargesPrimeFactor()
        {
            var largest = Problem3.LargestPrimeFactor(13195);
            Assert.That(largest, Is.EqualTo(29));
        }

        [Test]
        public void TestFastFindingTheLargesPrimeFactor()
        {
            var largest = Problem3.LargestPrimeFactorFast(13195);
            Assert.That(largest, Is.EqualTo(29));
        }
    }
}
