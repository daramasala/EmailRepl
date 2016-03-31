using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailRepl
{
    public class SubjectCommand : ICommand
    {
        public string Name => "subject";

        public string Execute(string[] parameters, State state)
        {
            var subject = parameters[0];
            state.Subject = subject;
            return $"Subject updated to '{subject}'";
        }
    }

    public class BodyCommand : ICommand
    {
        public string Name => "body";

        public string Execute(string[] parameters, State state)
        {
            var body = parameters[0];
            state.Body = body;
            var bodyForInfo = body;
            if (body.Length > 10)
            {
                bodyForInfo = body.Substring(0, 10) + "...";
            }
            return $"Body updated to '{bodyForInfo}'";
        }
    }

    public class ToCommand : ICommand
    {
        public string Name => "to";
        public string Execute(string[] parameters, State state)
        {
            var emails = parameters;
            state.Emails = emails;
            if (emails.Length == 1)
            {
                return $"To updated to {emails[0]}";
            }
            return $"To updated with {emails.Length} emails";
        }
    }

    public class SendCommand : ICommand
    {
        public string Name => "send";

        private readonly EmailClient emailClient;

        public SendCommand()
        {
            emailClient = new EmailClient("oop.with.csharp@gmail.com", "learn oop");
        }

        public string Execute(string[] parameters, State state)
        {
            foreach (var email in state.Emails)
            {
                emailClient.Send(email, state.Subject, state.Body);
            }
            return $"Sent '{state.Subject}' to {state.Emails.Length} recipients";
        }
    }
}
