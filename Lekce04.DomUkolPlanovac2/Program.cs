
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Event
{
    public string Name{ get; set; }
    public DateTime Date { get; set; }
    public static List<Event> ListOfEvents;
    public static Dictionary<DateTime, int> Statistics;
    
    public void CreateEvent(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
    public static void AddToList(string name, DateTime date)
    {
        ListOfEvents.Add(new Event(){ Name = name, Date = date});
    }
    public static void GetListOfEvents()
    {
    DateTime actualTime = DateTime.Now;
    foreach (var item in ListOfEvents.OrderBy(item => item.Date))
        {
            int difference = (item.Date - actualTime).Days;
            string dateFormat = DateToString(item.Date);
            Console.WriteLine((difference > 0) ? $"Event {item.Name} with date {dateFormat} will happen {difference} days ago." : $"Event {item.Name} with date {dateFormat} will happened {difference * -1} days ago.");
        }
    }
    public static void AddToStats(DateTime date)
    {
        if (!Statistics.ContainsKey(date))
            {
                Statistics.Add(date, 1);
            }
        else
            {   Statistics[date] += 1;
            }      
    }
    public static void GetStats()
    {
    foreach (var item in Statistics)
		{
            string dateFormat = DateToString(item.Key);
			Console.WriteLine($"Date: {dateFormat}: events: {item.Value}");
		}
    }
    public static string DateToString(DateTime date)
    {
        string dateFormat = date.ToString("yyyy-MM-dd");
        return dateFormat;
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        Event udalost = new Event();
        Event.ListOfEvents = new List<Event>();
        Event.Statistics = new Dictionary<DateTime, int>();

        while (true)
        {
            Console.WriteLine("Use format EVENT;[event name];[event date: YYYY-MM-DD]:");
            string vstup = Console.ReadLine();

            string[] prvkyVstupu = vstup.Split(";");
            
                switch (prvkyVstupu[0].ToUpper())
                {
                case "EVENT":
                    Event.AddToList(prvkyVstupu[1], StringToDate(prvkyVstupu[2]));
                    DateTime date = StringToDate(prvkyVstupu[2]);
                    Event.AddToStats(date);              
                    break;

                case "LIST":
                    Event.GetListOfEvents();
                    break;
                case "STATS":
                    Event.GetStats();
                    break;
            case "END":
                return;
            default:
                Console.WriteLine("Format is not correct. Check that text contains EVENT, LIST or STATS. Event format: EVENT;[event name];[event date: YYYY-MM-DD]");
                break;
                }
            
        }
    }

    public static DateTime StringToDate(string date)
    {
        DateTime dateValue;
        while(DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue) == false)
            {
                Console.WriteLine("Date format is not correct. Use yyyy-MM-dd format.");
                date = LoadInput();
            }
        return dateValue;
    }

    public static string LoadInput()
    {
        string vstup = Console.ReadLine();
        return vstup;
    }
}