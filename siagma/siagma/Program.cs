using System;
using System.Collections.Generic;
using System.Linq;

namespace siagma
{
    class Program
    {
        private static List<Person> lstPers;
        public delegate void MyAction<in T>(T obj);
        static void Main()
        {
            WorkHasSetCollection(); // It's HashSetCoolectionWork
            lstPers = new List<Person>();
            lstPers.Add(new Person("Roma1", "Roma1", 1));
            lstPers.Add(new Person("Roma2", "Roma2", 2));
            lstPers.Add(new Person("Roma3", "Roma3", 3));
            lstPers.Add(new Person("Roma4", "Roma4", 4));
            PersonsCollection<Person> collection = new PersonsCollection<Person>(lstPers);
            foreach (var element in collection)
            {
                Console.WriteLine(element.Name + " " + element.Surname);
            }
            Console.WriteLine("Сортировка пузырьком от менбьшего к большему");
            SortBuble();
            Console.WriteLine("Список после добавления");
            ShowAdd();
            Console.WriteLine("Список после удаления");
            DeletePerson();

            var lst = new List<int>{1,2,31,312,434,23,4235,43,53,45345346,234};

            var aggregate = lst.Where(i => i > 20).OrderBy(i => i).Select(i => i.ToString())
                .Aggregate((preview, cureent) => preview.ToString() + "," + cureent).Split(",").ToArray()
                .Select(s => s).ToList();
            foreach (var lol in aggregate)
            {
                Console.WriteLine(lol);
            }
            Console.ReadKey();
            
        }
        private static void ShowAdd()
        {
            var collec1 = new PersonsCollection<Person>(lstPers);
            collec1.Added(new Person("test", "test", 2));
            collec1.Reset();
            foreach (var element in collec1)
            {
                Console.WriteLine(element.Name + " " + element.Surname + " " + element.Age);
            }
        }

        private static void DeletePerson()
        {
            var collec = new PersonsCollection<Person>(lstPers);
            var pers = collec.FirstOrDefault(person => person.Age <= 10);
            if (pers!=null)
            {
                collec.Removed(pers);
            }
            collec.Reset();
            foreach (var element in collec)
            {
                Console.WriteLine(element.Name + " " + element.Surname + " " + element.Age);
            }
        }

        private static void SortBuble()
        {
            List<Person> lstPers = new List<Person>();
            lstPers.Add(new Person("Roma", "Gapunich", 26));
            lstPers.Add(new Person("Dyma", "Hulyi", 21));
            lstPers.Add(new Person("Bogdan", "Magda", 32));
            lstPers.Add(new Person("Vitaliy", "VitaliySyrname", 4112));
            lstPers.Add(new Person("Rosadsdma", "Gasdasdapunich", 226));
            lstPers.Add(new Person("Dyma", "Hasdasdulyi", 221));
            lstPers.Add(new Person("Basdasdogdan", "Maasdasdgda", 324));
            lstPers.Add(new Person("Vitasdasdaliy", "VitaliySyrname", 12123));
            var test = new PersonsCollection<Person>(lstPers);

            test.Sort((v1, v2) => v1.Age < v2.Age);

            foreach (var value in test)
            {
                Console.WriteLine(value.Name + " " + value.Surname + " " + value.Age);
            }
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

            Console.Write("hgascOList {0} elements : ", oddNumbers.GetHashCode());
            foreach (var hasoCode in oddNumbers)
            {
                Console.Write("getHashCode {0}: ", GetHashCode(hasoCode));
            }
            

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

        public static int GetHashCode(int n)
        {
            return n.GetHashCode();
        }
        #endregion
    }
}
