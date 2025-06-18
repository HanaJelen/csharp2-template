using System;

namespace _Projekt_KnihovnaKnihomolaV1;

class FileManage
{
    public static string Adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library");
    public static string BooksCSV = Path.Combine(Adresar, "listOfBooks.csv");
    public static string AudiosCSV = Path.Combine(Adresar, "listOfAudio.csv");
    public static string WishlistCSV = Path.Combine(Adresar, "wishlist.csv");
    public static List<string> nacteneZeSouboru = [];

    public static void OpenFile()
    {
        //List<string> soubory = new List<string>() { BooksCSV, AudiosCSV, WishlistCSV };
        //oreach (var soubor in soubory)
        //{
            if (File.Exists(BooksCSV))
            {
                FileToList(BooksCSV);
            }
            else
            {
                Console.WriteLine($"Soubor {BooksCSV} nenalezen.");
                File.Create(BooksCSV);
                Console.WriteLine($"Nový soubor {BooksCSV} byl vytvořen.");
            }
        //}
    }

    public static void FileToList(string soubor)//převod csv na listy
    {
        using (StreamReader reader = new StreamReader(soubor))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                nacteneZeSouboru.Add(line);
            }
            reader.Close();
        }


        foreach (var item in nacteneZeSouboru)
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
                if (nacteneZeSouboru.Contains(item))
                {
                    break;
                }
                else
                {
                    writer.WriteLine(item);
                }
            }
            writer.Close();
        }
    }
}

            /*
            var vsechnyAudio = AudioList.ListOfAudio.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.RunTime}; {Book.ReadStatus}; {Book.Rating}");
            var nacteneAudioZeSouboru = File.ReadAllLines(AudiosCSV);
            List<string> noveAudio = [];

            foreach (var item in vsechnyAudio)
            {
            if (!nacteneAudioZeSouboru.Contains(item))
            {
                noveAudio.Add(item);
            }
            }
            File.AppendAllLines(AudiosCSV, noveAudio);

            var prani = WishList.ListOfWish.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}");
            var nacteneWishZeSouboru = File.ReadAllLines(WishlistCSV);
            List<string> noveWish = [];

            foreach (var item in vsechnyAudio)
            {
            if (!nacteneWishZeSouboru.Contains(item))
            {
                noveWish.Add(item);
            }
            }
            File.AppendAllLines(AudiosCSV, noveWish);
        }*/