using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort
{
    public class Bubble
    {
        private int[] arr;
      
        private bool isSwapped;

        public Bubble()
        {

        }
        public Bubble(int[] arr) : this()
        {
            this.Arr = arr;
            isSwapped = false;

        }

        private int[] Arr
        {
            get { return arr; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException();
                }
                arr = value;
            }
        }

        public void Sort()
        {
            if (this.Arr.Length == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }
            do
            {
                isSwapped = false;
                for (int i = 0; i < Arr.Length - 1; i++)
                {
                    if (Arr[i] > Arr[i + 1])
                    {
                        int current = Arr[i];
                        Arr[i] = Arr[i + 1];
                        Arr[i + 1] = current;
                        isSwapped = true;

                    }
                }
            } while (isSwapped);

        }
    }
}