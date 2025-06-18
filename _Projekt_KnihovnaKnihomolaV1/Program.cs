//třída knihovna obsahující seznam knížek v ní
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace _Projekt_KnihovnaKnihomolaV1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Vaše knihovna se načítá...\n");
        FileManage.OpenFile();

        Console.WriteLine("Vítejte ve Vaší domácí knihovně pro knihomola!!!\n");
        while (true)
        {
            Console.WriteLine("\nVyberte následující akce dle přiřazených čísel.\n1 - přidat publikaci, 2 - seznamy publikací, 3 - vyhledat v knihovně, 4 - statistika knihovny, 5 - úprava knihovny, 6 - ukončení programu.\n");
            switch (InputManage.StringToNumber(InputManage.LoadInput("")))
            {
                case 1: //ADD to new book
                    Console.Clear();
                    Console.WriteLine("Přejete si přidat\n1 - novou knihu, 2 - novou audioknihu, 3 - do seznamu přání, 4 - zpět.");
                    InputManage.GetNewPublication(InputManage.StringToNumber(InputManage.LoadInput("")));
                    break;
                case 2://LIST
                    Console.Clear();
                    Console.WriteLine("Zadejte jaký seznam chcete zobrazit.\n1 - abecední seznam všech publikací v knihovně, 2 - seznam knih serii, 3 - seznam přání, 4 - zpět.");
                    switch (InputManage.StringToNumber(InputManage.LoadInput("")))
                    {
                        case 1://abecední seznam
                            Console.Clear();
                            Console.WriteLine("Abecední seznam knih:");
                            BookList.GetListOfBooks();
                            Console.WriteLine("Abecední seznam audio knih:");
                            AudioList.GetListOfBooks();
                            break;
                        case 2://seznam knih v serii
                            Console.Clear();
                            Console.WriteLine("Zadejte heslo či celý název serie, kterou si přejete zobrazit:");
                            Serie.GetFullSerie(InputManage.LoadInput(""));
                            break;
                        case 3://seznam přání
                            Console.Clear();
                            WishList.GetListOfBooks();
                            break;
                        case 4://zpět
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.\nZadejte jaký seznam chcete zobrazit.\n1 - abecední seznam knih, 2 - abecední seznam audii, 3 - ediční plán, 4 - seznam přání, 5 - zpět.");
                            break;
                    }
                    break;
                case 3://FIND
                    Console.Clear();
                    Console.WriteLine("Zadejte, co si přejete v knihovně vyhledat: 1 - knihy dle hesla v titulu, 2 - autora dle přijmení, 3 - knihy dle žánru, 4 - knihy dle tématu, 5 - knihy dle rozsahu, 6 - zpět.");
                    switch (InputManage.StringToNumber(InputManage.LoadInput("")))
                    {
                        case 1://heslo
                            Console.Clear();
                            Console.WriteLine("Zadejte slovo, které chcete vyhledat:");
                            string world = InputManage.LoadInput("");
                            Console.WriteLine($"""Výsledky hledání pro "{world}":""");
                            var listHeslo = BookList.GetTitle(world).Concat(AudioList.GetTitle(world));
                            foreach (var item in listHeslo.OrderBy(i => i.Title))
                            {
                                Console.WriteLine($"{item.Title}, autor: {item.Author}, {item.Medium}");
                            }
                            break;
                        case 2://autor
                            Console.Clear();
                            Console.WriteLine("Zadejte přijmení autora, jehož knihy si přejete vyhledat.");
                            string name = InputManage.LoadInput("");
                            Console.WriteLine($"""Knihovna obsahuje tyto knihy od autora {name}":""");
                            var listAutor = BookList.GetBooksOfAuthor(name).Concat(AudioList.GetBooksOfAuthor(name));
                            foreach (var item in listAutor.OrderBy(i => i.Title))
                            {
                                Console.WriteLine($"{item.Title}, autor: {item.Author}, {item.Medium}");
                            }
                            break;
                        case 3://žánr
                            Console.Clear();
                            Console.WriteLine("Zadejte žánr.");
                            string genre = InputManage.LoadInput("");
                            var vyber = from v in BookList.ListOfBook where v.Genre == genre select (v.Title, v.Author, v.Medium);
                            var vyber2 = from v in AudioList.ListOfAudio where v.Genre == genre select (v.Title, v.Author, v.Medium);
                            var vyber3 = vyber.Concat(vyber2);
                            foreach (var item in vyber)
                            {
                                Console.WriteLine($"{item.Title}, {item.Author}, {item.Medium}");
                            }
                            break;
                        case 4://téma
                            Console.Clear();
                            Console.WriteLine("Zadejte téma.");
                            string theme = InputManage.LoadInput("");
                            vyber = from v in BookList.ListOfBook where v.Theme == theme select (v.Title, v.Author, v.Medium);
                            vyber2 = from v in AudioList.ListOfAudio where v.Theme == theme select (v.Title, v.Author, v.Medium);
                            vyber3 = vyber.Concat(vyber2);
                            foreach (var item in vyber)
                            {
                                Console.WriteLine($"{item.Title}, {item.Author}, {item.Medium}");
                            }
                            break;
                        case 5://rozsah
                            Console.Clear();
                            Console.WriteLine("Zadejte dolní hranici");
                            int rozsahDolni = InputManage.StringToNumber(InputManage.LoadInput(""));
                            Console.WriteLine("Zadejte horní hranici");
                            int rozsahHorni = InputManage.StringToNumber(InputManage.LoadInput(""));
                            var rozhraniStran = from v in BookList.ListOfBook where (rozsahDolni < v.Pages) && (v.Pages < rozsahHorni) select (v.Title, v.Author);
                            foreach (var item in rozhraniStran)
                            {
                                Console.WriteLine($"{item.Title}, {item.Author}");
                            }
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.\nZadejte dle čeho chcete hledat.\n1 - dle hesla v titulu knihy, 2 - dle přijmení autora, 3 - dle žánru, 4 - dle tématu, 5 - dle rozsahu, 6 - zpět.");
                            break;
                    }
                    break;
                case 4://STATS
                    Console.Clear();
                    Console.WriteLine("Zadejte, jaká data Vás zajímají. 1 - konrétní autor, 2 - žánr, 3 - nejlépe hodnocené knihy, 4 - nejhůře hodnocené knihy, 5 - zpět.");
                    switch (InputManage.StringToNumber(InputManage.LoadInput("")))
                    {
                        case 1://autor
                            Console.Clear();
                            Console.WriteLine("Zadejte přijmení autora:");
                            Console.Clear();
                            BookList.AuthorStats(InputManage.LoadInput(""));
                            break;
                        case 2://žánr
                            Console.Clear();
                            Console.WriteLine("Ve Vaší knihovně se náchází tyto žánry literatury.");
                            BookList.GenreStats();
                            break;
                        case 3://nejlepší
                            Console.Clear();
                            Console.WriteLine("Top 10 knih:");
                            BookList.GetBest();
                            break;
                        case 4://nejhorší
                            Console.Clear();
                            Console.WriteLine("Nejhůře hodnocených 10 knih:");
                            BookList.GetWorst();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.\nZadejte jaká statistika Vás zajímá.\n1 - konrétní autor, 2 - žánr, 3 - nejlépe hodnocené knihy, 4 - nejhůře hodnocené knihy, 5 - zpět.");
                            break;
                    }
                    break;
                case 5://MANAGE
                    Console.WriteLine("Vítejte ve správě své knihovny. 1 - odstranění knihy, 2 - nákup knihy z wishlistu, 3 - hodnocení knihy, 4 - úprava knihy, 5 - zpět.");
                    switch (InputManage.StringToNumber(InputManage.LoadInput("")))
                    {
                        case 1://odstranění knihy
                            Console.WriteLine("Zadejte celý titul knihy, kterou si přejete odstranit.");
                            BookList.RemoveBook(InputManage.LoadInput(""));
                            break;
                        case 2://nákup knihy z wishlistu
                            Console.WriteLine("Zakoupili jste novou knihu z wishlistu. Zadejte celý titul knihy a doplňte potřebné informace.\nZadejte titul zakoupené knihy:");
                            WishList.NewBuy(InputManage.LoadInput(""));
                            break;
                        case 3://hodnocení knihy
                            BookList.GetRate();
                            break;
                        case 4://úprava knihy
                        
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Zadali jste neočekávaný vstup. Zadejte prosím znovu.\nZadejte jaká statistika Vás zajímá.\n1 - konrétní autor, 2 - žánr, 3 - nejlépe hodnocené knihy, 4 - nejhůře hodnocené knihy, 5 - zpět.");
                            break;
                    }
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
}