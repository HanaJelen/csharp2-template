using System;
using System.Runtime.CompilerServices;

namespace _Projekt_KnihovnaKnihomolaV1;

class BookList
{
    public static List<Book> ListOfBook = [];
    //ADD
    public static void AddToList(Book publication)
    {
        ListOfBook.Add(publication);
    }
    //LIST
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfBook.OrderBy(item => item.Title))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfBook)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
    //FIND funkce
    public static List<Publication> GetTitle(string world)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfBook)
        {
            if (item.Title.ToLower().Contains(world.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
    public static List<Publication> GetBooksOfAuthor(string name)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfBook)
        {
            if (item.Author.ToLower().Contains(name.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
    //STATS
    public static void AuthorStats(string name)
    {
        string author = name.ToLower();
        var pocetKnihAutora = (from v in ListOfBook where v.Author.ToLower().Contains(author) select v.Title).Count();
        if (pocetKnihAutora > 0)
        {
            var prumerStran = (from v in ListOfBook where v.Author.ToLower().Contains(author) select v.Pages).Average();
            var genreAutor = (from v in ListOfBook where v.Author.ToLower().Contains(author) select v.Genre).Distinct();
            var hodnoceniAutor = (from v in ListOfBook where v.Author.ToLower().Contains(author) select v.Rating).Average();

            Console.WriteLine($"autor: {author.ToUpper()}\n počet knih v knihovně: {pocetKnihAutora}, průměrný počet stran: {prumerStran:F0}, průměrné hodnocení knihy: {hodnoceniAutor:F1}\nžánry: ");
            foreach (var item in genreAutor)
            {
                Console.WriteLine($"- {item}");
            }

        }
        else
        {
            Console.WriteLine("Pod tímto heslem nebyl nalezen žádný autor.");
        }
    }
    public static void GenreStats()
    {
        var groupingGenre = ListOfBook.GroupBy(genre => genre.Genre);
        foreach (var skupina in BookList.ListOfBook.GroupBy(genre => genre.Genre))
        {
            var genreCount = skupina.Select(t => t.Title);
            Console.WriteLine(skupina.Key + ": počet knih " + genreCount.Count());
        }
    }
    public static void GetBest()
    {
        var hodnoceniBest = (from v in ListOfBook.OrderByDescending(v => v.Rating) select (v.Title, v.Author)).Take(10);
        foreach (var item in hodnoceniBest)
        {
            Console.WriteLine($"{item.Title}, autor: {item.Author}");
        }
    }
    public static void GetWorst()
    {
        var hodnoceniWorst = (from v in ListOfBook.OrderBy(v => v.Rating) select (v.Title, v.Author)).Take(10);
        foreach (var item in hodnoceniWorst)
        {
            Console.WriteLine($"{item.Title}, autor: {item.Author}");
        }
    }
    //MANAGE
    public static void RemoveBook(string title)
    {
        int index = ListOfBook.FindIndex(p => p.Title.ToLower() == title.ToLower());
        if (index != -1)
        {
            Console.WriteLine("Přejete si odstranit tuto knihu (A/N)? ");
            ListOfBook[index].GetInfo();
            string notification = InputManage.LoadInput();
            if (notification.ToLower() == "a")
            {
                ListOfBook.RemoveAt(index);
                Console.WriteLine("Kniha byla odstraněna.");
            }
        }
        else
        {
            Console.WriteLine("Zadaný titul knihy není v seznamu knihovny.");
        }
    }
    public static void GetRate()
    {
        Console.WriteLine("Zadejte titul knihy, kterou chcete ohodnotit.");
        int index = ListOfBook.FindIndex(p => p.Title.ToLower() == InputManage.LoadInput().ToLower());
        if (index != -1)
        {
            Console.WriteLine("Zadejte hodnocení.");
            ListOfBook[index].RatePublication(InputManage.StringToNumber(InputManage.LoadInput()));
            Console.WriteLine("Kniha byla ohodnocena.");
        }
        else
        {
            Console.WriteLine($"""Zadaný titul není v seznamu knihovny.""");
        }
    }
}

class AudioList
{
    public static List<AudioBook> ListOfAudio = [];
    //ADD
    public static void AddToList(AudioBook publication)
    {
        ListOfAudio.Add(publication);
    }
    //LIST
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfAudio.OrderBy(item => item.Title))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfAudio)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
    //FIND
    public static List<Publication> GetTitle(string world)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfAudio)
        {
            if (item.Title.ToLower().Contains(world.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
    public static List<Publication> GetBooksOfAuthor(string name)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfAudio)
        {
            if (item.Author.ToLower().Contains(name.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }

    
}

class WishList
{
    public static List<WishListBook> ListOfWish = [];

    public static void AddToList(WishListBook publication)
    {
        ListOfWish.Add(publication);
    }
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfWish.OrderBy(item => item.Title))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfWish)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        return serie;
    }
}

class Serie
{
    public static void GetSerie(string name)
    {
        var bookSerie = BookList.GetSerie(name).Concat(AudioList.GetSerie(name)).Concat(WishList.GetSerie(name));
        Console.WriteLine($"Serie {name} obsahuje tyto tituly:");
        foreach (var item in bookSerie.OrderBy(i => i.NumberOfBookInSerie))
        {
            if (item.Medium == "book" || item.Medium == "audio")
            {
                Console.WriteLine($"{item.Title}, díl {item.NumberOfBookInSerie}, zakoupeno");
            }
            else
            {
                Console.WriteLine($"{item.Title}, díl {item.NumberOfBookInSerie}");
            }
        }
    }
}
