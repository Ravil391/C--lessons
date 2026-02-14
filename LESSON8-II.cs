using System;


abstract class CookingProcess
{

    public void Cook()
    {
        PrepareIngredients();
        Process(); 
        Serve();
    }


    private void PrepareIngredients()
    {
        Console.WriteLine("Подготовка ингредиентов: моем, режем, взвешиваем.");
    }


    protected abstract void Process();


    private void Serve()
    {
        Console.WriteLine("Подача: выкладываем на тарелку и украшаем зеленью.");
        Console.WriteLine(new string('-', 30));
    }
}


class Soup : CookingProcess
{
    protected override void Process()
    {
        Console.WriteLine("Основной процесс: ингредиенты варятся в бульоне на медленном огне.");
    }
}


class Steak : CookingProcess
{
    protected override void Process()
    {
        Console.WriteLine("Основной процесс: мясо жарится на сильно разогретой сковороде до нужной прожарки.");
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("--- Готовим Суп ---");
        CookingProcess soup = new Soup();
        soup.Cook();

        Console.WriteLine("--- Готовим Стейк ---");
        CookingProcess steak = new Steak();
        steak.Cook();
    }
}
