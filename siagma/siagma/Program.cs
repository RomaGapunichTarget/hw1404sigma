using System;
using System.Collections.Generic;

namespace siagma
{
    class Program
    {
        static void Main()
        {
            WorkHasSetCollection(); // It's HashSetCoolectionWork
           

            Console.ReadKey();

        }

        #region HashCollection
        private static void WorkHasSetCollection()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    // Populate numbers with just even numbers.
                    evenNumbers.Add(i);
                }
                else
                {
                    // Populate oddNumbers with just odd numbers.
                    oddNumbers.Add((i));
                }

            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            Remove(evenNumbers);
            Remove(oddNumbers);

            Console.Write("evenNumbers contains {0} elements after divide: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements after divide: ", oddNumbers.Count);
            DisplaySet(oddNumbers);
        }

        private static void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

        private static void Remove(HashSet<int> set)
        {
            foreach (int i in set)
            {
                if (i/5>0)
                {
                    set.RemoveWhere(i1 => i1/5>0);
                    break;
                }
                
            }
        }
        #endregion
    }
}
