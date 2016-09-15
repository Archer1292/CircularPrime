using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class CircularPrime
    {
        public CircularPrime()
        {
            Prime = new List<int>();
        }

        private int MaximumLimit;
        private List<int> Prime;
        private int NumberOfCircularPrime;
        
        public void SetMaximumLimit(int limit){
            if (limit > 0) MaximumLimit = limit;
            else
            {
                Console.WriteLine("Entered incorrect data");
                MaximumLimit = -1;
            }
        }

        /// <summary>
        /// находит простые число до n Решетом Эратосфена
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        void GetPrime()
        {
            try
            {
                int[] a = Enumerable.Range(1, MaximumLimit).ToArray();//a[0]=1, 1 - не простое число -> формирование списка простых начинается с a[1]                
                for (int i = 1; i < MaximumLimit; i++)
                {
                    int temp = 0;
                    if (a[i] != 0)
                    {
                        temp = a[i];
                        Prime.Add(a[i]);
                        for (int j = i; j < MaximumLimit; )
                        {

                            a[j] = 0;
                            j += temp;
                        }

                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Верхняя граница должна быть натуральной( целое число, больше 0).");
                Prime = null;
            }
            
            
        }

        /// <summary>
        /// проверяет являются ли все цикличные сдвиги числа простыми
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        bool IsCircular(int x)
        {
            int digitCount = (int)Math.Log10(x) + 1;
            for (int i = 1; i < digitCount; i++)
            {
                x = x / 10 + x % 10 * digitCount;// сдвиг на 1 вправо
                if (!Prime.Contains(x)) return false;
            }
            return true;
        }

        /// <summary>
        /// возвращает количество CircularPrime (перебирает список простых чисел до граници, если число CircularPrime счетчик++)
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int GetNumberOfCircularPrime(int limit)
        {
            SetMaximumLimit(limit);
            GetPrime();
            if (Prime != null)
            {
                NumberOfCircularPrime = 0;
                foreach (int n in Prime)
                {
                    if (IsCircular(n))
                        NumberOfCircularPrime++;
                }
                return NumberOfCircularPrime;
            }
            return -1;
        }
         
    }
}
