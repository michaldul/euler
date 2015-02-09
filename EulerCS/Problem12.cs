using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace EulerCS
{
    public class Problem12
    {
        public static void Main()
        {
            var primes = new ESieve(1000).GetPrimes().ToArray();
            Console.WriteLine(FindNumberWithOverNDivisors(TriangularNumbers(), 500, primes));
        }

        public static long FindNumberWithOverNDivisors(IEnumerable<long> numbers, long n, int[] primes)
        {
            var enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var number = enumerator.Current;
                var divisors = NumberOfDivisors(number, primes);
                
                if (divisors > n)
                    return number;
            }
            throw new Exception("Number not found");
        }

        public static long NumberOfDivisors(long n, int[] primes)
        {
            if (n == 1)
                return 1;

            var primeFactors = GetPrimeFactors(n, primes);
            return primeFactors.Values.Select(a => a + 1).Aggregate((a, b) => a * b);
        }

        public static IEnumerable<long> TriangularNumbers()
        {
            for (long i = 2, n = 1; ; n += i, i++)
                yield return n;
        }

        public static IDictionary<long, long> GetPrimeFactors(long n, int[] primes)
        {
            var factors = new Dictionary<long, long>();

            foreach (var prime in primes)
            {
                while (n % prime == 0)
                {
                    factors[prime] = factors.ContainsKey(prime) ? factors[prime] + 1 : 1;
                    n /= prime;
                }
                if (n == 1)
                    break;
            }
            if (n != 1)
                factors[n] = 1;

            return factors;
        }
    }

    [TestFixture]
    public class Problem12Tests
    {
        private int[] primeNumbers;

        [SetUp]
        public void SetUp()
        {
            primeNumbers = new ESieve(100000).GetPrimes().ToArray();
        }

        [Test]
        public void TestFindingNumberWithOverNDivisors()
        {
            var numbers = new List<long> { 1, 3, 6, 10, 15, 21, 28, 36, 45 };
            var n = 5;

            var found = Problem12.FindNumberWithOverNDivisors(numbers, n, primeNumbers);

            Assert.That(found, Is.EqualTo(28));
        }

        [Test]
        [ExpectedException]
        public void MethodShouldThrowExceptionIfNumberWasNotFound()
        {

            var numbers = new List<long> { 1, 3, 6, 10, 15, 21 };
            var n = 5;
            Problem12.FindNumberWithOverNDivisors(numbers, n, primeNumbers);
        }

        [TestCase(1, 1)]
        [TestCase(12, 6)]
        [TestCase(15, 4)]
        [TestCase(75857656771, 16)]
        public void TestFindingNumberOfDivisors(long number, long expected)
        {
            var divisors = Problem12.NumberOfDivisors(number, primeNumbers);
            Assert.That(divisors, Is.EqualTo(expected));
        }

        [Test]
        public void TestFindingPrimeFactors()
        {
            var n = 90;
            var primeFactors = Problem12.GetPrimeFactors(n, primeNumbers);
            Assert.That(primeFactors, 
                Is.EqualTo(new Dictionary<long, long> { { 2, 1 }, { 3, 2 }, { 5, 1 } }));
        }

        [Test]
        public void TestFindingPrimeFactorIsNumberIsPrime()
        {
            var n = 7;
            var primeFactors = Problem12.GetPrimeFactors(n, primeNumbers);
            Assert.That(primeFactors, 
                Is.EqualTo(new Dictionary<long, long> { { 7, 1 } }));
        }

        [Test]
        public void TestFindingPrimeFactorOfOne()
        {
            var n = 1;
            var primeFactors = Problem12.GetPrimeFactors(n, primeNumbers);
            Assert.That(primeFactors, Is.Empty);
        }

        [Test]
        public void TestTriangularNumbersGeneration()
        {
            var triangularNumbers = Problem12.TriangularNumbers();
            var enumerator = triangularNumbers.GetEnumerator();

            enumerator.MoveNext();
            var first = enumerator.Current;
            enumerator.MoveNext();
            var second = enumerator.Current;
            enumerator.MoveNext();
            var third = enumerator.Current;

            Assert.That(first, Is.EqualTo(1));
            Assert.That(second, Is.EqualTo(3));
            Assert.That(third, Is.EqualTo(6));
        }
    }
}
