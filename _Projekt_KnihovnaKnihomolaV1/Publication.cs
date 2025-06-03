using System;
using System.Text;

namespace _Projekt_KnihovnaKnihomolaV1;

//třída obsahující objekt kniha v různých podobách
public abstract class Publication
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumberOfBookInSerie { get; set; }

    public Publication(string title, string author, int numberOfBookInSerie)//constructor
    {
        Title = title;
        Author = author;
        NumberOfBookInSerie = numberOfBookInSerie;
    }

    public abstract void GetInfo();//výpis knihy
}

public abstract class Purchased : Publication
{
    public bool ReadStatus { get; set; }
    public int Rating { get; set; }
    public Purchased(string title, string author, int numberOfBookInSerie, bool readStatus, int rating) : base(title, author, numberOfBookInSerie)
    {
        ReadStatus = readStatus;
        Rating = rating;
    }
}

public class Fiction : Purchased
{
    int Pages { get; set; }
    public string Genre { get; set; }
    public Fiction(string title, string author, int numberOfBookInSerie, int pages, string genre, bool readStatus, int rating) : base(title, author, numberOfBookInSerie, readStatus, rating)
    {
        Genre = genre;
        Pages = pages;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"kniha: {Title}, autor: {Author}, počet stran: {Pages}, žánr: {Genre}, přečteno: {ReadStatus}, hodnocení: {Rating}");
    }
}

public class AudioBook : Purchased
{
    public TimeSpan RunTime { get; set; }
    public string Genre { get; set; }
    public AudioBook(string title, string author, int numberOfBookInSerie, TimeSpan runTime, string genre, bool readStatus, int rating) : base(title, author, numberOfBookInSerie, readStatus, rating)
    {
        RunTime = runTime;
        Genre = genre;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"kniha: {Title}, autor: {Author}, délka: {RunTime}, žánr: {Genre}, poslechnuto: {Genre}, hodnocení: {Rating}");
    }
}

    //definition of non-fiction book
    public class NonFiction : Purchased
    {
        public int Pages{ get; set; }
        public string Theme { get; set; }
        public NonFiction(string title, string author, int numberOfBookInSerie, int pages, string theme, bool readStatus, int rating) : base(title, author, numberOfBookInSerie, readStatus, rating)
        {
        Pages = pages;
        Theme = theme;
        }

    public override void GetInfo()
    {
        Console.WriteLine($"Kniha: {Title}, autor: {Author}, stran: {Pages}, téma: {Theme}, přečteno: {ReadStatus}, hodnocení: {Rating}");
    }
}

    public class WishListBook : Publication
    {
        public DateTime DateRealease { get; set; }

        public WishListBook(string title, string author, int number, DateTime dateRealease) : base(title, author, number)
        {
            DateRealease = dateRealease;
        }

    public override void GetInfo()
    {
        Console.WriteLine($"Kniha: {Title}, autor: {Author}, datum vydání: {DateRealease}");
    }
}

