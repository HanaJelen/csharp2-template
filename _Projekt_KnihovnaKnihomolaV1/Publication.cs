using System;
using System.Text;

namespace _Projekt_KnihovnaKnihomolaV1;

//třída obsahující objekt publikace v různých podobách
public abstract class Publication
{
    public string Medium { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string NameOfSerie { get; set; }
    public int NumberOfBookInSerie { get; set; }

    public Publication(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie)//constructor
    {
        Medium = medium;
        Title = title;
        Author = author;
        NameOfSerie = nameOfSerie;
        NumberOfBookInSerie = numberOfBookInSerie;
    }

    public abstract void GetInfo();//výpis knihy
}

public abstract class Purchased : Publication
{
    public string Genre { get; set; }
    public string Theme { get; set; }
    public bool ReadStatus { get; set; }
    public int Rating { get; set; }

    public Purchased(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, string genre, string theme, bool readStatus, int rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie)
    {
        ReadStatus = readStatus;
        Rating = rating;
        Genre = genre;
        Theme = theme;
    }
}

public class Book : Purchased
{
    public int Pages { get; set; }

    public Book(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, string genre, string theme, int pages, bool readStatus, int rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie, genre, theme, readStatus, rating)
    {

        Pages = pages;
    }

    public override void GetInfo()
    {
        if (NameOfSerie is null)
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, počet stran: {Pages}, žánr: {Genre}, přečteno: {ReadStatus}, hodnocení: {Rating}");
        }
        else
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, počet stran: {Pages}, žánr: {Genre}, serie: {NameOfSerie}, přečteno: {ReadStatus}, hodnocení: {Rating}");
        }
    }
}

public class AudioBook : Purchased
{
    public TimeSpan RunTime { get; set; }

    public AudioBook(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, string genre, string theme, TimeSpan runTime, bool readStatus, int rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie, genre, theme, readStatus, rating)
    {
        
        RunTime = runTime;
    }

    public override void GetInfo()
    {
        if (NameOfSerie is null)
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, délka: {RunTime}, žánr: {Genre}, přečteno: {ReadStatus}, hodnocení: {Rating}");
        }
        else
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, délka: {RunTime}, žánr: {Genre}, serie: {NameOfSerie}, přečteno: {ReadStatus}, hodnocení: {Rating}");
        }
    }
}


public class WishListBook : Publication
{
    public WishListBook(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie) : base(medium, title, author, nameOfSerie, numberOfBookInSerie)
    {}

    public override void GetInfo()
    {
        if (NameOfSerie is null)
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, typ media: {Medium}");
        }
        else
        {
            Console.WriteLine($"kniha: {Title}, autor: {Author}, serie: {NameOfSerie}, typ media: {Medium}");
        }
    }
}
public class InPressBook : Publication
    {
        public DateTime DateRealease { get; set; }

        public InPressBook(string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, DateTime dateRealease) : base(medium, title, author, nameOfSerie, numberOfBookInSerie)
        {
            DateRealease = dateRealease;
        }

        public override void GetInfo()
        {
            if (NameOfSerie is null)
            {
                Console.WriteLine($"kniha: {Title}, autor: {Author}, typ media: {Medium}, datum vydání: {DateRealease}");
            }
            else
            {
                Console.WriteLine($"kniha: {Title}, autor: {Author}, serie: {NameOfSerie}, typ media: {Medium}, datum vydání: {DateRealease}");
            }
        }
    }

