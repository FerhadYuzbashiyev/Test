namespace Library
{
    interface ISearch
    {
        public void SearchPatron();
    }
    internal class Save : Book, ISearch
    {
        public void SearchPatron()
        {
            Console.WriteLine();
            if (PatronNames[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Create at least one patron info.\n");
                return;
            }
            for (int i = 0; i < PatronNames.Length; i++)
            {
                if (PatronNames[i] != null)
                {
                    Console.Write($"{i + 1})\n" +
                        $"Patron name: {PatronNames[i]}\n" +
                        $"Contact Info: {contactInfo[i]}\n" +
                        $"Borrowed Books: ");
                    try
                    {
                        for (int j = 0; j < borrowedBooks[i].Length; j++)
                        {
                            Console.Write($"{borrowedBooks[i][j]}");
                            if (j == borrowedBooks[i].Length - 1)
                            {
                                Console.WriteLine($".");
                            }
                            else
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No data");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void SaveInfo()
        {
            if (PatronNames[0] == null)
            {
                Console.WriteLine("Create at least one patron info first!\n");
                return;
            }
            string directoryPath = @"C:\Users\Acer\Desktop";
            string fileName = "data.txt";
            string filePath = Path.Combine(directoryPath, fileName);
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Names and their contact info: ");
                for (int i = 0; i < PatronNames.Length && i < contactInfo.Length; i++)
                {
                    if (PatronNames[i] != null)
                    {
                        sw.Write($"{i + 1}) {PatronNames[i]}, ");
                        sw.WriteLine($"{contactInfo[i]}");
                    }
                }
                sw.WriteLine("Borrowed books: ");
                for (int i = 0; i < borrowedBooks.GetLength(0); i++)
                {
                    if (borrowedBooks[i] != null)
                    {
                        sw.Write($"{i + 1}) ");
                        for (int j = 0; j < borrowedBooks[i].Length; j++)
                        {
                            sw.Write($"{borrowedBooks[i][j]}");
                            if (j == borrowedBooks[i].Length - 1)
                            {
                                sw.WriteLine($".");
                            }
                            else
                            {
                                sw.Write(", ");
                            }
                        }
                    }
                    else if (PatronNames[i] != null)
                    {
                        sw.WriteLine($"{i + 1}) No data.");
                    }
                    /*else
                    {
                        sw.Write($"{i + 1}) No data.\n");
                    }*/
                }
            }
        }
    }
    internal class Book : Patron
    {
        //private int OneBookInfo;
        private int bookCount;
        private int[] ManyBooksInfo;
        private bool flag = true;
        private bool flag2 = true;
        private string[] BooksForInfo;
        private string[] AuthorsForInfo;
        private long[] ISBNForInfo;
        public void ShowBooksInfo()
        {
            flag = true;
            flag2 = true;
            while (flag)
            {
                Console.Write("Choose a book count: ");
                bookCount = int.Parse(Console.ReadLine());
                if (bookCount < 1 || bookCount > 9)
                {
                    Console.WriteLine("Choose between 1 and 9");
                }
                else
                {
                    for (int i = 0; i < allBooks.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}) {allBooks[i]}");
                    }
                    if (bookCount < 1 && bookCount > allBooks.Length)
                    {
                        Console.WriteLine($"\nChoose between 1 and {allBooks.Length}");
                    }
                    else
                    {
                        ManyBooksInfo = new int[bookCount];
                        Console.WriteLine("\nChoose a books number you would like to know about:");
                        for (int i = 0; i < bookCount; i++)
                        {
                            flag2 = true;
                            ManyBooksInfo[i] = int.Parse(Console.ReadLine());
                            while (flag2)
                            {
                                if (ManyBooksInfo[i] < 1 || ManyBooksInfo[i] > 9)
                                {
                                    Console.WriteLine("Choose between 1 and 9!");
                                    ManyBooksInfo[i] = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    flag2 = false;
                                    //flag = false;
                                }
                            }
                        }
                    }
                    flag = false;
                }
            }
            Array.Sort(ManyBooksInfo);
            ManyBooksInfo = ManyBooksInfo.Distinct().ToArray();
            ShowedBooksAssignment();
        }
        public void ShowedBooksAssignment()
        {
            BooksForInfo = new string[ManyBooksInfo.Length];
            AuthorsForInfo = new string[ManyBooksInfo.Length];
            ISBNForInfo = new long[ManyBooksInfo.Length];
            for (int i = 0; i < ManyBooksInfo.Length; i++)
            {
                BooksForInfo[i] = allBooks[ManyBooksInfo[i] - 1];
                AuthorsForInfo[i] = allAuthors[ManyBooksInfo[i] - 1];
                ISBNForInfo[i] = ISBN[ManyBooksInfo[i] - 1];
                Console.Write($"{i + 1}) Book name: " +
                    $"{BooksForInfo[i]}\n" +
                    $"Author: " +
                    $"{AuthorsForInfo[i]}\n" +
                    $"ISBN: " +
                    $"{ISBNForInfo[i]}\n" +
                    $"Book Status: ");
                if (ManyBooksInfo[i] - 1 == 7)
                {
                    Console.Write(BookStatus.Checked_Out);
                    Console.WriteLine("\n");
                }
                else if (ManyBooksInfo[i] - 1 == 8)
                {
                    Console.Write(BookStatus.Lost);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.Write(BookStatus.Available);
                    Console.WriteLine("\n");
                }
            }
        }
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
        private bool flag2 = true;
        private bool flag3 = true;
        private int choosePatron;
        private int PatronInd;
        private int borrowedBooksSize;
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
        public void CreatePatronInfo()
        {
            flag2 = true;
            flag3 = true;

            Console.WriteLine("Input a patron name: ");
            for (int i = 0; i < PatronNames.Length; i++)
            {
                if (PatronNames[i] == null)
                {
                    while (flag2)
                    {
                        PatronNames[i] = Console.ReadLine();
                        if (PatronNames[i] == "")
                        {
                            // PatronNames[i] = "No data";
                            //break;
                            Console.WriteLine("Don't leave this field empty!");
                        }
                        else
                        {
                            flag2 = false;
                        }
                    }
                    Console.Write($"Now input a contact info for {PatronNames[i]}: ");
                    break;
                }
            }
            for (int i = 0; i < contactInfo.Length; i++)
            {
                if (contactInfo[i] == null)
                {
                    while (flag3)
                    {
                        contactInfo[i] = Console.ReadLine();
                        if (contactInfo[i] == "")
                        {
                            Console.WriteLine("Don't leave this field empty");
                        }
                        else
                        {
                            flag3 = false;
                        }
                    }
                    break;
                }
            }
        }
        public void BorrowBook()
        {
            if (PatronNames[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Create at least one patron info first!\n");
                return;
            }
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
                /*if (choosePatron != Array.IndexOf(PatronNames, PatronNames[i]) + 1)
                {
                    Console.WriteLine($"Choose between 1 and 5!");
                }*/
                for(int i = 0; i < PatronNames.Length; i++)
                {
                    if (PatronNames[i] != null)
                    {
                        borrowedBooksSize = i;
                    }
                }
                borrowedBooksSize++;
                if (choosePatron < 1 || choosePatron > borrowedBooksSize)
                {
                    Console.WriteLine($"Choose between 1 and {borrowedBooksSize}!");
                }
                else
                {
                    /* for (int i = 0; i < PatronNames.Length; i++)
                     {*/
                    PatronInd = choosePatron - 1;
                    /*if (PatronNames[PatronInd] == null)
                    {
                        Console.WriteLine("Choose ");
                    }*/
                    Console.WriteLine($"Now input a book count for {PatronNames[PatronInd]}:");
                    break;
                    /*}
                    break;*/
                }
            }


            while (true)
            {
                chooseBookCount = int.Parse(Console.ReadLine());
                if (chooseBookCount > 9)
                {
                    Console.WriteLine("Library policy: You can't take more than 9 books in one time.");
                }
                else if(chooseBookCount < 1)
                {
                    Console.WriteLine("Wrong book count entered. Try again.");
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
                    else if (chooseBook[i] == 8)
                    {
                        Console.WriteLine($"Unfortunately this book is {BookStatus.Checked_Out}. But you can choose another one.");
                        chooseBook[i] = int.Parse(Console.ReadLine());
                    }
                    else if (chooseBook[i] == 9)
                    {
                        Console.WriteLine($"Unfortunately this book is {BookStatus.Lost}. But you can choose another one.");
                        chooseBook[i] = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            Array.Sort(chooseBook);
            //chooseBook = chooseBook.Distinct().ToArray();
            BorrowedBooksAssignment();
        }
        public void BorrowedBooksAssignment() // borrowedBooks[][] memory allocation
                                              // and assignment and 2 Outputs
        {
            for (int i = 0; i < PatronNames.Length && i < borrowedBooks.GetLength(0); i++)
            {
                borrowedBooks[PatronInd] = new string[chooseBookCount];
            }
            for (int i = 0; i < chooseBook.Length && i < allBooks.Length; i++)
            {
                borrowedBooks[PatronInd][i] = allBooks[chooseBook[i] - 1];
            }
        }
        public void ShowPatronInfo()
        {
            Console.WriteLine();
            for(int i = 0; i < PatronNames.Length; i++)
            {
                if (PatronNames[i] != null)
                {
                    Console.Write($"{i + 1})\n" +
                        $"Patron name: {PatronNames[i]}\n" +
                        $"Contact Info: {contactInfo[i]}\n" +
                        $"Borrowed Books: ");
                    try
                    {
                        for (int j = 0; j < borrowedBooks[i].Length; j++)
                        {
                            Console.Write($"{borrowedBooks[i][j]}");
                            if (j == borrowedBooks[i].Length - 1)
                            {
                                Console.WriteLine($".");
                            }
                            else
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No data");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool CodeExit = true;
            int choose;
            Save s = new Save();
            Patron p = new Patron();
            Book b = new Book();
            while (CodeExit)
            {
                Console.WriteLine("Choose one option: ");
                Console.WriteLine("1) Create patron info");
                Console.WriteLine("2) Borrow book/books");
                Console.WriteLine("3) Find out a book info");
                Console.WriteLine("4) Show full patron info");
                Console.WriteLine("5) Save patron info");
                Console.WriteLine("6) Exit\n");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            s.CreatePatronInfo();
                            break;
                        case 2:
                            s.BorrowBook();
                            break;
                        case 3:
                            b.ShowBooksInfo();
                            break;
                        case 4:
                            s.SearchPatron();
                            break;
                        case 5:
                            Console.WriteLine("Saving Info...");
                            s.SaveInfo();
                            break;
                        case 6:
                            CodeExit = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Choose between 1 and 6!\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect data entered. Try again\n");
                }
            }
        }
    }
}