using System;
using System.Collections.Generic;
using System.Text;

namespace Tweet
{
    public interface IWriter
    {
        void Print(string message);
    }
}
