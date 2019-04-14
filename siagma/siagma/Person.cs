using System;
using System.Collections;
using System.Collections.Generic;
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

        public Person(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    public class PersonsCollection: IEnumerable<Person>,IEnumerator<Person>
    {
        private List<Person> lstPerson;
        private int index = 0;

        public PersonsCollection(List<Person> _lstPerson)
        {
            lstPerson = new List<Person>();

            foreach (var pArray in _lstPerson)
            {
                lstPerson.Add(pArray);
            }
        }


        public Person Current => lstPerson[index-1];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public IEnumerator<Person> GetEnumerator
        {
            get {
                yield return Current;
            }
        }

        public bool MoveNext()
        {
            
            if (index <= lstPerson.Count - 1)
            {
                index++;
                return true;
            }
            else
                return false;

        }

        public void Reset()
        {
            index = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonsCollection(lstPerson);
        }

        IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
           return this;
        }
    }
}
