using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
   public class ConsoleWriter : IWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
