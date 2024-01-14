// Class and Object definition
namespace Intro;
class Car
{
    public string brand { get; set; } = null!;
    public string model { get; set; } = null!;

    public void StartEngine()
    {
        Console.WriteLine($"Engine of {brand}-{model} started!");
    }
}

// Encapsulation
class BankAccount
{
    private double balance; // Encapsulated variable

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}


// Inheritance
class Animal
{
    public void Sound()
    {
        Console.WriteLine("Some sound");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof!");
    }
}

// Polymorphism
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

// Abstraction
abstract class Vehicle
{
    public abstract void Start();
    public void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }
}

class Truck : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car started");
    }
}

// Interfaces
interface IShape
{
    void Draw();
}

class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a square");
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Class Definition
        var myCar = new Car
        {
            brand = "Toyota",
            model = "Corolla"
        };
        myCar.StartEngine();

        // Encapsulation
        var ba = new BankAccount();
        var initialBalance = ba.GetBalance();
        Console.WriteLine($"Bank Account Balance: {initialBalance}");
        ba.Deposit(amount: 1000.0);
        var finalBalance = ba.GetBalance();
        Console.WriteLine($"Bank Account Balance: {finalBalance}");

        // Inheritance
        Dog myDog = new Dog();
        myDog.Sound(); // Output: Some sound
        myDog.Bark(); // Output: Woof!

        // Polymorphism
        Shape shape1 = new Circle();
        shape1.Draw(); // Output: Drawing a circle

        // Abstraction
        Vehicle myTruck = new Truck();
        myTruck.Start(); // Output: Truck started
        myTruck.Stop(); // Output: Truck stopped

        // Interfaces
        IShape shape = new Square();
        shape.Draw(); // Output: Drawing a square

        // Mediator
        // Create mediator
        var mediator = new Mediator();

        // Register request handler
        mediator.RegisterHandler(new GreetRequestHandler());

        // Send request through mediator
        var greetRequest = new GreetRequest { Name = "John" };
        var result = mediator.Send(greetRequest);

        Console.WriteLine(result); // Output: Hello, John!
    }
}

