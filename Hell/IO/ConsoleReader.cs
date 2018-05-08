using System;
using Hell.Interfaces;

public class ConsoleReader : IInputReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}