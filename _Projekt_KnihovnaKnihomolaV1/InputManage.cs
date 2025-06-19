using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;

namespace _Projekt_KnihovnaKnihomolaV1;

static class InputManage
{
    public static void GetNewPublication(int item)//vytvoření nového objektu
    {
        switch (item)
        {
            case 1:
                //Book(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie, 5string genre, 6string theme, 7int pages, 8bool readStatus, 9int rating) 
                BookList.ListOfBook.Add(new Book("book", LoadInput("title"), LoadInput("author"), LoadInput("nameOfSerie"), StringToNumberOrNull(LoadInput("numberOfBookInSerie"),"numberOfBookInSerie"), LoadInput("genre"), LoadInput("theme"), StringToNumber(LoadInput("pages")), StringToBoolean(LoadInput("readStatus")), StringToNumberOrNull(LoadInput("rating"), "rating")));
                break;
            case 2:
                AudioList.ListOfAudio.Add(new AudioBook("audio", LoadInput("title"),LoadInput("author"),LoadInput("nameOfSerie"),StringToNumberOrNull(LoadInput("numberOfBookInSerie"), "numberOfBookInSerie"),LoadInput("genre"),LoadInput("theme"),StringToTime(LoadInput("runTime")),StringToBoolean(LoadInput("readStatus")),StringToNumberOrNull(LoadInput("rating"), "rating")));
                break;
            case 3:
                //WishListBook(0string medium, 1string title, 2string author, 3string nameOfSerie, 4int numberOfBookInSerie)
                WishList.ListOfWish.Add(new WishListBook("wish", LoadInput("title"), LoadInput("author"), LoadInput("nameOfSerie"), StringToNumberOrNull(LoadInput("numberOfBookInSerie"), "numberOfBookInSerie"), StringToDate(LoadInput("dateRelease").Trim())));
                break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu. Zda chce knihu přidat:\n1 - novou knihu, 2 - novou audioknihu, 3 - do seznamu přání, 4 - zpět.");
                    break;
        }
    }
    public static string[] LoadInputToParts(string input)//metoda pro rozdělení načteného vstupu na jednotlivé části, v případě ADD/FIND kontroluje, zda zadání bylo kompletní
    {
        string[] inputParts = input.Split(";");
        
        return inputParts;
    }

    public static string LoadInput(string typeMessage)//načtení a ověření vstupu, že se nejedná o prázdný řetězec či řetezec s hodnotou null
    {
        switch (typeMessage)
        {
            case "title":
                Console.WriteLine($"Zadejte název knihy:");
                break;
            case "author":
                Console.WriteLine($"Zadejte jméno a přijmení autora:");
                break;
            case "nameOfSerie":
                Console.WriteLine($"Zadejte název serie, pokud kniha není součástí serie stiskněte enter:");
                break;
            case "numberOfBookInSerie":
                Console.WriteLine($"Zadejte pořadí knihy v serii, pokud kniha není součástí serie stiskněte enter:");
                break;
            case "genre":
                Console.WriteLine($"Zadejte žánr knihy:");
                break;
            case "theme":
                Console.WriteLine($"Zadejte hlavní téma knihy:");
                break;
            case "pages":
                Console.WriteLine($"Zadejte počet stran knihy:");
                break;
            case "runTime":
                Console.WriteLine($"Zadejte délku časové stopy:");
                break;
            case "readStatus":
                Console.WriteLine($"Knihu jste již přečetli - true nebo ještě ne - false:");
                break;
            case "rating":
                Console.WriteLine($"Zadejte hodnocení knihy, pokud jste knihu ještě nečetli zmačtněte enter:");
                break;
            case "dateRelease":
                Console.WriteLine($"Zadejte datum vydání, pokud je známo:");
                break;
            default:
                break;
        }
        string? input = Console.ReadLine();
        List<string> nullTypes = new List<string>() { "nameOfSerie", "numberOfBookInSerie", "rating", "dateRelease" };
        if (!nullTypes.Contains(typeMessage))
        {
            while (string.IsNullOrWhiteSpace(input) == true)
            {
                Console.WriteLine("Nezadali jste žádný text.");
                input = Console.ReadLine();
            }
            return input;
        }
        return input;
    }
    public static DateOnly? StringToDate(string date)//parsování datového typu
    {
        date = date.Trim();
        DateOnly dateValue;
        if (!string.IsNullOrWhiteSpace(date))
        {
            while (DateOnly.TryParseExact(date, "dd.MM.yyyy", out dateValue) == false)
            {
                Console.WriteLine("Datum není ve správném formátu. Zadejte ve formátu: dd.MM.yyyy");
                date = LoadInput("dateRelease");
            }
            return dateValue;
        }
        else
        {
            return null;
        }
    }

    public static TimeSpan StringToTime(string time)//parsování časového typu
    {
        time = time.Trim();
        TimeSpan timeValue;
        while (TimeSpan.TryParseExact(time, "h\\:mm\\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out timeValue) == false)
        {
            Console.WriteLine("Čas nebyl zadán ve správném formátu. Použijte formát: h\\:mm\\:ss");
            time = LoadInput("runTime");
        }
        return timeValue;
    }

    public static int? StringToNumberOrNull(string number, string type)//parsování vstup obsahujících celočíselnou hodnotu
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            return null;
        }
        else
        {
            number = number.Trim();
            int pageNumber;
            while (int.TryParse(number, out pageNumber) == false)
            {
                Console.WriteLine("Je potřeba zadat celé číslo.");
                number = LoadInput(type);
            }
            return pageNumber;
        }
    }
    public static int StringToNumber(string number)//parsování vstup obsahujících celočíselnou hodnotu
    {
        number = number.Trim();
        int pageNumber;
        while (int.TryParse(number, out pageNumber) == false)
        {
            Console.WriteLine("Zadejte celé kladné číslo.");
            number = LoadInput("pages");
        }
        return pageNumber;
    }

    public static bool StringToBoolean(string value)//parsování vstup obsahujícího pravdivostní hodnotu
    {
        value = value.Trim();
        List<string> values = new List<string>() { "false", "true" };
        while (!values.Contains(value.ToLower()))
        {
            Console.WriteLine("Zadejte pravdivostní hodnotu.");
            value = LoadInput("readStatus");
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

