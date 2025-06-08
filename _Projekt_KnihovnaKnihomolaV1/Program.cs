//třída knihovna obsahující seznam knížek v ní
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;

namespace _Projekt_KnihovnaKnihomolaV1;

internal class Program
{
    private static void Main(string[] args)
    {
        //načtení knihovny a vytvoření listů
        Console.WriteLine("Vaše knihovna se načítá...");
        FileManage.OpenFile();
        Console.WriteLine("Vítejte ve Vaší domácí knihovně pro knihomola!!!");
        while (true)
        {
            Console.WriteLine("Vyberte následující akce dle přiřazených čísel.");
            Console.WriteLine("1 - přidat publikaci, 2 - seznamy publikací, 3 - vyhledat, 4 - statistika, 5 - úprava knihovny, 6 - ukončení programu.");
            switch (StringToNumber(LoadInput()))
            {
                case 1: //ADD to new book
                    Console.WriteLine("Přejete si přidat\n1 - novou knihu, 2 - novou audioknihu, 3 - knihu do edičního plánu, 4 - do seznamu přání, 5 - zpět.");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://přidání do knihovny
                            Console.WriteLine("Zadejte novou knihu ve formátu:\n[title];[author];[nameOfSerie];[numberOfBookInSerie];[genre];[theme];[pages];[readStatus];[rating]");
                            GetNewPublication($"book;{LoadInput()}");
                            break;
                        case 2://přidání do knihovny
                            Console.WriteLine("Zadejte novou audioknihu ve formátu:\n[title];[author];[nameOfSerie];[numberOfBookInSerie];[genre];[theme];[runTime];[readStatus];[rating]");
                            GetNewPublication($"audio;{LoadInput()}");
                            break;
                        case 3://přidání do edičního plánu
                            Console.WriteLine("Kniha do edičního plánu:\n[title];[author];[nameOfSerie];[numberOfBookInSerie];[dateTimeRealese]");
                            GetNewPublication($"inPress;{LoadInput()}");
                            break;
                        case 4:
                            Console.WriteLine("Kniha na seznam přání:\n[title];[author];[nameOfSerie];[numberOfBookInSerie]");
                            GetNewPublication($"wish;{LoadInput()}");
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.");
                            Console.WriteLine("Přejete si přidat knihu do\n1 - novou knihu, 2 - novou audioknihu, 3 - knihu do edičního plánu, 4 - do seznamu přání, 5 - zpět.");
                            break;
                    }
                    break;

                case 2://LIST
                    Console.WriteLine("Zadejte jaký seznam chcete zobrazit.\n1 - abecední seznam všech publikací v knihovně, 2 - seznam knih serii, 3 - ediční plán, 4 - seznam přání, 5 - zpět.");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://abecední seznam
                            Console.WriteLine("Abecední seznam knih:");
                            BookList.GetListOfBooks();
                            Console.WriteLine("Abecední seznam audio knih:");
                            AudioList.GetListOfBooks();
                            break;
                        case 2://seznam knih v serii
                            Console.WriteLine("Zadejte heslo či celý název serie, kterou si přejete zobrazit:");
                            string inputSerie = LoadInput();
                            var list = BookList.GetSerie(inputSerie).Concat(AudioList.GetSerie(inputSerie)).Concat(WishList.GetSerie(inputSerie)).Concat(PublishingSheduleList.GetSerie(inputSerie));
                            Console.WriteLine($"Serie {inputSerie} obsahuje tyto tituly:");
                            foreach (var item in list.OrderBy(i => i.NumberOfBookInSerie))
                            {
                                if (item.Medium == "book" || item.Medium == "audio" )
                                {
                                    Console.WriteLine($"{item.Title}, díl {item.NumberOfBookInSerie}, zakoupeno");
                                }
                                else
                                {
                                    Console.WriteLine($"{item.Title}, díl {item.NumberOfBookInSerie}");
                                }
                            }
                            break;
                        case 3://ediční plán
                            PublishingSheduleList.GetListOfBooks();
                            break;
                        case 4://seznam přání
                            WishList.GetListOfBooks();
                            break;
                        case 5://zpět
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.");
                            Console.WriteLine("Zadejte jaký seznam chcete zobrazit.\n1 - abecední seznam knih, 2 - abecední seznam audii, 3 - ediční plán, 4 - seznam přání, 5 - zpět.");
                            break;
                    }
                    break;
                case 3://FIND
                    Console.WriteLine("Zadejte, co si přejete hledat: 1 - dle hesla v titulu knihy, 2 - dle přijmení autora, 3 - dle žánru, 4 - dle tématu, 5 - dle rozsahu, 6 - zpět.");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://heslo
                            //kod
                            break;
                        case 2://autor
                            //kod
                            break;
                        case 3://žánr
                            //kod
                            break;
                        case 4://téma
                            //kod
                            break;
                        case 5://rozsah
                               //kod
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.");
                            Console.WriteLine("Zadejte dle čeho chcete hledat.\n1 - dle hesla v titulu knihy, 2 - dle přijmení autora, 3 - dle žánru, 4 - dle tématu, 5 - dle rozsahu, 6 - zpět.");
                            break;
                    }
                    break;
                case 4://STATS
                    Console.WriteLine("Zadejte, jaká data Vás zajímají. 1 - konrétní autor, 2 - žánr, 3 - nejlépe hodnocené knihy, 4 - nejhůře hodnocené knihy, 5 - zpět.");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://autor
                            //kod
                            break;
                        case 2://žánr
                            //kod
                            break;
                        case 3://nejlepší
                            //kod
                            break;
                        case 4://nejhorší
                            //kod
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.");
                            Console.WriteLine("Zadejte jaká statistika Vás zajímá.\n1 - konrétní autor, 2 - žánr, 3 - nejlépe hodnocené knihy, 4 - nejhůře hodnocené knihy, 5 - zpět.");
                            break;
                    }
                    break;
                case 5://MANAGE
                       //kod
                    break;
                case 6://END
                    Console.WriteLine("Vaše knihovna se loučí!");
                    FileManage.ListToFile();
                    return;
                default:
                    Console.WriteLine("Zadali jste špatné číslo akce. Zvolte: 1 - přidat publikaci, 2 - seznamy publikací, 3 - vyhledat, 4 - statistika, 5 - úprava knihovny, 6 - ukončení programu.");
                    break;
            }
        }
    }

    //metody
    class FileManage
    {
        public static string Adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library");
        public static string BooksCSV = Path.Combine(Adresar, "listOfBooks.csv");
        public static string AudiosCSV = Path.Combine(Adresar, "listOfAudio.csv");
        public static string WishlistCSV = Path.Combine(Adresar, "wishlist.csv");
        public static string PublishCSV = Path.Combine(Adresar, "publishingShedule.csv");

        public static void OpenFile()
        {
            List<string> soubory = new List<string>() { BooksCSV, AudiosCSV, WishlistCSV, PublishCSV };
            foreach (var item in soubory)
            {
                if (File.Exists(item))
                {
                    FileToList(item);
                }
                else
                {
                    Console.WriteLine($"Soubor {item} nenalezen.");
                }
            }
        }

        public static void FileToList(string fileBookcase)//převod csv na listy
        {
            var nacteneZeSouboru = File.ReadAllLines(fileBookcase);
            foreach (var item in nacteneZeSouboru)
            {
                GetNewPublication(item);
            }
        }
        public static void ListToFile()
        {
            Directory.CreateDirectory(Adresar);
            var knihy = BookList.ListOfBook.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.Pages}; {Book.ReadStatus}; {Book.Rating}");
            File.AppendAllLines(Path.Combine(Adresar, "listOfBooks.csv"), knihy);

            var audio = AudioList.ListOfAudio.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.RunTime}; {Book.ReadStatus}; {Book.Rating}");
            File.AppendAllLines(Path.Combine(Adresar, "listOfAudio.csv"), audio);

            var prani = WishList.ListOfWish.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}");
            File.AppendAllLines(Path.Combine(Adresar, "wishlist.csv"), prani);

            var edice = PublishingSheduleList.ListOfPublishingShedule.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.DateRealease}");
            File.AppendAllLines(Path.Combine(Adresar, "publishingShedule.csv"), knihy);
        }
    }

    

    public static void GetNewPublication(string item)//vytvoření nového objektu
        {
            string[] inputParts = LoadInputToParts(item);
            switch (inputParts[0])
            {
                case "book":
                    //Book(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5string genre, 6string theme, 7int pages, 8bool readStatus, 9int rating) 
                    Book kniha = new Book(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumber(inputParts[4].Trim()), inputParts[5].Trim(), inputParts[6].Trim(), StringToNumber(inputParts[7].Trim()), StringToBoolean(inputParts[8].Trim()), StringToNumber(inputParts[9].Trim()));
                    BookList.AddToList(kniha);
                    break;
                case "audio":
                    //AudioBook (0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5string genre, 6string theme, 7TimeSpan runTime, 8bool readStatus, 9int rating)
                    AudioBook audio = new AudioBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumber(inputParts[4].Trim()), inputParts[5].Trim(), inputParts[6].Trim(), StringToTime(inputParts[7].Trim()), StringToBoolean(inputParts[8].Trim()), StringToNumber(inputParts[9].Trim()));
                    AudioList.AddToList(audio);
                    break;
                case "inPress":
                    //BookInPress(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5DateTime dateRealease)
                    Publication inPress = new InPressBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumber(inputParts[4].Trim()), StringToDate(inputParts[5].Trim()));
                    PublishingSheduleList.AddToList((InPressBook)inPress);
                    break;
                case "wish":
                    //WishListBook(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie)
                    Publication wish = new WishListBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumber(inputParts[4].Trim()));
                    WishList.AddToList((WishListBook)wish);
                    break;
                default:
                    Console.WriteLine($"Položka ({item}) nebyla správně načtena.");
                    break;
            }
        }

    public static string[] LoadInputToParts(string input)//metoda pro rozdělení načteného vstupu na jednotlivé části, v případě ADD/FIND kontroluje, zda zadání bylo kompletní
    {
        string[] inputParts = input.Split(";");
        if (inputParts[0].ToLower() == "book" || inputParts[0].ToLower() == "audio")
        {
            while (inputParts.Length != 10)
            {
                Console.WriteLine($"You not enter all paramets. Try it again in format: string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, string genre, string theme, TimeSpan runTime, bool readStatus, int rating");
                input = LoadInput();
                inputParts = input.Split(";");
            }
            return inputParts;
        }

        if (inputParts[0].ToLower() == "wish")
        {
            while (inputParts.Length != 5)
            {
                Console.WriteLine($"You not enter all paramets. Try it again in format: string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie.");
                input = LoadInput();
                inputParts = input.Split(";");
            }
            return inputParts;
        }
        if (inputParts[0].ToLower() == "inpress")
        {
            while (inputParts.Length != 6)
            {
                Console.WriteLine($"You not enter all paramets. Try it again in format: string medium, string title, string author, string nameOfSerie, int numberOfBookInSerie, DateTime dateRealease.");
                input = LoadInput();
                inputParts = input.Split(";");
            }
            return inputParts;
        }

        else
        {
            return inputParts;
        }
    }

    public static string LoadInput()//načtení a ověření vstupu, že se nejedná o prázdný řetězec či řetezec s hodnotou null
    {
        string? input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input) == true)
        {
            Console.WriteLine("Please enter some input.");
            input = Console.ReadLine();
        }
        return input;
    }
    
    //type conversion
     public static DateTime StringToDate(string date)//parsování datového typu
    {
        DateTime dateValue;
        while (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue) == false)
        {
            Console.WriteLine("Date format is not correct. Use yyyy-MM-dd format.");
            date = LoadInput();
        }
        return dateValue;
    }

    public static TimeSpan StringToTime(string time)//parsování časového typu
    {
        TimeSpan timeValue;
        while (TimeSpan.TryParseExact(time, "h\\:mm\\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out timeValue) == false)
        {
            Console.WriteLine("Time format is not correct. Use h\\:mm\\:ss format.");
            time = LoadInput();
        }
        return timeValue;
    }

    public static int StringToNumber(string number)//parsování vstup obsahujících celočíselnou hodnotu
    {
        int pageNumber;
        while (int.TryParse(number, out pageNumber) == false)
        {
            Console.WriteLine("Pages must be integer.");
            number = LoadInput();
        }
        return pageNumber;
    }

    public static bool StringToBoolean(string value)//parsování vstup obsahujícího pravdivostní hodnotu
    {
        List<string> values = new List<string>() { "false", "true" };
        while (!values.Contains(value.ToLower()))
        {
            Console.WriteLine("Enter false or true value.");
            value = LoadInput();
        }

        if (value.ToLower() == "false")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

        