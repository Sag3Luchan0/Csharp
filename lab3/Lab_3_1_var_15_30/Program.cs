using Lib;

namespace BookshelfApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Створюємо порожню полицю:
            CulturalFigure<Author> bookshelf = new();

            // Додаємо книжки

            bookshelf += new Novel<Author>("Колобок", 1855,
                new Author("Афанасій", "Афанасьєвич", 1826) { });

            bookshelf += new Novel<Author>("Червона Шапочка", 1812,
                new Author("Брати-Грімм", "Якоб і Вільгельм", 1785) { });

            bookshelf += new Novel<Author>("Попелюшка", 1812,
                new Author("Брати-Грімм", "Якоб і Вільгельм", 1785) { });


            // Шукаємо книжки з певною послідовністю літер:
            Console.WriteLine("Уведiть послiдовнiсть лiтер:");
            string sequence = Console.ReadLine() ?? "";

            CulturalFigure<Author> newBookshelf = new()
            {
                ArraysOfNovels = bookshelf.ContainsCharacters(sequence)
            };

            // Виводимо результат на екран:
            Console.WriteLine("Знайденi роман(-и):");
            Console.WriteLine(newBookshelf);
            Console.WriteLine();
            //Console.WriteLine(newGroup);

            try
            {
                // Зберігаємо дані про книжки:
                bookshelf.WriteStories("Bookshelf.xml");

                // Здійснюємо сортування за назвами та зберігаємо у файлі:
                bookshelf.SortByTitle();
                Console.WriteLine("За назвами:");
                Console.WriteLine(bookshelf);
                Console.WriteLine();
                bookshelf.WriteStories("ByTitle.xml");

                // Здійснюємо сортування за кількістю авторів та зберігаємо у файлі:
                bookshelf.SortByYear();
                Console.WriteLine("За роками:");
                Console.WriteLine(bookshelf);
                Console.WriteLine();
                bookshelf.WriteStories("ByAuthorsCount.xml");
                bookshelf.ReadStories("ByTitle.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------Виняток:------------");
                Console.WriteLine(ex.GetType());
                Console.WriteLine("-------------Змiст:-------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-------Трасування стеку:-------");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}