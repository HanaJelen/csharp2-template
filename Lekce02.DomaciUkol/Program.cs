public class Archer
{
    string Name;
    int NumberOfArrow;

    public Archer(string name, int numberOfArrow)
    {
        Name = name;
        NumberOfArrow = numberOfArrow;
    }

    public void Shoot()
    {
        if (NumberOfArrow > 0)
        {
            NumberOfArrow --; 
            Console.WriteLine("Arrow is shot from a bow!\n"); 
        }
        else
        {
            Console.WriteLine("You don´t have an arrow. You can´t shoot!\n");
        } 
    }

    public void GetArrow(int numberOfArrow)
    {
        NumberOfArrow += numberOfArrow;
        Console.WriteLine("Number of arrows is {0} now.\n", NumberOfArrow);
    }

     public void DisplayStatus()
    {
        Console.WriteLine("The archer´s name is {0} and he has {1} arrow(s).\n", Name, NumberOfArrow);
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Archer legolas = new Archer("Legolas", 3);
        string dash = new string('-', 50);
        Console.WriteLine("Welcome to the game Archer.\n{0}", dash);
        while (true)
        {  
        legolas.DisplayStatus();
        Console.WriteLine("Choose action (Numbers: 1-2-3):\n{0}", dash);
        Console.WriteLine("1. Shoot arrow\n2. Get arrow\n3. End\n{0}", dash);
        
        switch (GetIntergerFromConsole())
        {
            case 1:
                legolas.Shoot();
                break;
            case 2:
                Console.WriteLine("Input how many arrows, you want to add.\n");
                int input = GetIntergerFromConsole();
                while (input < 0)
                {
                    Console.WriteLine("Input integer.\n");
                    input = GetIntergerFromConsole();
                }
                legolas.GetArrow(input);
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Input 1, 2, or 3.\n");
                break;
        }
        }
    }
    public static int GetIntergerFromConsole()
    {
        string input = Console.ReadLine();
        int integer;
        while (!int.TryParse(input, out integer))
            {
                Console.WriteLine("Input integer.\n");
                input = Console.ReadLine();
            }
        return integer;
    }
}