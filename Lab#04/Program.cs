using System.Diagnostics.Tracing;
using System.Drawing;

class App
{
    public static void Main(string[] args)
    {   
        System.Console.WriteLine(Exercise1.NextPoint(Direction4.UP,(0, 0), (3,3)));
        int[,] screen =
        {
            {1, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };
        (int, int) point = (1, 1);
        Direction8 direction = Exercise2.DirectionTo(screen, point, 1);
        System.Console.WriteLine(direction);
        Car[] cars = new Car[]
        {
            new Car(),
            new Car(Model: "Fiat", true),
            new Car(),
            new Car(Power: 100),
            new Car(Model: "Fiat", true),
            new Car(Power: 125),
            new Car()
        };
        System.Console.WriteLine(cars[0].Model);
        System.Console.WriteLine(Exercise3.CarCounter(cars));
    }
}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction dir = Direction.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {
        int x = point.Item1;
        int y = point.Item2;
        int width = screenSize.Item1;
        int height = screenSize.Item2;
        switch (direction)
        {
            default:
            return point;
            case Direction4.UP:
                y+=1;
                return (x, y);
            case Direction4.DOWN:
                y-=1;
                return (x, y);
            case Direction4.LEFT:
                x-=1;
                return (x, y);
            case Direction4.RIGHT:
                x+=1;
                return (x, y);
        }
    }
}
//Cwiczenie 2
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT
class Exercise2
{
    static int[,] screen =
    {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private static (int, int) point = (1, 1);
    
    private Direction8 direction = DirectionTo(screen, point, 1);
    
    public static Direction8 DirectionTo(int[,] screen, (int, int) point,  int value)
    {
        int x = point.Item1;
        int y = point.Item2;
        int width = screen.GetLength(0);
        int height = screen.GetLength(1);
        if (x == 0 && y == 0)
        {
            return Direction8.DOWN_RIGHT;
        }
        if (x == 0 && y == height - 1)
        {
            return Direction8.UP_RIGHT;
        }
        if (x == width - 1 && y == 0)
        {
            return Direction8.DOWN_LEFT;
        }
        if (x == width - 1 && y == height - 1)
        {
            return Direction8.UP_LEFT;
        }
        if (x == 0)
        {
            return Direction8.DOWN;
        }
        if (x == width - 1)
        {
            return Direction8.UP;
        }
        if (y == 0)
        {
            return Direction8.RIGHT;
        }
        if (y == height - 1)
        {
            return Direction8.LEFT;
        }
        if (screen[x, y] == value)
        {
            return Direction8.UP_LEFT;
        }
        if (screen[x, y + 1] == value)
        {
            return Direction8.DOWN_LEFT;
        }
        if (screen[x + 1, y] == value)
        {
            return Direction8.UP_RIGHT;
        }
        if (screen[x + 1, y + 1] == value)
        {
            return Direction8.DOWN_RIGHT;
        }
        return Direction8.UP_LEFT;
    }

}
//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        var carCounter = new Dictionary<string, int>();
        foreach (var car in cars)
        {
            if (car.Model != null && carCounter.ContainsKey(car.Model) )
            {
                carCounter[car.Model]++;
            }
            else if (car.Model != null)
            {
                carCounter.Add(car.Model, 1);
            }
        }
        return carCounter.Values.Max();
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {
        
    }
}