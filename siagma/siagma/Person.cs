using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace siagma
{
    public class Person
    {
        public string Name { get; set; }

        public string Surname
        {
            get ;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public Person(string name,string surname,int _age)
        {
            Name = name;
            Surname = surname;
            Age = _age;
        }
    }

    public class PersonsCollection<T>: IEnumerable<Person>,IEnumerator<Person>
    {
        private readonly List<Person> lstPerson;
        private int _currentIndex;

        public PersonsCollection(List<Person> items)
        {
            lstPerson = items;
            _currentIndex = -1;
        }


        public Person Current => lstPerson[_currentIndex];

        object IEnumerator.Current => lstPerson[_currentIndex];

        public void Dispose()
        {
            foreach (var item in lstPerson)
            {
                if (item is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        public IEnumerator<Person> GetEnumerator => this;

        
        public bool MoveNext() => ++_currentIndex<lstPerson.Count; 

        public void Reset()
        {
            _currentIndex = -1;
        }
       
        IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
           return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Sort(Func<Person, Person, bool> comparator)
        {
            for (int i = 0; i < lstPerson.Count; i++)
            {
                for (int j = 0; j < lstPerson.Count-1; j++)
                {
                    if (lstPerson[i].Age >= lstPerson[j+1].Age)
                        continue;

                    if (comparator(lstPerson[i], lstPerson[j]))
                    {
                        var temp = lstPerson[i];
                        lstPerson[i] = lstPerson[j];
                        lstPerson[j] = temp;
                    }
                }
            }
        }
    }
}
