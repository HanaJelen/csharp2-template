public class Lucisnik
{
    string Jmeno;
    int PocetSipu;

    public Lucisnik(string jmeno, int pocetSipu)
    {
        Jmeno = jmeno;
        PocetSipu = pocetSipu;
    }

    public void Vystrel()
    {
        if (PocetSipu > 0)
        {
            PocetSipu --; 
            Console.WriteLine("Šíp vystřelen!\n"); 
        }
        else
        {
            Console.WriteLine("Nemáte dostatek šípů. Doplňte šípy.\n");
        } 
    }

    public void PridejSipy(int pocetSipu)
    {
        PocetSipu += pocetSipu;
        Console.WriteLine("Šípy doplněny. Počet šípů je nyní {0}.\n", PocetSipu);
    }

     public void ZobravStav()
    {
        Console.WriteLine("Jméno lučišníka je {0} a počet šípů v toulci je {1}.\n", Jmeno, PocetSipu);
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Lucisnik legolas = new Lucisnik("Legolas", 3);
        string pomlcka = "---------------------------------------------------------";
        Console.WriteLine("Vítejte ve hře Lučičník.\n{0}", pomlcka);
        while (true)
        {  
        legolas.ZobravStav();
        Console.WriteLine("Vyberte číslo akce, kterou chcete provést:\n{0}", pomlcka);
        Console.WriteLine("1. Vystřelit šíp\n2. Přidat šípy\n3. Konec\n{0}", pomlcka);
        
        switch (NactiCeleCisloZKonzole())
        {
            case 1:
                legolas.Vystrel();
                break;
            case 2:
                Console.WriteLine("Zadejte počet šípů, které chcete přidat.\n");
                int vstup = NactiCeleCisloZKonzole();
                while (vstup < 0)
                {
                    Console.WriteLine("Zadejte celé kladné číslo.\n");
                    vstup = NactiCeleCisloZKonzole();
                }
                legolas.PridejSipy(vstup);
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Nezadali jste platné číslo. Zvolte 1, 2, nebo 3.\n");
                break;
        }
        }
    }
    public static int NactiCeleCisloZKonzole()
    {
        string vyzva = Console.ReadLine();
        int celeKladneCislo;
        while (!int.TryParse(vyzva, out celeKladneCislo))
            {
                Console.WriteLine("Číslo nebylo zadáno správně. Je třeba zadat celé kládné číslo.\n");
                vyzva = Console.ReadLine();
            }
        return celeKladneCislo;
    }
}