using System;
using System.IO.Compression;

namespace Lekce06.DomUkolKnihovna;

public class Book
{
    public string Title { get; set; }
    public string? author;
    public string? Author
    {
        get { return author; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                author = "Neznámý";
            }
            else
            {
                author = value;
            }
        }
    }
    public DateTime PublishedDate { get; set; }
    private int pages;
    public int Pages
    {
        get { return pages; }//validace počtu stránek, kdy počet stran nemůže být nulový, nula znamená nezmámou hodnotu
        set
        {
            if (value < 0)
            {
                pages = 0;
            }
            else
            {
                pages = value;
            }
        }
    }
    public static List<Book> ListOfBooks = [];

    //constructor
    public Book(string title, string author, DateTime publishedDate, int pages)
    {
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
        Pages = pages;
    }
    //metoda ADD
    public static void AddToList(string title, string author, DateTime publishedDate, int pages)
    {
        ListOfBooks.Add(new Book(title, author, publishedDate, pages));
    }
    //metoda LIST
    public static void GetListOfBooks()
    {
    foreach (var item in ListOfBooks.OrderByDescending(item => item.PublishedDate))
        {
            Console.WriteLine($"Kniha: {item.Title}, autor: {item.Author}, vydáno: {item.PublishedDate.ToString("d.M.yyyy")}, stran: {item.Pages}");
        }
    }
    //metoda STATS
    public static void GetStatistics()
    {
        var averagePageNumber = ListOfBooks.Average(z => z.Pages);//průměrný počet stran na knihu v knihovně

        Console.WriteLine($"Průměrný počet stran: {averagePageNumber:F0}");

        Console.WriteLine($"Počet knih dle autora:");//přiřazení počtu knih v knihovně ke kontrontrétnímu autorovi
        foreach (var group in ListOfBooks.GroupBy(a => a.Author))
        {
            var authors = group.Select(a => a.Author);
            Console.WriteLine($" -  {group.Key}: {group.Count()}");
        }

        var distinctWorlds = ListOfBooks.SelectMany(z => z.Title.Split(" ")).Distinct().Count();//unikátní slova obsažena v titulcích knih
        Console.WriteLine($"Počet unikátních slov obsažených v názvech knih je: {distinctWorlds}");

    }
    //metoda FIND
    public static void GetTitle(string world)
    {
        Console.WriteLine($"""Výsledky hledání pro "{world}":""");
        foreach (var item in ListOfBooks)
        {
            if (item.Title.ToLower().Contains(world.ToLower()))
            {
                Console.WriteLine($" - {item.Title}");
            }
        }
        var vyber = from v in ListOfBooks where v.Title.Contains(world) select v.Title.ToList();
    }

}