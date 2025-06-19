using System;
using System.Collections;

namespace _Projekt_KnihovnaKnihomolaV1;

static class FileManage
{
    public static string Adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library");
    public static string BooksCSV = Path.Combine(Adresar, "listOfBooks.csv");
    public static string AudiosCSV = Path.Combine(Adresar, "listOfAudio.csv");
    public static string WishlistCSV = Path.Combine(Adresar, "wishlist.csv");
    public static List<string> nacteneZeSouboruKnihy = [];
    public static List<string> nacteneZeSouboruAudio = [];
    public static List<string> nacteneZeSouboruWish = [];


    public static void OpenFile(string soubor, List<string> seznam)
    {
        if (Directory.Exists(Adresar))
        {
            if (File.Exists(soubor))
            {
                using (StreamReader reader = new StreamReader(soubor))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        seznam.Add(line);
                    }
                    reader.Close();
                }
                FileToList(seznam);
            }
            else
            {
                Console.WriteLine($"Soubor {BooksCSV} nenalezen.");
                File.Create(BooksCSV);
                Console.WriteLine($"Nový soubor {BooksCSV} byl vytvořen.");
            }
        }
        else
        {
            Console.WriteLine($"Adresář {Adresar} nenalezen.");
            Directory.CreateDirectory(Adresar);
            Console.WriteLine($"Nový adresář {Adresar} byl vytvořen.");
        }
    }

    public static void FileToList(List<string> seznam)
    {
        foreach (var item in seznam)
        {
            string[] inputParts = InputManage.LoadInputToParts(item);
            switch (inputParts[0])
            {
                case "book":
                    Book kniha = new Book(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), InputManage.StringToNumberOrNull(inputParts[4].Trim(), "numberOfBookInSerie"), inputParts[5].Trim(), inputParts[6].Trim(), InputManage.StringToNumber(inputParts[7].Trim()), InputManage.StringToBoolean(inputParts[8].Trim()), InputManage.StringToNumberOrNull(inputParts[9].Trim(), "dateRelease"));
                    BookList.ListOfBook.Add(kniha);
                    break;
                case "audio":
                    AudioBook audio = new AudioBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), InputManage.StringToNumberOrNull(inputParts[4].Trim(), "numberOfBookInSerie"), inputParts[5].Trim(), inputParts[6].Trim(), InputManage.StringToTime(inputParts[7].Trim()), InputManage.StringToBoolean(inputParts[8].Trim()), InputManage.StringToNumberOrNull(inputParts[9].Trim(), "dateRelease"));
                    AudioList.ListOfAudio.Add(audio);
                    break;
                case "wish":
                    Publication wish = new WishListBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), InputManage.StringToNumber(inputParts[4].Trim()), InputManage.StringToDate(inputParts[5]));
                    WishList.ListOfWish.Add((WishListBook)wish);
                    break;
                default:
                    Console.WriteLine($"Položka ({item}) nebyla správně načtena.");
                    break;
            }
        }
    }

    public static void ListToFile()

    {
        var vsechnyKnihy = BookList.ListOfBook.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.Pages}; {Book.ReadStatus}; {Book.Rating}");

        using (StreamWriter writer = new StreamWriter(BooksCSV, append: false))
        {
            foreach (var item in vsechnyKnihy)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        var vsechnyAudio = AudioList.ListOfAudio.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.RunTime.ToString("h\\:mm\\:ss")}; {Book.ReadStatus}; {Book.Rating}");
        using (StreamWriter writer = new StreamWriter(AudiosCSV, append: false))
        {
            foreach (var item in vsechnyAudio)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

    
        var vsechnyPrani = WishList.ListOfWish.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.DateRealease}");
        using (StreamWriter writer = new StreamWriter(WishlistCSV, append: false))
        {
            foreach (var item in vsechnyPrani)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }
    }
}
