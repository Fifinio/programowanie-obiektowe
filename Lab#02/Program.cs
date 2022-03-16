using System;

namespace Lab_02
{
    class Program
    {
        //create abstract class messagetype
        abstract class AbstractMessage
        {
            public string Message { get; init; }
            public abstract bool Send(string Message);
        }
        class Email : AbstractMessage
        {
            public Email(string From, string To)
            {
                this.From = From;
                this.To = To;
            }
            string From { get; init; }
            string To { get; init; }
            public override bool Send(string Message)
            {
                Console.WriteLine("Email from " + From + " to " + To + ": " + Message);
                return true;
            }
        }
        //create a class that implements the abstract class Messenger that has properties for the From and To fields
        class Messenger
        {
            public string From { get; init; }
            public string To { get; init; }
            public AbstractMessage Message { get; init; }
            public Messenger(string From, string To, AbstractMessage Message)
            {
                this.From = From;
                this.To = To;
                this.Message = Message;
            }
            public bool Send()
            {
                return Message.Send(Message.Message);
            }
        }
        //create a user class that has a property for the name of the user and the last message sent
        class User
        {
            public User(string Name,AbstractMessage Message)
            {
                this.Name = Name;
                this.LastMessage = Message;
            }
            public string Name { get; init; }
            public AbstractMessage LastMessage { get; init; }
        }

        
        static void Main(string[] args)
        {
            
            User userExample = new User("Karol", new Email("Karol", "Kowalski"));

            Email email = new Email("me", "you");
            email.Send("Hello");
            Console.WriteLine("Hello World!");

        }
    }
}
