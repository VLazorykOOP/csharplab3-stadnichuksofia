using System;
using System.Collections.Generic;

//Task1
    //Задано масив ромбів. Вивести в консоль інформацію про та їх площу і периметр. Визначити скільки є квадратів.
    //Створити клас Romb (ромб), розробивши такі елементи класу:
    //    Поля(захищені): сторона та діагональ (int a, d1); колір ромба(int с); 
    //    Конструктор, що дозволяє створити екземпляр класу з заданими довжинами. 
    //    Методи, що дозволяють: вивести довжини на екран; розрахувати периметр ромба; розрахувати площу ромба; дозволяє встановити,
    //    чи є даний ромб є квадратом;.
    //    Властивості: отримати - встановити довжини(доступні для читання і запису); отримати колір(доступна тільки для читання).
public class Romb
{
    protected int side;
    protected int diagonal;
    protected int color;

//Конструктори
    public Romb(int side, int diagonal, int color)
    {
        this.side = side;
        this.diagonal = diagonal;
        this.color = color;
    }

    public void Show()
    {
        Console.WriteLine($"Side: {side}, Diagonal: {diagonal}, Color: {color}");
    }

    public int Perimeter() => 4 * side;

    public double Area() => 0.5 * side * diagonal;

    public bool IsSquare() => side == diagonal;
}


//Task2
    //Побудувати ієрархію класів відповідно до варіанта завдання. Згідно завдання вибрати базовий клас та похідні.
    //В класах задати поля, які характерні для кожного класу. Для всіх класів розробити метод Show(), який виводить дані
    //про об’єкт класу. Створити масив базового класу та написати функцію наповняє масив різними об’єктами похідних класів. Вивести масив впорядкований за деяким критерієм який характеризує всі об’єкти масиву.
    //Корабель, пароплав, вітрильник, корвет.

public class Ship
{
    protected string name;
    protected int yearBuilt;

    public Ship(string name, int yearBuilt)
    {
        this.name = name;
        this.yearBuilt = yearBuilt;
    }

    // Метод для виведення інформації про судно
    public virtual void Show()
    {
        Console.WriteLine($"Ship: {name}, Year Built: {yearBuilt}");
    }

    public int YearBuilt => yearBuilt;
}

// Похідний клас для пароплавів
public class Steamship : Ship
{
    protected int steamPressure;

    public Steamship(string name, int yearBuilt, int steamPressure) : base(name, yearBuilt)
    {
        this.steamPressure = steamPressure;
    }

    // Перевизначений метод виведення інформації про пароплав
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Steam Pressure: {steamPressure}");
    }
}

// Похідний клас для вітрильників
public class Sailboat : Ship
{
    protected int mastHeight;

    public Sailboat(string name, int yearBuilt, int mastHeight) : base(name, yearBuilt)
    {
        this.mastHeight = mastHeight;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Mast Height: {mastHeight}");
    }
}

// Похідний клас для корветів
public class Corvette : Ship
{
    protected string weaponType;

    public Corvette(string name, int yearBuilt, string weaponType) : base(name, yearBuilt)
    {
        this.weaponType = weaponType;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Weapon Type: {weaponType}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lab 3 !");
        Console.WriteLine("Please choose the task:");
        Console.WriteLine("1. Task_1");
        Console.WriteLine("2. Task_2");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Romb[] rombs = {
                new Romb(4, 6, 1),
                new Romb(5, 5, 2),
                new Romb(3, 7, 3)
            };

            int squareCount = 0;

            foreach (var romb in rombs)
            {
                Console.WriteLine("Rhombus:");
                romb.Show();
                Console.WriteLine($"Perimeter: {romb.Perimeter()}, Area: {romb.Area()}");
                if (romb.IsSquare())
                    squareCount++;
            }

            Console.WriteLine($"Total squares: {squareCount}");
        }
        else if (choice == 2)
        {
            List<Ship> ships = new List<Ship>
            {
                new Steamship("Titanic", 1912, 100),
                new Sailboat("Sea Breeze", 2005, 50),
                new Corvette("Thunder", 2010, "Missiles"),
                new Steamship("Queen Mary", 1936, 120),
                new Sailboat("Wind Chaser", 1998, 45),
                new Corvette("Lightning", 2008, "Cannons")
            };

            ships.Sort((x, y) => x.YearBuilt.CompareTo(y.YearBuilt));

            foreach (var ship in ships)
            {
                ship.Show();
            }
        }
    }
}
