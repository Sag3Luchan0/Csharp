using System.Xml.Serialization;

namespace Lab_4_1_var_15_30Lib1Lib;

public class CulturalFigure<T>
{
    [XmlAttribute]
    public string Name { get; set; }
    [XmlAttribute]
    public int YearOfBirth { get; set; }
    public T Country { get; set; }

    public CulturalFigure() { }
    public CulturalFigure(string name, int yearOfBirth, T country)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
        Country = country;
    }

    public override string ToString()
    {
        return $"Cultural Figure: {Name}, {Country}\nYear of Birth: {YearOfBirth}";
    }
}

public class Artist<T> : CulturalFigure<T>
{
    public List<Artwork> Artworks { get; set; }

    public Artist() { }
    public Artist(string name, int yearOfBirth, T country, List<Artwork> artworks) : base(name, yearOfBirth, country)
    {
        Artworks = artworks;
    }

    public int GetTotalArtworkCount()
    {
        return Artworks.Count;
    }

    public override string ToString()
    {
        string result = base.ToString() + $"\nType: Artist\nTotal Artworks: {GetTotalArtworkCount()}\nArtworks:\n";
        foreach (var artwork in Artworks)
        {
            result += "\t" + artwork + "\n";
        }
        return result;
    }

    public List<Artwork> GetArtworksWithName(string name)
    {
        List<Artwork> result = new List<Artwork>();

        foreach (var artwork in Artworks)
        {
            if (artwork.Name.ToLower() == name.ToLower())
            {
                result.Add(artwork);
            }
        }

        return result;
    }

    public List<Artwork> GetArtworksWithYear(int from, int to)
    {
        List<Artwork> result = new List<Artwork>();

        if (to < from || to < 0)
        {
            return result;
        }

        foreach (var artwork in Artworks)
        {
            if (artwork.Year >= from && artwork.Year <= to)
            {
                result.Add(artwork);
            }
        }

        return result;
    }

    public static Artist<T> operator +(Artist<T> artist, Artwork artworkToAdd)
    {
        artist.Artworks.Add(artworkToAdd);
        return artist;
    }
    public static Artist<T> operator -(Artist<T> artist, Artwork artworkToRemove)
    {
        artist.Artworks.Remove(artworkToRemove);
        return artist;
    }

    public void SortByNameAlphabetically()
    {
        Artworks = Artworks.OrderByDescending(artwork => artwork.Name).ToList();
    }

    public void SortByYear()
    {
        Artworks = Artworks.OrderBy(artwork => artwork.Year).ToList();
    }

    public void WriteToXml(string fileName)
    {
        XmlSerializer serializer = new(typeof(List<Artwork>));

        using TextWriter textWriter = new StreamWriter(fileName);

        serializer.Serialize(textWriter, Artworks);
    }
    public void ReadFromXml(string fileName)
    {
        XmlSerializer deserializer = new(typeof(List<Artwork>));
        using TextReader textReader = new StreamReader(fileName);
        Artworks = (List<Artwork>)deserializer.Deserialize(textReader);
    }
}

public class Artwork
{
    [XmlAttribute]
    public string Name { get; set; }
    [XmlAttribute]
    public int Year { get; set; }

    public Artwork() { }
    public Artwork(string name, int year)
    {
        Name = name;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Name}, Year: {Year}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Artwork artwork && Name == artwork.Name && Year == artwork.Year;
    }
}

public struct CountryStruct
{
    [XmlAttributeAttribute]
    public string Name { get; set; }

    public CountryStruct(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class CountryClass
{
    [XmlAttributeAttribute]
    public string Name { get; set; }

    public CountryClass(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}