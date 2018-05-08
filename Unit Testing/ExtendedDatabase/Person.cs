using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase___People
{
    public class Person
    {
        private string name;
        private long id;

        public Person(string name, long id)
        {
            this.name = name;
            this.id = id;
        }

        public long Id { get => this.id; }
        public string Name { get => this.name; }
    }
}
