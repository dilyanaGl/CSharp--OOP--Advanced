using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hell.Commands;
using Hell.Interfaces;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private HeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, HeroManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.parseInput(inputLine);
            this.writer.WriteLine(this.processInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string processInput(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        string commandName = command + "Command";

        Type commandType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(p => p.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

        var constructor = commandType.GetConstructor(new[] { typeof(HeroManager), typeof(List<string>) });
        AbstractCommand cmd = (AbstractCommand)constructor.Invoke(new object[] { this.heroManager, arguments });
        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}