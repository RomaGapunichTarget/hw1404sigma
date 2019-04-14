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
        int position = -1;

        public PersonsCollection(List<Person> lstPerson)
        {
            lstPerson = new List<Person>();

            foreach (var pArray in lstPerson)
            {
                lstPerson.Add(pArray);
            }
        }


        public Person Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            position++;
            return position < lstPerson.Count;
        }

        public void Reset()
        {
            position=-1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonsCollection(lstPerson);
        }
    }
}
