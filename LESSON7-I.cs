using System;

// Базовый класс Transport
public class Transport
{
    public string Model { get; set; }
    protected int Speed { get; private set; } = 0;
    
    public void ShowInfo()
    {
        Console.WriteLine($"Модель: {Model}, скорость: {Speed} км/ч");
    }
    
    public virtual void Move()
    {
        Console.WriteLine("Транспорт движется");
    }
    
    // Защищенный метод для изменения скорости (для наследников)
    protected void SetSpeed(int value)
    {
        Speed = value;
    }
    
    protected int GetSpeed()
    {
        return Speed;
    }
}

// Класс Car, наследник Transport
public class Car : Transport
{
    public void Accelerate(int value)
    {
        int newSpeed = GetSpeed() + value;
        if (newSpeed > 200)
        {
            Console.WriteLine("Слишком большая скорость!");
        }
        else
        {
            SetSpeed(newSpeed);
        }
    }
    
    public override void Move()
    {
        Console.WriteLine("Машина едет по дороге");
    }
}

// Класс Bicycle, наследник Transport
public class Bicycle : Transport
{
    public void Pedal()
    {
        SetSpeed(GetSpeed() + 5);
    }
    
    public override void Move()
    {
        Console.WriteLine("Велосипед крутит педали");
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        var car = new Car { Model = "Audi" };
        car.Accelerate(100);
        car.ShowInfo();
        car.Move();
        
        var bike = new Bicycle { Model = "Cube" };
        bike.Pedal();
        bike.ShowInfo();
        bike.Move();
    }
}