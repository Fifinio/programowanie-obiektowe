using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person person = new Person("John", "Doe", 30);
            Console.WriteLine(person);
        }
    }
}
