using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IOutputWriter
    {
        void WriteLine(string line);
        void WriteLine(string format, params string[] args);
    }
}
