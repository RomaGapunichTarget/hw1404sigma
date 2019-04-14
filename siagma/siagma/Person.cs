using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace siagma
{
    public class Persons
    {
        public string Name { get; set; }

        public string Surname
        {
            get ;
            set;
        }

        public Persons(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    public class PeopleWorked : IEnumerable<Persons>,IEnumerator<Persons>
    {
        public Persons Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Persons> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
