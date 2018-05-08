using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
