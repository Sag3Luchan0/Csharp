using System;

public class Country
{
    public string Name { get; set; }

    public Country(string name)
    {
        Name = name;
    }
}

public class Novel
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string[] Authors { get; set; }
    public Country Origin { get; set; }

    public Novel(string title, int year, Country origin, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = authors;
        Origin = origin;
    }

    public void Print()
    {
        Console.WriteLine("Назва: \"{0}\". Рiк видання: {1}", Title, Year);
        Console.WriteLine("   Автор(и):");
        for (int i = 0; i < Authors.Length; i++)
        {
            Console.Write("      {0}", Authors[i]);
            if (i < Authors.Length - 1)
            {
                Console.WriteLine(",");
            }
            else
            {
                Console.WriteLine("");
            }
        }
        Console.WriteLine("   Країна походження: {0}", Origin.Name);
    }
}

public class Writer
{
    public Novel[] Novels { get; set; }

    public Writer(params Novel[] novels)
    {
        Novels = novels;
    }

    public void Print()
    {
        Console.WriteLine("----------Романи письменника:----------");
        foreach (Novel novel in Novels)
        {
            novel.Print();
        }
    }

    public Novel[] FindByTitle(string title)
    {
        Novel[] found = new Novel[0];
        foreach (Novel novel in Novels)
        {
            if (novel.Title.Contains(title))
            {
                Array.Resize(ref found, found.Length + 1);
                found[found.Length - 1] = novel;
            }
        }
        return found;
    }

    public Novel[] FindByAuthor(string author)
    {
        Novel[] found = new Novel[0];
        foreach (Novel novel in Novels)
        {
            if (Array.Exists(novel.Authors, element => element == author))
            {
                Array.Resize(ref found, found.Length + 1);
                found[found.Length - 1] = novel;
            }
        }
        return found;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо письменника з трьома романами:
        Writer writer = new Writer(
            new Novel("Тисяча чудес", 2000, new Country("Україна"), "Андрій Шевченко"),
            new Novel("По той бік обрію", 2015, new Country("Україна"), "Іван Франко"),
            new Novel("Війна і мир", 1869, new Country("Росія"), "Лев Толстой")
        );

        // Виводимо дані на екран:
        writer.Print();

        Console.WriteLine("Уведiть назву роману:");
        string title = Console.ReadLine() ?? string.Empty;

        // Шукаємо романи за назвою:
        Novel[] novelsByTitle = writer.FindByTitle(title);

        Console.WriteLine("Уведiть ім'я автора:");
        string author = Console.ReadLine() ?? string.Empty;

        // Шукаємо романи за автором:
        Novel[] novelsByAuthor = writer.FindByAuthor(author);

        // Виводимо результати на екран:
        Console.WriteLine("----------Результати пошуку за назвою та автором:----------");
        foreach (Novel novel in novelsByTitle)
        {
            novel.Print();
        }

    }
}