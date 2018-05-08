using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            ListIterator list = new ListIterator();
            while ((command = Console.ReadLine()) != "END")
            {
                var line = command.Split();
                try
                {
                    switch (line[0])
                    {
                        case "Create":
                            list.InitialiseList(line.Skip(1).ToArray());
                            break;
                        case "HasNext":
                            Console.WriteLine(list.HasNext().ToString());
                            break;
                        case "Move":
                            Console.WriteLine(list.Move().ToString());
                            break;
                        case "Print":
                            Console.WriteLine(list.Print());
                            break;

                    }
                }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }


            
        }
    }
}
