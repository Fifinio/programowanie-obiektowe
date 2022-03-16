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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

        }
    }
}
