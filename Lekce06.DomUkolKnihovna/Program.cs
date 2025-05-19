using System.Collections.Specialized;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Lekce06.DomUkolKnihovna;

internal class Program
{
    private static void Main(string[] args)
    {
        Book.ListOfBooks = new List<Book>();
        Book.Statistics = new Dictionary<DateTime, int>();

        while (true)
        {
            Console.WriteLine("Use format ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]:");

            string[] prvkyVstupu = LoadInputToParts();

            switch (prvkyVstupu[0].ToUpper().Trim())
            {
                case "ADD":
                    Book.AddToList(prvkyVstupu[1].Trim(), prvkyVstupu[2].Trim(), StringToDate(prvkyVstupu[3].Trim()), StringToNumber(prvkyVstupu[4].Trim()));
                    break;

                case "LIST":
                    Book.GetListOfBooks();
                    break;
                case "STATS":
                    Book.GetStatistics();
                    break;
                case "FIND":
                    Book.GetTitle(prvkyVstupu[1]);
                    break;
                case "END":
                    return;
                default:
                    Console.WriteLine("Format is not correct. Check that text contains ADD, LIST, STATS or FIND. Support format: ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]");
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

    public static string[] LoadInputToParts()//metoda pro rozdělení načteného vstupu na jednotlivé části, v případě ADD/FIND kontroluje, zda zadání bylo kompletní
    {
        string input = LoadInput();
        string[] inputParts = input.Split(";");
        if (inputParts[0] == "ADD")
        {
            while (inputParts.Length != 5)
            {
                Console.WriteLine($"You not enter all paramets. Try it again in format ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran].");
                input = LoadInput();
                inputParts = input.Split(";");
            }
            return inputParts;
        }
        if (inputParts[0] == "FIND")
        {
            while (inputParts.Length != 2)
            {
                Console.WriteLine($"You not enter all paramets. Try it again in format FIND;[world].");
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