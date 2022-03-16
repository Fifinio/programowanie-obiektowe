using System;

namespace Lab_02_Homework
{
    class Program
    {
        //Ćwiczenie 1

        public abstract class Vehicle
        {
            public abstract void Drive();

            public virtual void Stop()
            {
                Console.WriteLine("The vehicle has stopped.");
            }
        }

        public class Scooter: Vehicle{

            public override void Drive()
            {
                Console.WriteLine("The scooter has started driving.");
            }
            public override void Stop()
            {
                Console.WriteLine("The scooter has stopped.");
            }
        }
        public class ElectricScooter: Scooter{
            
            public ElectricScooter(){
                ChargeBattery();
                MaxRange = 40*BatteryCapacity;
                Range = MaxRange;
            }
            public double BatteryCapacity { get; set; }
            public double MaxRange { get; set; }
            public double Range{ get;set; }
            public void ChargeBattery()
            {
                Console.WriteLine("The battery is charging.");
                BatteryCapacity = 1;
            }
            public override void Drive()
            {
                if(BatteryCapacity > 0)
                {
                    Console.WriteLine("The electric scooter is driving.");
                    BatteryCapacity -= 0.1;
                    Range -= 4;
                }
                else
                {
                    Console.WriteLine("The electric scooter is out of battery.");
                }
            }
            public void displayInfo(){
                Console.WriteLine("Range: "+ string.Format("{0:0.0}",  Range) + " km");
                Console.WriteLine("Battery: "+ string.Format("{0:0.0}",  BatteryCapacity*100) + " %");
            }
            public override void Stop()
            {
                base.Stop();
            }
        }
        public class KickScooter: Scooter{
            public override void Drive()
            {
                Console.WriteLine("The kick scooter has started driving.");
            }
            public override void Stop()
            {
                base.Stop();
            }
        }
        //define a class Duck that implements interface Flyable and Swimable and a class Wasp that implements interface Flyable.
        public interface Flyable{
            void Fly();
        }
        public interface Swimable{
            void Swim();
        }
        public class Duck: Flyable, Swimable{
            public void Fly(){
                Console.WriteLine("The duck is flying.");
            }
            public void Swim(){
                Console.WriteLine("The duck is swimming.");
            }
        }
        public class Wasp: Flyable{
            public void Fly(){
                Console.WriteLine("The wasp is flying.");
            }
        }
        public class Hydroplane: Flyable, Swimable{
            public void Fly(){
                Console.WriteLine("The hydroplane is flying.");
            }
            public void Swim(){
                Console.WriteLine("The hydroplane is swimming.");
            }
        }
        
        static void Main(string[] args)
        {
            //Ćwiczenie 1
            Console.WriteLine("Ćwiczenie 1");
            ElectricScooter electricScooter = new ElectricScooter();
            electricScooter.displayInfo();
            for(int i = 0; i < 10; i++)
            {
                electricScooter.Drive();
                electricScooter.displayInfo();
            }
            electricScooter.Stop();

            KickScooter kickScooter = new KickScooter();
            kickScooter.Drive();
            kickScooter.Stop();
            
            //Ćwiczenie 2
            Console.WriteLine("\nĆwiczenie 2");

            Flyable[] flyables = new Flyable[3];
            flyables[0] = new Duck();
            flyables[1] = new Wasp();
            flyables[2] = new Hydroplane();
            int Multipurpouse = 0;
            foreach(Flyable flyable in flyables)
            {
                if(flyable is Flyable && flyable is Swimable )
                {
                    Multipurpouse++;
                }
            }
            Console.WriteLine("Classes that implement Swimmable and flyable: "+ Multipurpouse);
        }
    }
}
