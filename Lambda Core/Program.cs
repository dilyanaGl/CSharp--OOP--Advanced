using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Core;
using LambdaCore_Skeleton.IO;

namespace LambdaCore_Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(
                 new Manager(),
                 new ConsoleWriter(),
                 new ConsoleReader());

            engine.Run();
        }
    }
}
