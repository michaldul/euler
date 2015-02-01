using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EulerCS
{
    public class ESieve
    {
        private readonly int _size;
        private bool[] _sieve;

        public ESieve(int size)
        {
            _size = size;
            _sieve = Enumerable.Repeat(true, size + 1).ToArray();
            _sieve[0] = false;
            _sieve[1] = false;
            for (var number = 2; number * number < size; number++)
            {
                if(!_sieve[number])
                    continue;

                for (var i = 2 * number; i <= size; i += number)
                    _sieve[i] = false;
            }
        }

        public bool IsPrime(int n)
        {
            if(n > _size)
                throw new ArgumentOutOfRangeException();

            return _sieve[n];
        }

        public IEnumerable<int> GetPrimes()
        {
            return _sieve.Select((isPrime, n) => isPrime ? n : 0).Where(n => n != 0);
        }
    }

    [TestFixture]
    public class ESieveTest
    {
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(21, false)]
        [TestCase(29, true)]
        [TestCase(30, false)]
        public void PrimesTests(int number, bool expeced)
        {
            var sieve = new ESieve(30);
            
            var isPrime = sieve.IsPrime(number);

            Assert.That(isPrime, Is.EqualTo(expeced));
        }

        [Test]
        public void SieveGeneratesPrimesSequence()
        {
            var sieve = new ESieve(11);
            var sequence = sieve.GetPrimes();

            Assert.That(sequence.ToArray(), Is.EqualTo(new[] {2, 3, 5, 7, 11}));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SieveThrowsExceptionIfArgumentIsOutOfRange()
        {
            var sieve = new ESieve(5);
            sieve.IsPrime(6);
        }
    }
}
