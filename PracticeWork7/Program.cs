using PracticeWork7;
using System.Globalization;
using System.Text;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Оберіть завдання:");
            Console.WriteLine("1 - Завдання 1");
            Console.WriteLine("2 - Завдання 2");
            Console.WriteLine("3 - Завдання 3");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;

                case "2":
                    RunTask2();
                    break;

                case "3":
                    RunTask3();
                    break;

                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void RunTask1()
    {
        Rack<Guitar> newGuitars = new Rack<Guitar>("Стенд новинок");

        Rack<Guitar> discountedGuitars = new Rack<Guitar>("Стенд уцінених товарів");

        newGuitars.Add(new Guitar("RG550", "Ibanez", 35000, 6));

        newGuitars.Add(new Guitar("Les Paul", "Gibson", 85000, 6));

        newGuitars.Add(new Guitar("Stratocaster", "Fender", 62000, 6));

        discountedGuitars.Add(new Guitar("Pacifica 112", "Yamaha", 12000, 6));

        Console.WriteLine(newGuitars);
        Console.WriteLine(discountedGuitars);

        Rearrange(newGuitars, discountedGuitars, 0);

        Rearrange(discountedGuitars, newGuitars, 1);

        Console.WriteLine(newGuitars);
        Console.WriteLine(discountedGuitars);

        Rack<Keyboard> keyboards = new Rack<Keyboard>("Стенд клавішних");

        keyboards.Add(new Keyboard("PSR-E373", "Yamaha", 15000, 61));

        keyboards.Add(new Keyboard("CT-S300", "Casio", 11000, 61));

        keyboards.Add(new Keyboard("FP-30X", "Roland", 38000, 88));

        Console.WriteLine(keyboards);

        Guitar guitar = newGuitars[0];
        Console.WriteLine(guitar);
    }

    static void RunTask2()
    {
        Rack<Guitar> guitars = new Rack<Guitar>("Стенд гітар");

        guitars.Add(new Guitar("RG550", "Ibanez", 35000, 6));
        guitars.Add(new Guitar("Les Paul", "Gibson", 85000, 6));
        guitars.Add(new Guitar("Stratocaster", "Fender", 62000, 6));
        guitars.Add(new Guitar("Pacifica 112", "Yamaha", 12000, 6));

        Rack<Keyboard> keyboards = new Rack<Keyboard>("Стенд клавішних");

        keyboards.Add(new Keyboard("PSR-E373", "Yamaha", 15000, 61));
        keyboards.Add(new Keyboard("CT-S300", "Casio", 11000, 61));
        keyboards.Add(new Keyboard("FP-30X", "Roland", 38000, 88));

        Console.WriteLine($"Загальна вартість гітар: {guitars.TotalPrice} грн");
        Console.WriteLine($"Загальна вартість клавішних: {keyboards.TotalPrice} грн");

        Keyboard? cheapest = keyboards.Cheapest();

        if (cheapest != null)
        {
            Console.WriteLine("\nНайдешевший клавішний інструмент:");
            Console.WriteLine(cheapest);
            Console.WriteLine($"Кількість клавіш: {cheapest.Keys}");
        }

        Console.WriteLine("\nГітари виробника Yamaha:");

        foreach (Guitar guitar in guitars.ByBrand("Yamaha"))
        {
            Console.WriteLine(guitar);
        }
    }

    static void RunTask3()
    {
        Rack<Guitar> guitars = new Rack<Guitar>("Стенд гітар");

        guitars.Add(new Guitar("RG550", "Ibanez", 35000, 6));
        guitars.Add(new Guitar("Les Paul", "Gibson", 85000, 6));
        guitars.Add(new Guitar("Pacifica 112", "Yamaha", 12000, 6));

        KeyboardRack keyboards = new KeyboardRack("Стенд клавішних");

        keyboards.Add(new Keyboard("PSR-E373", "Yamaha", 15000, 61));
        keyboards.Add(new Keyboard("CT-S300", "Casio", 11000, 61));
        keyboards.Add(new Keyboard("FP-30X", "Roland", 38000, 88));
        keyboards.Add(new Keyboard("P-125", "Yamaha", 42000, 88));

        Report(guitars);

        Report(keyboards);

        Console.WriteLine($"\nКількість повнорозмірних клавішних: {keyboards.FullSizeCount}");
    }

    static void Rearrange<T>(Rack<T> source, Rack<T> destination, int index) where T : Instrument
    {
        T item = source[index];

        destination.Add(item);
        source.RemoveAt(index);
    }
    static void Report(IReadOnlyRack<Instrument> rack)
    {
        Console.WriteLine($"Назва: {rack.Name}");
        Console.WriteLine($"Кількість: {rack.Count}");
        Console.WriteLine($"Загальна вартість: {rack.TotalPrice} грн");

        for (int i = 0; i < rack.Count; i++)
        {
            Console.WriteLine(rack[i]);
        }
    }
}
