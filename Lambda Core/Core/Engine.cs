using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.Core
{
    public class Engine
    {
        private Manager manager;
        private IWriter writer;
        private IReader reader;

        public Engine(Manager manager, IWriter writer, IReader reader)
        {
            this.manager = manager;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string input;
            while ((input = reader.Read()) != "System Shutdown!")
            {
                var line = input.Split(new[] {"@"}, StringSplitOptions.RemoveEmptyEntries);
                string command = line[0].Trim().TrimEnd(':');
                string[] args = line.Skip(1).ToArray();

                var method = manager
                    .GetType()
                    .GetMethods()
                   .FirstOrDefault(p => p.Name == command);
                var commandParams = method.GetParameters();
                var parameters = new object[commandParams.Length];
                for (int i = 0; i < commandParams.Length; i++)
                {
                    var type = commandParams[i].ParameterType;
                    parameters[i] = Convert.ChangeType(args[i], type);
                }

                writer.Print(method.Invoke(manager, parameters).ToString());
            }
        }
    }
}
