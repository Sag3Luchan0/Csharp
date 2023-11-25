using System.Xml.Serialization;

namespace Lib
{
    public class Author
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Surname { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int BirthYear { get; set; }

        public Author(string name, string surname, int birthYear)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
        }

        public Author()
        {

        }

        // Перевизначення еквівалентності
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            Author author = (Author)obj;
            return author.Name == Name && author.Surname == Surname;
        }

        // Визначення представлення у вигляді рядку:
        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public static bool operator ==(Author left, Author right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Author left, Author right)
        {
            return !(left == right);
        }
    }

    public class Novel<TAuthor>
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Year { get; set; }

        // Додайте властивість для зберігання автора (TAuthor)
        public TAuthor Author { get; set; }

        // Конструктори
        public Novel(string title, int year, TAuthor author)
        {
            Title = title;
            Year = year;
            Author = author;
        }

        public Novel()
        {

        }

        // Визначення представлення у вигляді рядку
        public override string ToString()
        {
            string s = string.Format("Title: \"{0}\". Year: {1}. Author: {2}\n", Title, Year, Author);
            return s;
        }

        // Перевизначення еквівалентності
        public override bool Equals(object? obj)
        {
            if (obj is Novel<TAuthor> b)
            {
                if (b.Year.Equals(Year))
                {
                    return false;
                }
                return b.Title == Title && b.Year == Year && b.Author.Equals(Author);
            }
            return false;
        }
    }

    public class CulturalFigure<TAuthor>
    {
        public List<Novel<TAuthor>> ArraysOfNovels { get; set; }

        // Конструктор
        public CulturalFigure(params Novel<TAuthor>[] objects)
        {
            ArraysOfNovels = new List<Novel<TAuthor>>(objects);
        }

        // Додавання казки
        public void Add(Novel<TAuthor> story)
        {
            ArraysOfNovels.Add(story);
        }

        // Індексатор
        public Novel<TAuthor> this[int index]
        {
            get { return ArraysOfNovels[index]; }
            set { ArraysOfNovels[index] = value; }
        }

        // Перевантажений оператор додавання казки
        public static CulturalFigure<TAuthor> operator +(CulturalFigure<TAuthor> figure, Novel<TAuthor> story)
        {
            CulturalFigure<TAuthor> newFigure = new() { ArraysOfNovels = figure.ArraysOfNovels };
            newFigure.Add(story);
            return newFigure;
        }

        // Перевантажений оператор видалення казки
        public static CulturalFigure<TAuthor> operator -(CulturalFigure<TAuthor> figure, Novel<TAuthor> story)
        {
            CulturalFigure<TAuthor> newFigure = new() { ArraysOfNovels = figure.ArraysOfNovels };
            newFigure.Remove(story);
            return newFigure;
        }

        // Видалення казки зі вказаними даними
        public void Remove(Novel<TAuthor> story)
        {
            ArraysOfNovels.Remove(story);
        }

        // Визначення представлення у вигляді рядку
        public override string ToString()
        {
            string result = "";
            foreach (Novel<TAuthor> story in ArraysOfNovels)
            {
                result += story.Title + " " + story.Year + "\n";
            }
            return result;
        }

        // Пошук казки з певною послідовністю літер
        public List<Novel<TAuthor>> ContainsCharacters(string nameCharacters)
        {
            List<Novel<TAuthor>> found = new();
            foreach (Novel<TAuthor> story in ArraysOfNovels)
            {
                if (story.Title.Contains(nameCharacters))
                {
                    found.Add(story);
                }
            }
            return found;
        }

        // Читання казок за допомогою механізму десеріалізації
        public bool ReadStories(string fileName)
        {
            XmlSerializer deserializer = new(typeof(List<Novel<TAuthor>>));
            using TextReader textReader = new StreamReader(fileName);
            var data = deserializer.Deserialize(textReader);
            if (data == null)
            {
                return false;
            }
            ArraysOfNovels = (List<Novel<TAuthor>>)data;
            return true;
        }

        // Запис казок за допомогою механізму серіалізації
        public void WriteStories(string fileName)
        {
            XmlSerializer serializer = new(typeof(List<Novel<TAuthor>>));
            using TextWriter textWriter = new StreamWriter(fileName);
            serializer.Serialize(textWriter, ArraysOfNovels);
        }

        // Вкладений клас для порівняння казок за алфавітом назв в зворотньому порядку
        class CompareByTitleReverse : IComparer<Novel<TAuthor>>
        {
            public int Compare(Novel<TAuthor>? b1, Novel<TAuthor>? b2)
            {
                if (b1 == null || b2 == null)
                {
                    return 0;
                }
                // Змінено на CompareTo для порівняння в зворотньому порядку
                return string.Compare(b2.Title, b1.Title);
            }
        }


        // Вкладений клас для порівняння казок за роком
        class CompareSortByYear : IComparer<Novel<TAuthor>>
        {
            public int Compare(Novel<TAuthor>? b1, Novel<TAuthor>? b2)
            {
                if (b1 == null || b2 == null)
                {
                    return 0;
                }
                return b1.Year.CompareTo(b2.Year);
            }
        }

        // Сортування казок за алфавітом назв
        public void SortByTitle()
        {
            ArraysOfNovels.Sort(new CompareByTitleReverse());
        }

        // Сортування казок за роком
        public void SortByYear()
        {
            ArraysOfNovels.Sort(new CompareSortByYear());
        }
    }
}