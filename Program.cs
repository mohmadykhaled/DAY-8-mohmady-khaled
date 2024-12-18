

#region problem1
using System;

interface IVehicle
{
    void StartEngine();
    void StopEngine();
}

class Car : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Car engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Car engine stopped.");
    }
}

class Bike : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Bike engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Bike engine stopped.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVehicle car = new Car();
        IVehicle bike = new Bike();

        Console.WriteLine("Car Operations:");
        car.StartEngine();
        car.StopEngine();

        Console.WriteLine(); 

        Console.WriteLine("Bike Operations:");
        bike.StartEngine();
        bike.StopEngine();
    }
}
/* Interfaces allow your code to work with multiple implementations
 * without needing to modify the existing code*/
#endregion








   #region problem2
  using System;


abstract class Shape
{
    public abstract double GetArea(); 

    public void Display()
    {
        Console.WriteLine("This is a shape.");
    }
}

class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

interface IShape
{
    double GetArea();
    void Display();
}

class RectangleInterface : IShape
{
    private double length;
    private double width;

    public RectangleInterface(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public double GetArea()
    {
        return length * width;
    }

    public void Display()
    {
        Console.WriteLine("This is a rectangle.");
    }
}

class CircleInterface : IShape
{
    private double radius;

    public CircleInterface(double radius)
    {
        this.radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public void Display()
    {
        Console.WriteLine("This is a circle.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Using abstract class
        Shape rectangle = new Rectangle(5, 10);
        Shape circle = new Circle(7);

        Console.WriteLine("Abstract Class Approach:");
        rectangle.Display();
        Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");

        circle.Display();
        Console.WriteLine($"Circle Area: {circle.GetArea()}");

        Console.WriteLine(); 

        IShape rectangleInterface = new RectangleInterface(5, 10);
        IShape circleInterface = new CircleInterface(7);

        Console.WriteLine("Interface-Based Approach:");
        rectangleInterface.Display();
        Console.WriteLine($"Rectangle Area: {rectangleInterface.GetArea()}");

        circleInterface.Display();
        Console.WriteLine($"Circle Area: {circleInterface.GetArea()}");
    }
}
/* when you want to provide common functionality to all derived classes.*/
#endregion

#region problem3
 
using System;

class Product : IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {

        Product[] products = new Product[]
        {
            new Product(1, "Laptop", 1500.00),
            new Product(2, "Smartphone", 800.00),
            new Product(3, "Tablet", 400.00),
            new Product(4, "Monitor", 300.00)
        };

        Console.WriteLine("Products before sorting:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Array.Sort(products);

        Console.WriteLine("\nProducts after sorting by price:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
/*  define a default comparison logic  
   that works seamlessly with built-in sorting mechanisms like By embedding the comparison logic in the class
  you make the sorting criteria explicit and self-contained
   improving code clarity and maintainability*/

#endregion


#region problem4
using System;


class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Grade Grade { get; set; }


    public Student(int id, string name, Grade grade)
    {
        Id = id;
        Name = name;
        Grade = grade;
    }


    public Student(Student other)
    {
        Id = other.Id;
        Name = other.Name;
        Grade = new Grade(other.Grade.Score);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Grade: {Grade.Score}";
    }
}

class Grade
{
    public int Score { get; set; }

    public Grade(int score)
    {
        Score = score;
    }
}

class Program
{
    static void Main(string[] args)
    {

        Student original = new Student(1, "Alice", new Grade(85));


        Student shallowCopy = original;

        Student deepCopy = new Student(original);

        Console.WriteLine("Before modification:");
        Console.WriteLine("Original: " + original);
        Console.WriteLine("Shallow Copy: " + shallowCopy);
        Console.WriteLine("Deep Copy: " + deepCopy);


        original.Grade.Score = 95;

        Console.WriteLine("\nAfter modification:");
        Console.WriteLine("Original: " + original);
        Console.WriteLine("Shallow Copy: " + shallowCopy);
        Console.WriteLine("Deep Copy: " + deepCopy);
    }
}
/*  copy constructor is used to create a new object with the same values as an existing 
  object ensuring independent copies of reference-type fields*/
#endregion

#region problem5
using System;

interface IWalkable
{
    void Walk();
}

class Robot : IWalkable
{
  
    public void Walk()
    {
        Console.WriteLine("Robot is walking using its default method");
    }

    void IWalkable.Walk()
    {
        Console.WriteLine("Robot is walking as defined by the IWalkable interface");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robot robot = new Robot();

        robot.Walk();

        IWalkable walkableRobot = robot;
        walkableRobot.Walk();
    }
}
/* class has its own method with the same name as an interface method
  explicit interface implementation ensures that the interface method is only accessible via an interface reference
If a class implements multiple interfaces with methods of the same name 
explicit implementation allows each interface method to have its own definition without conflicts.*/
#endregion

#region problem6
using System;


struct Account
{
    private int accountId;
    private string accountHolder;
    private double balance;

    public int AccountId
    {
        get { return accountId; }
        set { accountId = value; }
    }

    public string AccountHolder
    {
        get { return accountHolder; }
        set { accountHolder = value; }
    }

    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public Account(int accountId, string accountHolder, double balance)
    {
        this.accountId = accountId;
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    public override string ToString()
    {
        return $"AccountId: {AccountId}, AccountHolder: {AccountHolder}, Balance: {Balance:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
    
        Account account = new Account(101, "mohmady", 15000);

 
        Console.WriteLine("Initial Account Details:");
        Console.WriteLine(account);

        
        account.Balance += 500; 
        Console.WriteLine("\nAfter Deposit:");
        Console.WriteLine(account);

        account.Balance -= 300;
        Console.WriteLine("\nAfter Withdrawal:");
        Console.WriteLine(account);
    }
}
/* Structs: Stored on the stack when used as local variables or part of another type. They are value types so they are passed by value.
Classes: Stored on the heap and passed by reference, making them suitable for larger, more complex objects*/
#endregion
