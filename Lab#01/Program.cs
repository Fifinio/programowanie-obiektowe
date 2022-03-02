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
        class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
    }
}
