using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmailRepl
{
    public interface ICommand
    {
        string Name { get; }
        string Execute(string[] parameters, State state);
    }
}
