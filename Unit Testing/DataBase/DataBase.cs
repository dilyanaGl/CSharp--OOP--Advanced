using System;

namespace DataBase
{
    public class DataBase
    {
        private int[] values;
        private int index;
        private const int capacity = 16;

        private DataBase()
        {
            this.values = new int[capacity];
            this.index = 0;
        }

        public int Count { get => this.index; }

        public DataBase(params int[] values) : this()
        {
            this.InitialiseValues(values);
        }

        private void InitialiseValues(int[] newValues)
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

        public void Add(int element)
        {
            if (this.index >= capacity)
            {
                throw new InvalidOperationException("Overflow capacity");
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
            this.values[index] = default(int);
        }

        public int[] Fetch()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Ärray is emty");
            }

            var newArr = new int[index];

            Array.Copy(this.values, newArr, index);
            return newArr;
        }


    }
}

