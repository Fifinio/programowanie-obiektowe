public class Program
{
    record Car(string Model, int Power);
    public static void Main(string[] args)
    {
        List<Car> cars = new List<Car>()
        {
            new Car("Fiat 500", 90),
            new Car("Ford Kuga", 100),
            new Car("Toyota Yaris", 90),
            new Car("Audi A4", 200)
        };
        Car car = cars.Skip(3).ElementAt(1);
        Console.WriteLine(car);
    }
}