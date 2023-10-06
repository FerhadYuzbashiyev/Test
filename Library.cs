namespace Library
{
    internal class Save : Patron
    {
        public void SaveInfo()
        {
            string directoryPath = @"C:\Users\Gaming PC\Desktop";
            string fileName = "data.txt";
            string filePath = Path.Combine(directoryPath, fileName);
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Names and their contact info: ");
                for (int i = 0; i < PatronNames.Length && i < contactInfo.Length; i++)
                {
                    sw.Write($"{i + 1}) {PatronNames[i]}, ");
                    sw.WriteLine($"{contactInfo[i]}");
                }
                sw.WriteLine("Borrowed books: ");
                for(int i = 0; i < borrowedBooks.GetLength(0); i++)
                {
                    sw.Write($"{i + 1}) ");
                    for(int j = 0; j < borrowedBooks[i].Length; j++)
                    {
                        sw.Write($"{borrowedBooks[i][j]}, ");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
    internal class Book : Patron
    {

    }
    internal class Patron
    {
        public string[] contactInfo = new string[5];
        public string[][] borrowedBooks = new string[5][];
        public string[] PatronNames = new string[5];
        private int chooseBookCount;
        private int[] chooseBook;
        private int[] NEWchooseBook = new int[9];
        private bool flag = true;
        private int choosePatron, PatronInd;
        protected string[] allAuthors = new string[]
        {
            "Isabella Nightshade",
            "Aiden Everbright",
            "Evelyn Mystere",
            "Magnus Arcanum",
            "Seraphina Shadowdancer",
            "Lucius Stormrider",
            "Elara Moonshadow",
            "Dr. Orion Quantum",
            "Amelia Adventureheart"
        };
        protected string[] allBooks = new string[]
        {
            "Amelia Adventureheart",
            "Chronicles of the Eternity Key",
            "Lost in the Labyrinth of Dreams",
            "The Enchanted Alchemist's Apprentice",
            "Echoes of Forgotten Realms",
            "Serpents of the Celestial Isles",
            "The Secret Garden of Time",
            "Tales from the Quantum Realm",
            "Wandering through Wonders: A Traveler's Odyssey"
        };
        protected long[] ISBN = new long[]
        {
            9780451526342,
            9780141439563,
            9780061120084,
            9780670020553,
            9780385341004,
            9780307743657,
            9780553280360,
            9780446310789,
            9780064407663
        };
        protected enum BookStatus
        {
            Available,
            Checked_Out,
            Lost
        }
        public void GiveContactInfo()
        {
            Console.WriteLine("Input a patron name: ");
            for (int i = 0; i < PatronNames.Length; i++)
            {
                if (PatronNames[i] == null)
                {
                    PatronNames[i] = Console.ReadLine();
                    if (PatronNames[i] == "")
                    {
                        PatronNames[i] = "No data";
                    }
                    Console.Write($"Now input a contact info for {PatronNames[i]}: ");
                    break;
                }
            }
            for (int i = 0; i < contactInfo.Length; i++)
            {
                if (contactInfo[i] == null)
                {
                    contactInfo[i] = Console.ReadLine();
                    if (contactInfo[i] == "")
                    {
                        contactInfo[i] = "No data";
                    }
                    break;
                }
            }
        }
        public void GiveBooksInfo()
        {
            
            Console.WriteLine("Choose a patron: ");
            for (int i = 0; i < PatronNames.Length; i++)
            {
                if (PatronNames[i] != null)
                {
                    Console.WriteLine($"{i + 1}) {PatronNames[i]}");
                }
            }
            while (true)
            {
                choosePatron = int.Parse(Console.ReadLine());
                if (choosePatron < 1 || choosePatron > 5)
                {
                    Console.WriteLine("Choose between 1 and 5!");
                }
                else
                {
                    for (int i = 0; i < PatronNames.Length; i++)
                    {

                        PatronInd = choosePatron - 1;
                        Console.WriteLine($"Now input a book count for {PatronNames[PatronInd]}:");
                        break;

                    }
                    break;
                }
            }
            while (true)
            {
                chooseBookCount = int.Parse(Console.ReadLine());
                if (chooseBookCount < 1 || chooseBookCount > 9)
                {
                    Console.WriteLine("Library policy: You can't take more than 9 books in one time.");
                }
                else
                {
                    break;
                }
            }
            chooseBook = new int[chooseBookCount];
            for (int i = 0; i < allBooks.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {allBooks[i]}");   // Books output
            }
            Console.WriteLine("\nThen choose the books you would like to borrow: ");
            for (int i = 0; i < chooseBookCount; i++)
            {
                flag = true;
                chooseBook[i] = int.Parse(Console.ReadLine());
                while (flag)
                {
                    if (chooseBook[i] < 1 || chooseBook[i] > 9)
                    {
                        Console.WriteLine("Choose between 1 and 9!");
                        chooseBook[i] = int.Parse(Console.ReadLine());
                        //continue;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            Array.Sort(chooseBook);
            chooseBook = chooseBook.Distinct().ToArray();
            BooksAssignment();
        }
        public void BooksAssignment()
        {
            for (int i = 0; i < PatronNames.Length && i < borrowedBooks.GetLength(0); i++)
            {
                borrowedBooks[PatronInd] = new string[chooseBookCount];
            }
            foreach (var item in contactInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(chooseBook.Length);
            for (int i = 0; i < chooseBook.Length && i < allBooks.Length; i++)
            {
                borrowedBooks[PatronInd][i] = allBooks[chooseBook[i] - 1];
                Console.WriteLine($"{i + 1}) {borrowedBooks[PatronInd][i]}");
            }
            Console.WriteLine();
        }
        public void a()
        {
            for(int i = 0; i < contactInfo.Length; i++)
            {
                Console.WriteLine(contactInfo[i]);
            }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool CodeExit = true;
            Save s = new Save();
            Patron i = new Patron();
            s.GiveContactInfo();
            s.GiveContactInfo();
            s.GiveContactInfo();
            s.GiveContactInfo();
            s.GiveContactInfo();
            s.GiveBooksInfo();
            s.GiveBooksInfo();
            s.GiveBooksInfo();
            s.GiveBooksInfo();
            s.GiveBooksInfo();
            s.SaveInfo();
        }
    }
}