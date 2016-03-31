using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailRepl
{
    class Program
    {


        static void Main(string[] args)
        {
            var repl = new Repl();
            Console.WriteLine("Welcome to Email REPL");
            Console.WriteLine("---------------------");
            Console.WriteLine("Use the following commands to send emails:");
            Console.WriteLine("subject <subject> - update the message subject");
            Console.WriteLine("body <body> - update the message body");
            Console.WriteLine("to <email>[,<email>]* - update the message recipient list");
            Console.WriteLine("send - send the email using the current subject, body and recipient list");
            Console.WriteLine("");
            Console.WriteLine("Type 'exit' to exit");
            Console.WriteLine("");
            repl.Run();
        }
    }
}
