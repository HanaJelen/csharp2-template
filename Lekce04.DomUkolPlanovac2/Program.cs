﻿
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

public class Event
{
    public string Name{ get; set; }
    public DateTime Date { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Event> ListOfEvents = new List<Event>();
        Dictionary<DateTime, int> Statistics = new Dictionary<DateTime, int>();

        while (true)
        {
            Console.WriteLine("Use format EVENT;[event name];[event date: YYYY-MM-DD]:");
            string vstup = Console.ReadLine();

            string[] prvkyVstupu = vstup.Split(";");
            
                switch (prvkyVstupu[0].ToUpper())
                {
                case "EVENT":
                    string name = prvkyVstupu[1];
                    string[] casti = prvkyVstupu[2].Split("-");

                    
                    string date = prvkyVstupu[2];
                    DateTime dateValue;

                    while(DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue) == false)
                    {
                        Console.WriteLine("Date format is not correct. Use yyyy-MM-dd format.");
                        date = Console.ReadLine();
                    }

                    Event udalost = new Event(){Name = name, Date = dateValue};
                    ListOfEvents.Add(udalost);//fill list of objects

                    //fill dictionary with statistics 
                    if (Statistics.ContainsKey(dateValue))
                    {
                        Statistics[dateValue] += 1;
                    }
                    else
                    {
                        Statistics.Add(dateValue, 1);
                    }                  
                    break;

                case "LIST":
                    DateTime actualTime = DateTime.Now;
                    foreach (var item in ListOfEvents.OrderBy(item => item.Date))
                    {
                        int difference = (item.Date - actualTime).Days;
                        string dateFormat = item.Date.ToString();
                        dateFormat = $"{dateFormat.Substring(6,4)}-{dateFormat.Substring(3,2)}-{dateFormat.Substring(0,2)}";
                        Console.WriteLine((difference > 0) ? $"Event {item.Name} with date {dateFormat} will happen {difference} days ago." : $"Event {item.Name} with date {dateFormat} will happened {difference * -1} days ago.");
                    }
                    break;
                case "STATS":
                    foreach (var item in Statistics)
		            {
                        string dateFormat = item.Key.ToString();
                        dateFormat = $"{dateFormat.Substring(6,4)}-{dateFormat.Substring(3,2)}-{dateFormat.Substring(0,2)}";
			            Console.WriteLine($"Date: {dateFormat}: events: {item.Value}");
		            }
                    break;
            case "END":
                return;
            default:
                Console.WriteLine("Format is not correct. Check that text contains EVENT, LIST or STATS. Event format: EVENT;[event name];[event date: YYYY-MM-DD]");
                break;
                }
            
        }
    }
}