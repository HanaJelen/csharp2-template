using System;
using System.Runtime.CompilerServices;

namespace _Projekt_KnihovnaKnihomolaV1;

class BookList
{
    public static List<Book> ListOfBook = [];

    public static void AddToList(Book publication)
    {
        ListOfBook.Add(publication);
    }
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfBook.OrderBy(item => item.Title))
        //item in listofbokcase.OfType<Book>()
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List < Publication > serie = [];
        foreach (var item in ListOfBook)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        //var vyber = from v in ListOfBook where v.NameOfSerie.Contains(nameSerie) select ( v.Title, v.Author, v.NumberOfBookInSerie);
        return serie;
    }
}

class AudioList
{
    public static List<AudioBook> ListOfAudio = [];

    public static void AddToList(AudioBook publication)
    {
        ListOfAudio.Add(publication);
    }
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfAudio.OrderBy(item => item.Title))
        //item in listofbokcase.OfType<Book>()
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List < Publication > serie = [];
        foreach (var item in ListOfAudio)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        //var vyber = from v in ListOfAudio where v.NameOfSerie.Contains(nameSerie) select ( v.Title, v.Author, v.NumberOfBookInSerie);
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
        List < Publication > serie = [];
        foreach (var item in ListOfWish)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        //var vyber = from v in ListOfWish where v.NameOfSerie.Contains(nameSerie) select ( v.Title, v.Author, v.NumberOfBookInSerie);
        return serie;
    }
}

class PublishingSheduleList
{
    public static List<InPressBook> ListOfPublishingShedule = [];

    public static void AddToList(InPressBook publication)
    {
        ListOfPublishingShedule.Add(publication);
    }
    public static void GetListOfBooks()
    {
        foreach (var item in ListOfPublishingShedule.OrderBy(item => item.DateRealease))
        {
            item.GetInfo();
        }
    }
    public static List<Publication> GetSerie(string nameSerie)
    {
        List < Publication > serie = [];
        foreach (var item in ListOfPublishingShedule)
        {
            if (item.NameOfSerie.ToLower().Contains(nameSerie.ToLower()))
            {
                serie.Add(item);
            }
        }
        //var vyber = from v in ListOfPublishingShedule where v.NameOfSerie.Contains(nameSerie) select ( v.Title, v.Author, v.NumberOfBookInSerie);
        return serie;
    }
}
