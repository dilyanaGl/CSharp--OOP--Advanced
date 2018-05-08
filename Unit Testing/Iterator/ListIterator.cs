using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterator
{
    public class ListIterator
    {
        private List<string> list;
        private int currentIndex;

        public ListIterator()
        {
            this.list = new List<string>();
            this.currentIndex = 0;
        }

        public ListIterator(string[] strings) : this()
        {
            InitialiseList(strings);
        }

        public void InitialiseList(string[] strings)
        {
            if (strings.Length == 0)
            {
                throw new ArgumentException("Invalid parameter");
            }

            list.AddRange(strings.ToList());

        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
            }

            return HasNext();
        }

        public bool HasNext()
        {
            if (this.currentIndex == list.Count)
            {
                return false;
            }

            return true;
        }

        public string Print()
        {
            if (list.Count == 0 || currentIndex < 0 || currentIndex >= list.Count)
            {
                throw new InvalidOperationException("Invalid operation");
            }
            return list[currentIndex];
        }
    }
}



