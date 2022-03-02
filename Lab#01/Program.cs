using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PersonProperties person = new PersonProperties();
            Console.WriteLine(person.firstName);
            
            Vehicle vehicle = Vehicle.Create("Honda", "Civic", 2015,"Red", "123456789");
            Console.WriteLine(vehicle);
        }
    }
    class PersonProperties
    {
        private string FirstName;
        public string firstName
        {
            get { return FirstName; }
            set { 
                if(value.Length >= 2){
                    FirstName = value;
                } 
                }
        }
    }

    class Vehicle {
            public readonly string[] makes = {
            "Abarth",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroën",
            "Dacia",
            "Daewoo",
            "Daihatsu",
            "Dodge",
            "Donkervoort",
            "DS",
            "Ferrari",
            "Fiat",
            "Fisker",
            "Ford",
            "Honda",
            "Hummer",
            "Hyundai",
            "Infiniti",
            "Iveco",
            "Jaguar",
            "Jeep",
            "Kia",
            "KTM",
            "Lada",
            "Lamborghini",
            "Lancia",
            "Land Rover",
            "Landwind",
            "Lexus",
            "Lotus",
            "Maserati",
            "Maybach",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "MG",
            "Mini",
            "Mitsubishi",
            "Morgan",
            "Nissan",
            "Opel",
            "Peugeot",
            "Porsche",
            "Renault",
            "Rolls-Royce",
            "Rover",
            "Saab",
            "Seat",
            "Skoda",
            "Smart",
            "SsangYong",
            "Subaru",
            "Suzuki",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"};
        private string _Make;
        private string _Model;
        private int _Year;
        private string _Color;
        private string _LicensePlate;

        public override string ToString()
        {
            return "Make: " + _Make + "\nModel: " + _Model + "\nYear: " + _Year + "\nColor: " + _Color + "\nLicense Plate: " + _LicensePlate;
        }
        private Vehicle(string make, string model, int year, string color, string licensePlate) {
            _Make = make;
            _Model = model;
            _Year = year;
            _Color = color;
            _LicensePlate = licensePlate;
        }


        public static Vehicle Create(string make, string model, int year, string color, string licensePlate) {
            Vehicle x = new Vehicle("Honda", "Civic", 2020, "black","testing123");
            if( Array.IndexOf(x.makes, make) >= 0){
                if(model.Length >= 2){
                    if(year >= 1900 && year <= 2020){
                        if(color.Length >= 2){
                            if(licensePlate.Length >= 2){
                                return new Vehicle(make, model, year, color, licensePlate);
                            }
                            else{
                                throw new Exception("License plate must be at least 2 characters long");
                            }
                        }
                        else{
                            throw new Exception("Color must be at least 2 characters long");
                        }
                    }
                    else{
                        throw new Exception("Year must be between 1900 and 2020");
                    }
                }
                else{
                    throw new Exception("Model must be at least 2 characters long");
                }
            }
            else{
                throw new Exception("Make is not valid");       
            } 
        }
    }
}
