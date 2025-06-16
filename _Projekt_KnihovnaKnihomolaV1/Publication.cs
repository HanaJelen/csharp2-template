using System;
using System.Text;

namespace _Projekt_KnihovnaKnihomolaV1;

public abstract class Publication
{
    public string Medium { get; private set; }
    public string Title { get; set; }
    public string Author { get; private set; }
    public string? NameOfSerie { get; private set; }
    public int? NumberOfBookInSerie { get; private set; }

    public Publication(string medium, string title, string author, string? nameOfSerie, int? numberOfBookInSerie)
    {
        Medium = medium;
        Title = title;
        Author = author;
        NameOfSerie = nameOfSerie;
        NumberOfBookInSerie = numberOfBookInSerie;
    }

    public abstract void GetInfo();
}

public abstract class Purchased : Publication
{
    public string Genre { get; private set; }
    public string Theme { get; private set; }
    public bool ReadStatus { get; private set; }
    private int? rating;
    public int? Rating
    {
        get { return rating; }
        private set
        {
            if (value > 5)
            { rating = 5; }
            if (value < 0)
            {
                rating = 0;
            }
            else
            { rating = value; }
        }
    }

    public Purchased(string medium, string title, string author, string? nameOfSerie, int? numberOfBookInSerie, string genre, string theme, bool readStatus, int? rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie)
    {
        ReadStatus = readStatus;
        Rating = rating;
        Genre = genre;
        Theme = theme;
    }
    public void RatePublication(int number)
    {
        Rating = number;
    }
}

public class Book : Purchased
{
    public int Pages { get; private set; }

    public Book(string medium, string title, string author, string? nameOfSerie, int? numberOfBookInSerie, string genre, string theme, int pages, bool readStatus, int? rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie, genre, theme, readStatus, rating)
    {

        Pages = pages;
    }

    public override void GetInfo()
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(NameOfSerie) ? $"kniha: {Title}, autor: {Author}, počet stran: {Pages}, žánr: {Genre}, přečteno: {ReadStatus}, hodnocení: {Rating}" : $"kniha: {Title}, autor: {Author}, počet stran: {Pages}, žánr: {Genre}, serie: {NameOfSerie}, přečteno: {ReadStatus}, hodnocení: {Rating}");
    }
}

public class AudioBook : Purchased
{
    public TimeSpan RunTime { get; private set; }

    public AudioBook(string medium, string title, string author, string? nameOfSerie, int? numberOfBookInSerie, string genre, string theme, TimeSpan runTime, bool readStatus, int? rating) : base(medium, title, author, nameOfSerie, numberOfBookInSerie, genre, theme, readStatus, rating)
    {
        
        RunTime = runTime;
    }

    public override void GetInfo()
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(NameOfSerie) ? $"kniha: {Title}, autor: {Author}, délka: {RunTime}, žánr: {Genre}, přečteno: {ReadStatus}, hodnocení: {Rating}" : $"kniha: {Title}, autor: {Author}, délka: {RunTime}, žánr: {Genre}, serie: {NameOfSerie}, přečteno: {ReadStatus}, hodnocení: {Rating}");
    }
}


public class WishListBook : Publication
{
    public DateTime? DateRealease { get; private set; }
    public WishListBook(string medium, string title, string author, string? nameOfSerie, int? numberOfBookInSerie, DateTime? dateRealease) : base(medium, title, author, nameOfSerie, numberOfBookInSerie)
    {
        DateRealease = dateRealease;
    }

    public override void GetInfo()
    {
        Console.WriteLine(DateRealease is null ? $"kniha: {Title}, autor: {Author}, serie: {NameOfSerie}, typ media: {Medium}, datum vydání: {DateRealease}" : $"kniha: {Title}, autor: {Author}, serie: {NameOfSerie}, typ media: {Medium}");
    }
}