using System;
using System.Runtime.CompilerServices;

namespace _Projekt_KnihovnaKnihomolaV1;

public class Bookcase
{
    public string Name;
    public List<Publication> ListOfBookcase;

    public Bookcase(string name)
    {
        Name = name;
        ListOfBookcase = [];
    }

    //method ADD - add book to bookcase
    public void AddToList(Publication publication)
    {
        ListOfBookcase.Add(publication);
    }
    //metoda LIST - all books in bookcase in alphabet order
    public void GetListOfBooks()
    {
        foreach (var item in ListOfBookcase.OrderBy(item => item.Title))
        //item in listofbokcase.OfType<NonFiction>()
        {
            if (item is NonFiction)
            {
                //NonFiction kniha = (NonFiction)item;
                item.GetInfo();
            }
            else if (item is Fiction)
            {
                //Fiction kniha = (Fiction)item;
                item.GetInfo();
            }
            else if (item is AudioBook)
            {
                //AudioBook kniha = (AudioBook)item;
                item.GetInfo();
            }
        }
    }
    //metoda FIND
    public void GetTitle(string world)//book
    {
        Console.WriteLine($"""Výsledky hledání pro "{world}":""");
        foreach (var item in ListOfBookcase)
        {
            if (item.Title.ToLower().Contains(world.ToLower()))
            {
                Console.WriteLine($" - {item.Title}");
            }
        }
    }
    public void GetAuthor(string name)//author
    {
        Console.WriteLine($"""Hledáte autora s přijmením "{name}":""");
        foreach (var item in ListOfBookcase)
            if (item.Author.ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine($" - {item.Author}");
            }
    }
}
public class Wish
{
    public List<WishListBook> ListOfWish;

    public Wish()
    {
        ListOfWish = [];
    }

    //method ADD - add book to wishlist
    public void AddToList(WishListBook publication)
    {
        ListOfWish.Add(publication);
    }
    //metoda LIST - all books in bookcase in alphabet order
    public void GetListOfWish()
    {
        foreach (var item in ListOfWish.OrderBy(item => item.DateRealease))
        {
            item.GetInfo();
        }
    }
}


public class Series
{
    public Dictionary<string, Serie> DictSeries = [];
    public void AddToSerie(string nameOfSerie, Publication book)
    {
        if (!DictSeries.ContainsKey(nameOfSerie))
        {
            var serie = new Serie();
            serie.AddToSerie(book);
            DictSeries.Add(nameOfSerie, serie);
        }
        else
        {
            DictSeries[nameOfSerie].AddToSerie(book);
        }
    }
    //method FIND - find the serie
    public void GetSerie(string nameOfSerie)
    {
        if (DictSeries.ContainsKey(nameOfSerie))
        {
            Console.WriteLine($"""Serie s názvem "{nameOfSerie}" obsahuje tyto knihy:""");
            DictSeries[nameOfSerie].GetListOfBooksInSerie();
        }
        else
        {
            Console.WriteLine("Serie is not found.");
        }
    }


    public class Serie
    {
        public List<Publication> ListOfBooksInSerie;

        public Serie()
        {
            ListOfBooksInSerie = [];
        }

        //method ADD - add book to serie
        public void AddToSerie(Publication publication)
        {
            ListOfBooksInSerie.Add(publication);
        }
        //metod LIST of books in serie for FIND function
        public void GetListOfBooksInSerie()
        {
            foreach (var item in ListOfBooksInSerie.OrderBy(item => item.NumberOfBookInSerie))
            {
                item.GetInfo();
            }
        }

    }
}

