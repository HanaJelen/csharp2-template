public class Program
{
	public static void Main()
	{
				
		//Ukol - Obratte poradi stringu
		string palindrom = "Kuna nese nanuk";

        for (int i = 0; i < palindrom.Length; i++)
        {
            Console.Write(palindrom[palindrom.Length - 1 - i]);
        }

        Console.WriteLine();

		
		//Ukol - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom (zatim jen u slov) a pak z pole vypiste jen palindromy
		string[] slova = new string[] {"kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen"};

        foreach (string slovo in slova)
        {
            string palindromSlovo = "";
            for (int i = 0; i < slovo.Length; i++)
            { 
                palindromSlovo += slovo[slovo.Length - 1 - i];
            }
            if(string.Equals(slovo,palindromSlovo,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("slovo je palindrom {0} = {1}", slovo, palindromSlovo);
                }

        }
		
		//Ukol - opravte v tomto textu omylem zapnuty Caps Lock
		string capsLock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK";

        foreach (char znak in capsLock)
        {
            Console.Write(char.IsLower(znak)? char.ToUpper(znak):char.ToLower(znak));
        }
        Console.WriteLine();
		
		//Ukol - rozsifrujte tuto zpravu - text byl zasifrovan tak, ze jsme kazde pismeno posunuli o jedno doprava: 'a' -> 'b'. 
		string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";
		
        foreach (char pismeno in sifra)
        {
            int pismenoZpet = pismeno - 1;
            Console.Write((char) pismenoZpet);
        }
		Console.WriteLine();
	}
}
