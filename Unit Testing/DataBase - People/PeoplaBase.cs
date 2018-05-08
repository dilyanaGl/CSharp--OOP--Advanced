using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase___People;

namespace DataBasePeople
{
    public class PeopleBase
    {
       
            private Person[] values;
            private int index;
            private const int capacity = 16;

            private PeopleBase()
            {
                this.values = new Person[capacity];
                this.index = 0;
            }

            public int Count { get => this.index; }

            public PeopleBase(params Person[] values) : this()
            {
                this.InitialiseValues(values);
            }

            private void InitialiseValues(Person[] newValues)
            {
                try
                {
                    this.index = newValues.Length;
                    Array.Copy(this.values, newValues, this.index);
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidOperationException("Array Overflow", ex);
                }



            }

            public void Add(Person element)
            {
                if (this.index >= capacity)
                {
                    throw new InvalidOperationException("Overflow capacity");
                }

            if (index > 0 && values.Any(p => p.Name == element.Name))
                {
                    throw new InvalidOperationException("Usernam already exists");
                }

                if (index > 0 && values.Any(p => p.Id == element.Id))
                {
                    throw new InvalidOperationException("Username with this Id already exists");
                }

              

                this.values[index] = element;
                index++;
            }

            public void Remove()
            {
                if (this.index == 0)
                {
                    throw new InvalidOperationException("Array is empty");

                }
                index--;
                this.values[index] = default(Person);
            }

            public Person[] Fetch()
            {
                if (index == 0)
                {
                    throw new InvalidOperationException("Ärray is emty");
                }

                var newArr = new Person[index];

                Array.Copy(this.values, newArr, index);
                return newArr;
            }


        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid Id");
            }

            if (index == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            var person = values.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            return person;
        }

        public Person FindByUsername(string username)
        {
           if (username == null)
            {
                throw new ArgumentException("Invalid username");
            }

            if (index == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            var person = values.FirstOrDefault(p => p.Name == username);
            if (person == null)
            {
                throw new InvalidOperationException("User not found");
            }
            return person;
        }
        

        }
}
