//třída knihovna obsahující seznam knížek v ní
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace _Projekt_KnihovnaKnihomolaV1;

internal class Program
    {
        private static void Main(string[] args)
        {
            var knihovna = new Bookcase("Knihovna01");
            var slovnik = new Series();
            var wishlist = new Wish();

        while (true)
        {
            Console.WriteLine("Please choose what you want: 1 - ADD, 2 - LIST, 3 - FIND, 4 - STATISTICS, 5 - END");
            
            switch (StringToNumber(LoadInput()))
            {
                case 1: //ADD to new book
                    Console.WriteLine("Please choose what you want to add: 1 - FICTION, 2 - NON-FICTION, 3 - AUDIO, 4 - WISHBOOK");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://Fiction
                            Console.WriteLine("Please enter input in format:\n[title];[author];[numberOfBookInSerie];[pages];[gendre];[readStatus];[rating]");
                            string[] prvkyVstupu = LoadInputToParts(7);
                            Publication kniha = new Fiction(prvkyVstupu[0].Trim(), prvkyVstupu[1].Trim(), StringToNumber(prvkyVstupu[2].Trim()), StringToNumber(prvkyVstupu[3].Trim()), prvkyVstupu[4].Trim(), StringToBoolean(prvkyVstupu[5].Trim()), StringToNumber(prvkyVstupu[6].Trim()));
                            knihovna.AddToList(kniha);
                            if (StringToNumber(prvkyVstupu[2].Trim()) > 0)
                            {
                                Console.WriteLine("Kniha je součástí serie. Prosím zadejte název serie pro její uložení.");
                                string name = LoadInput();
                                slovnik.AddToSerie(name, kniha);
                            }
                            break;
                        case 2://non-fiction
                            Console.WriteLine("Please enter input in format:\n[title];[author];[numberOfBookInSerie];[pages];[theme];[readStatus];[rating]");
                            prvkyVstupu = LoadInputToParts(7);
                            kniha = new Fiction(prvkyVstupu[0].Trim(), prvkyVstupu[1].Trim(), StringToNumber(prvkyVstupu[2].Trim()), StringToNumber(prvkyVstupu[3].Trim()), prvkyVstupu[4].Trim(), StringToBoolean(prvkyVstupu[5].Trim()), StringToNumber(prvkyVstupu[6].Trim()));
                            knihovna.AddToList(kniha);
                            if (StringToNumber(prvkyVstupu[2].Trim()) > 0)
                            {
                                Console.WriteLine("Kniha je součástí serie. Prosím zadejte název serie pro její uložení.");
                                string name = LoadInput();
                                slovnik.AddToSerie(name, kniha);
                            }
                            break;
                        case 3://audio
                            Console.WriteLine("Please enter input in format:\n[title];[author];[numberOfBookInSerie];[tunTime];[gendre];[readStatus];[rating]");
                            prvkyVstupu = LoadInputToParts(7);
                            kniha = new AudioBook(prvkyVstupu[0].Trim(), prvkyVstupu[1].Trim(), StringToNumber(prvkyVstupu[2].Trim()), StringToTime(prvkyVstupu[3].Trim()), prvkyVstupu[4].Trim(), StringToBoolean(prvkyVstupu[5].Trim()), StringToNumber(prvkyVstupu[6].Trim()));
                            knihovna.AddToList(kniha);
                            if (StringToNumber(prvkyVstupu[2].Trim()) > 0)
                            {
                                Console.WriteLine("Audio je součástí serie. Prosím zadejte název serie pro její uložení.");
                                string name = LoadInput();
                                slovnik.AddToSerie(name, kniha);
                            }
                            break;
                        case 4://wish
                            Console.WriteLine("Please enter input in format:\n[title];[author];[numberOfBookInSerie];[dateRealease]");
                            prvkyVstupu = LoadInputToParts(4);
                            kniha = new WishListBook(prvkyVstupu[0].Trim(), prvkyVstupu[1].Trim(), StringToNumber(prvkyVstupu[2].Trim()), StringToDate(prvkyVstupu[3].Trim()));
                            wishlist.AddToList((WishListBook)kniha);
                            if (StringToNumber(prvkyVstupu[2].Trim()) > 0)
                            {
                                Console.WriteLine("Kniha je součástí serie. Prosím zadejte název serie pro její uložení.");
                                string name = LoadInput();
                                slovnik.AddToSerie(name, kniha);
                            }
                            break;
                            default:
                            Console.WriteLine("You enter wrong number. Choose 1-4.\n1 - FICTION, 2 - NON-FICTION, 3 - AUDIO, 4 - WISHBOOK");
                            break;
                    }
                    break;
            
                case 2://LIST
                    Console.WriteLine("Please choose what you want: 1 - LIST OF PURCHASED IN YOU LIBRARY, 2 - WISHLIST");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://alphabet list of books in library
                            knihovna.GetListOfBooks();
                            break;
                        case 2://wishlist
                            wishlist.GetListOfWish();
                            break;
                        default:
                            Console.WriteLine("You enter wrong number. Choose 1-2.\n1 - LIST OF PURCHASED IN YOU LIBRARY, 2 - WISHLIST");
                            break;
                    }
                    break;
                case 3://FIND
                    Console.WriteLine("Please choose what you want: 1 - FIND the book, 2 - FIND the author, 3 - FIND the serie");
                    switch (StringToNumber(LoadInput()))
                    {
                        case 1://find a book
                            Console.WriteLine("Please enter the title or the world in it:");
                            knihovna.GetTitle(LoadInput());
                            break;
                        case 2://find an author
                            Console.WriteLine("Please input the last name of the author:");
                            knihovna.GetAuthor(LoadInput());
                            break;
                        case 3://find a serie
                            Console.WriteLine("Please enter name of series:");
                            slovnik.GetSerie(LoadInput());
                            break;
                        default:
                            Console.WriteLine("You enter wrong number. Choose 1-3.\n1 - FIND the book, 2 - FIND the author, 3 - FIND the serie");
                            break;
                    }
                    break;
                case 4://STATS
                    //Book.GetStatistics();
                    break;
                case 5://END
                    return;
                default:
                    Console.WriteLine("You enter wrong number. Choose 1-5.");
                    break;
            }

        }
    }

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

    public static string[] LoadInputToParts(int number)//metoda pro rozdělení načteného vstupu na jednotlivé části, v případě ADD/FIND kontroluje, zda zadání bylo kompletní
    {
        string input = LoadInput();
        int numberOfParts = number;
        string[] inputParts = input.Split(";");
        if (numberOfParts == 7)
            {
                while (inputParts.Length != 7)
                {
                    Console.WriteLine($"You not enter all paramets. Try it again in format [title];[author];[numberOfBookInSerie];[pages/tunTime];[gendre/theme];[readStatus];[rating]");
                    input = LoadInput();
                    inputParts = input.Split(";");
                }
                return inputParts;
            }

        if (numberOfParts == 4)
            {
                while (inputParts.Length !=4)
                {
                    Console.WriteLine($"You not enter all paramets. Try it again in format [title];[author];[numberOfBookInSerie];[dateRealease].");
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
}