using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class CulturalFigure
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Country Country { get; set; }

        public CulturalFigure(string name, int age, Country country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public override string ToString()
        {
            return $"Cultural Figure: {Name}, {Country}\nAge: {Age}\n";
        }
    }

    internal class Writer : CulturalFigure
    {
        public List<Novel> Novels { get; set; }

        public Writer(string name, int age, Country country) : base(name, age, country)
        {
            Novels = new List<Novel>();
        }

        public void AddNovel(Novel novel)
        {
            Novels.Add(novel);
        }

        public void RemoveNovel(Novel novel)
        {
            Novels.Remove(novel);
        }

        public override string ToString()
        {
            string result = base.ToString() + "Novels:\n";
            foreach (var novel in Novels)
            {
                result += "\t" + novel + "\n";
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Writer otherWriter = (Writer)obj;
            return Name.Equals(otherWriter.Name) && Country.Equals(otherWriter.Country);
        }
    }

    internal struct Novel
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public Novel(string title, int year)
        {
            Title = title;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title}, Year: {Year}";
        }
    }

    internal class Country
    {
        public string Name { get; set; }

        public Country(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Country otherCountry = (Country)obj;
            return Name.Equals(otherCountry.Name);
        }
    }
    class Program
    {
        public static void Main()
        {
            Writer sharl = new Writer("Шарль Діккенс", 58, new Country("Британія"));
            sharl.AddNovel(new Novel("Oliver Twist", 1837));
            sharl.AddNovel(new Novel("David Copperfield", 1849));
            sharl.AddNovel(new Novel("A Tale of Two Cities", 1859));
            sharl.AddNovel(new Novel("Great Expectations", 1860));

            Console.WriteLine(sharl);

            Console.Write("Novels with title: ");
            string titleToFind = Console.ReadLine();
            var novelsWithTitle = sharl.Novels.Where(novel => novel.Title.Equals(titleToFind, StringComparison.OrdinalIgnoreCase));
            foreach (var novel in novelsWithTitle)
            {
                Console.WriteLine("\t" + novel);
            }

            Console.WriteLine("\nNovels created in year range");
            Console.Write("From year: ");
            int fromYear = int.Parse(Console.ReadLine());
            Console.Write("To year: ");
            int toYear = int.Parse(Console.ReadLine());
            var artworksInYearRange = sharl.Novels.Where(novel => novel.Year >= fromYear && novel.Year <= toYear);
            foreach (var artwork in artworksInYearRange)
            {
                Console.WriteLine("\t" + artwork);
            }

            // Додавання нового письменника з його романами
            Writer newWriter = new Writer("Франца Кафка", 35, new Country("Чехія"));
            newWriter.AddNovel(new Novel("Die Verwandlung", 1912));
            newWriter.AddNovel(new Novel("Der Prozess", 1920));

            Console.WriteLine("\nAdded New Writer:");
            Console.WriteLine(newWriter);

            // Видалення письменника
            sharl.RemoveNovel(new Novel("Great Expectations", 1860));

            Console.WriteLine("\nRemoved [Great Expectations] from [Шарль Діккенс] Novels:");
            Console.WriteLine(sharl);
        }
    }
}