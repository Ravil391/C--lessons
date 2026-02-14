using System;


abstract class Worker
{
    public string Name { get; set; }


    public abstract void Work();


    public void ShowInfo()
    {
        Console.WriteLine($"Работник: {Name}");
    }
}


class Manager : Worker
{
    public override void Work()
    {
        Console.WriteLine("Планирует задачи");
    }
}


class Developer : Worker
{
    public override void Work()
    {
        Console.WriteLine("Пишет код");
    }
}


class Program
{
    static void Main()
    {

        Worker[] workers = { 
            new Manager { Name = "Анна" }, 
            new Developer { Name = "Иван" } 
        };


        foreach (var w in workers)
        {
            w.ShowInfo();
            w.Work();
            Console.WriteLine();
        }
    }
}
