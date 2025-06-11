using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;

namespace _Projekt_KnihovnaKnihomolaV1;

public class InputManage
{
    public static void GetNewPublication(string item)//vytvoření nového objektu
    {
        string[] inputParts = LoadInputToParts(item);
        switch (inputParts[0])
        {
            case "book":
                //Book(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5string genre, 6string theme, 7int pages, 8bool readStatus, 9int rating) 
                Book kniha = new Book(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumberOrNull(inputParts[4].Trim()), inputParts[5].Trim(), inputParts[6].Trim(), StringToNumber(inputParts[7].Trim()), StringToBoolean(inputParts[8].Trim()), StringToNumberOrNull(inputParts[9].Trim()));
                BookList.AddToList(kniha);
                break;
            case "audio":
                //AudioBook (0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5string genre, 6string theme, 7TimeSpan runTime, 8bool readStatus, 9int rating)
                AudioBook audio = new AudioBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumberOrNull(inputParts[4].Trim()), inputParts[5].Trim(), inputParts[6].Trim(), StringToTime(inputParts[7].Trim()), StringToBoolean(inputParts[8].Trim()), StringToNumberOrNull(inputParts[9].Trim()));
                AudioList.AddToList(audio);
                break;
            case "wish":
                //WishListBook(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie)
                Publication wish = new WishListBook(inputParts[0].Trim(), inputParts[1].Trim(), inputParts[2].Trim(), inputParts[3].Trim(), StringToNumber(inputParts[4].Trim()), StringToDate(inputParts[5].Trim()));
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
            while (inputParts.Length != 6)
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
    public static DateTime? StringToDate(string date)//parsování datového typu
    {
        //DateTime dateValue;
        if (date == "null" || date == "")
        {
            return null;
        }
        else
        {
            DateTime dateValue;
            while (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue) == false)
            {
                Console.WriteLine("Date format is not correct. Use yyyy-MM-dd format.");
                date = LoadInput();
            }
            return dateValue;
        }
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

    public static int? StringToNumberOrNull(string number)//parsování vstup obsahujících celočíselnou hodnotu
    {
        if (number == "null" || number == "")
        {
            return null;
        }
        else
        {
            int pageNumber;
            while (int.TryParse(number, out pageNumber) == false)
            {
                Console.WriteLine("Pages must be integer.");
                number = LoadInput();
            }
            return pageNumber;
        }
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

