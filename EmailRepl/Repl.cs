using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailRepl
{
    public class ParsedCommand
    {
        public ParsedCommand(string name, string[] parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        public string Name { get; }
        public string[] Parameters { get; }
    }

    public class Repl
    {
        private static readonly ICommand[] Commands = new ICommand[]
        {
            new BodyCommand(), new SubjectCommand(), new ToCommand(), new SendCommand()
        };

        private readonly State state = new State();

        public void Run()
        {
            while (true)
            {
                var input = ReadLine();
                var parsedCommand = ParseCommand(input);
                if (parsedCommand.Name == "exit")
                {
                    Console.WriteLine("Exiting");
                    break;
                }
                ICommand command = FindCommand(parsedCommand);
                var output = command.Execute(parsedCommand.Parameters, state);
                Console.WriteLine("Command output: " + output);
            }
        }

        private ICommand FindCommand(ParsedCommand parsedCommand)
        {
            return Commands.Single(c => c.Name == parsedCommand.Name);
        }

 

        public void SplitIt()
        {
            var split = "hello world number one".Split(',', ' ');
        }

        private ParsedCommand ParseCommand(string input)
        {
            var parts = input.Split(new [] {' '}, 2);
            var name = parts[0];
            var parameters = (parts.Length > 1)? parts[1].Split(',') : new string[] {};
            return new ParsedCommand(name, parameters);
        }

        private string ReadLine()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
