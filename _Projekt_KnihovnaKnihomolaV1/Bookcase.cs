using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _Projekt_KnihovnaKnihomolaV1;

class BookList
{
    public static List<Book> ListOfBook = [];
    //LIST
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfBook.OrderBy(item => item.Title))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetToSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfBook)
        {
            if (item.NameOfSerie.ToLower() == nameSerie.ToLower())
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
        foreach (var skupina in ListOfBook.GroupBy(genre => genre.Genre))
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
            string notification = InputManage.LoadInput("");
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

    public static void ChangeNameAuthor(string wrongTitle)
    {
        int index = ListOfBook.FindIndex(p => p.Title.ToLower() == wrongTitle.ToLower());
         if (index != -1)
        {
            Console.WriteLine("Zadejte název knihy.");
            string title = InputManage.LoadInput("");
            Console.WriteLine("Zadejte jméno a přijmení autora.");
            string author = InputManage.LoadInput("");
            ListOfBook[index].Rename(title, author);
            
        }
        else
        {
            Console.WriteLine("Zadaný titul nebyl nalezen.");
        }
    }

    public static void GetRate()
    {
        Console.WriteLine("Zadejte titul knihy, kterou chcete ohodnotit.");
        string vstup = InputManage.LoadInput("");
        int index = ListOfBook.FindIndex(p => p.Title.ToLower() == vstup.ToLower());
        if (index != -1)
        {
            Console.WriteLine("Zadejte hodnocení.");
            ListOfBook[index].RatePublication(InputManage.StringToNumber(InputManage.LoadInput("")));
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
    //LIST
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfAudio.OrderBy(item => item.Title))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetToSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfAudio)
        {
            if (item.NameOfSerie.ToLower() == nameSerie.ToLower())
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
    public static void ChangeNameAuthor(string wrongTitle)
    {
        int index = ListOfAudio.FindIndex(p => p.Title.ToLower() == wrongTitle.ToLower());
         if (index != -1)
        {
            Console.WriteLine("Zadejte název knihy.");
            string title = InputManage.LoadInput("");
            Console.WriteLine("Zadejte jméno a přijmení autora.");
            string author = InputManage.LoadInput("");
            ListOfAudio[index].Rename(title, author);
            
        }
        else
        {
            Console.WriteLine("Zadaný titul nebyl nalezen.");
        }
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
    public static List<Publication> GetToSerie(string nameSerie)
    {
        List<Publication> serie = [];
        foreach (var item in ListOfWish)
        {
            if (item.NameOfSerie.ToLower() == nameSerie.ToLower())
                {
                    serie.Add(item);
                }
        }
        return serie;
    }

    public static void NewBuy(string title)
    {
        int index = ListOfWish.FindIndex(p => p.Title.ToLower() == title.ToLower());
        if (index != -1)
        {
            Console.WriteLine("Zadaný titul byl nalezen v seznamu přání. Zadejte prosím další informace: {genre};{theme};{pages};{readStatus};{rating}");
            List<string> info = new List<string>() { "genre", "theme", "pages", "readStatus", "rating" };
            List<string> hodnoty = [];

            foreach (var item in info)
            {
                Console.WriteLine($"Zadejte {item}:");
                hodnoty.Add(Console.ReadLine());
            }
            BookList.ListOfBook.Add(new Book("book", ListOfWish[index].Title, ListOfWish[index].Author, ListOfWish[index].NameOfSerie, ListOfWish[index].NumberOfBookInSerie, InputManage.LoadInput("genre"), InputManage.LoadInput("theme"), InputManage.StringToNumber(InputManage.LoadInput("pages")), InputManage.StringToBoolean(InputManage.LoadInput("readStatus")), InputManage.StringToNumberOrNull(InputManage.LoadInput("rating"), "rating")));
            ListOfWish.RemoveAt(index);
            Console.WriteLine("Kniha byla přidána do knihovny a odstraněna ze seznamu přání.");
        }
        else
        {
            Console.WriteLine("Zadaný titul nebyl nalezen v seznamu přání. Zadejte knihu přes hlavní menu 1 - přidat publikaci.");
        }
        }
        public static void ChangeNameAuthor(string wrongTitle)
        {
        int index = ListOfWish.FindIndex(p => p.Title.ToLower() == wrongTitle.ToLower());
        if (index != -1)
        {
            Console.WriteLine("Zadejte název knihy.");
            string title = InputManage.LoadInput("");
            Console.WriteLine("Zadejte jméno a přijmení autora.");
            string author = InputManage.LoadInput("");
            ListOfWish[index].Rename(title, author);

        }
        else
        {
            Console.WriteLine("Zadaný titul nebyl nalezen.");
        }
        }
    }

class Serie
{
    public static void GetFullSerie(string name)
    {
        List<Publication> bookSerie = BookList.GetToSerie(name).Concat(AudioList.GetToSerie(name)).Concat(WishList.GetToSerie(name)).ToList();
        if (bookSerie.Count() > 0)
        {
            Console.WriteLine($"Serie {name} obsahuje tyto tituly:");
            foreach (var item in bookSerie.OrderBy(i => i.NumberOfBookInSerie))
            {
                Console.WriteLine((item.Medium == "book" || item.Medium == "audio") ? $"{item.Title}, díl {item.NumberOfBookInSerie}, zakoupeno" : $"{item.Title}, díl {item.NumberOfBookInSerie}");
            }
        }
        else
        {
            Console.WriteLine("Zadaná serie nebyla nalezena.");
        }
    }
}


