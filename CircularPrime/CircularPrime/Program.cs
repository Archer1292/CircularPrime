using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            Console.WriteLine("Find all prime numbers up to " + n + ", which at Bitwise shift gives primes");         
            CircularPrime cp=new CircularPrime();
            try {
                Console.WriteLine(cp.GetNumberOfCircularPrime(n)); 
            }
            catch {
                Console.WriteLine("Entered incorrect data");
            }
            Console.ReadKey();
        }
        
    }
}
