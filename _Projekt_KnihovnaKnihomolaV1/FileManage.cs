using System;

namespace _Projekt_KnihovnaKnihomolaV1;

class FileManage
    {
        public static string Adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Library");
        public static string BooksCSV = Path.Combine(Adresar, "listOfBooks.csv");
        public static string AudiosCSV = Path.Combine(Adresar, "listOfAudio.csv");
        public static string WishlistCSV = Path.Combine(Adresar, "wishlist.csv");

        public static void OpenFile()
        {
            List<string> soubory = new List<string>() { BooksCSV, AudiosCSV, WishlistCSV};
            foreach (var item in soubory)
            {
                if (File.Exists(item))
                {
                    FileToList(item);
                }
                else
                {
                    Console.WriteLine($"Soubor {item} nenalezen.");
                }
            }
        }

        public static void FileToList(string fileBookcase)//převod csv na listy
        {
            var nacteneZeSouboru = File.ReadAllLines(fileBookcase);
            foreach (var item in nacteneZeSouboru)
            {
                InputManage.GetNewPublication(item);
            }
        }
        public static void ListToFile()
        {
            Directory.CreateDirectory(Adresar);
            var knihy = BookList.ListOfBook.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.Pages}; {Book.ReadStatus}; {Book.Rating}");
            File.AppendAllLines(Path.Combine(Adresar, "listOfBooks.csv"), knihy);

            var audio = AudioList.ListOfAudio.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}; {Book.Genre}; {Book.Theme}; {Book.RunTime}; {Book.ReadStatus}; {Book.Rating}");
            File.AppendAllLines(Path.Combine(Adresar, "listOfAudio.csv"), audio);

            var prani = WishList.ListOfWish.Select(Book => $"{Book.Medium}; {Book.Title}; {Book.Author}; {Book.NameOfSerie}; {Book.NumberOfBookInSerie}");
            File.AppendAllLines(Path.Combine(Adresar, "wishlist.csv"), prani);
        }
    }
