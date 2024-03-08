using System.Reflection.Emit;

namespace Test2
{
    internal class Book
    {
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public string? Genre { get; set; }
        public int? YearRealise { get; set; }
        public string?[] GenreNames =
        {
            "Novel","Thriller","Fantasy","Horror","Poetry","Drama"
        };
    }

    internal class Program
    {
        static List<Book> bookie = new List<Book>();
        public static void Main(string[] args)
        {
            int choice;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose an option:\n");
                Console.WriteLine("1) Add a book\n" +
                    "2) Remove all books\n" +
                    "3) Update a book info\n" +
                    "4) Search book by its parameters\n" +
                    "5) Insert a book at the beginning of the list\n" +
                    "6) Insert a book at the end of the list\n" +
                    "7) Insert a book at the individual place\n" +
                    "8) Remove a book from the beginning of the list\n" +
                    "9) Remove a book from the end of the list\n" +
                    "10) Remove a book from the individual place\n" +
                    "11) Output all books\n" +
                    "12) Save info\n" +
                    "13) Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBooks();
                        break;
                    case 3:
                        UpdateBook();
                        break;
                    case 4:
                        SearchByParams();
                        break;
                    case 5:
                        InsertBookAtBeginning();
                        break;
                    case 6:
                        InsertBookAtEnd();
                        break;
                    case 7:
                        InsertBookByChoice();
                        break;
                    case 8:
                        RemoveBookAtBeginning();
                        break;
                    case 9:
                        RemoveBookAtEnd();
                        break;
                    case 10:
                        RemoveBookByChoice();
                        break;
                    case 11:
                        OutputBooks();
                        break;
                    case 12:
                        SaveInfo();
                        break;
                    case 13:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Try again.");
                        break;
                }
            }
        }
        static void AddBook()
        {
            Book book = new Book();
            int genreChoice;
            Console.Write("Input a book name: ");
            book.BookName = Console.ReadLine();
            Console.Write("Input an author name: ");
            book.AuthorName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Choose one of book genres: \n");
                for (int i = 0; i < book.GenreNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {book.GenreNames[i]}");
                }
                genreChoice = int.Parse(Console.ReadLine());
                if (genreChoice < 1 || genreChoice > 6)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    book.Genre = book.GenreNames[genreChoice - 1];
                    break;
                }
            }
            while (true)
            {
                Console.Write("Input a year realise: ");
                book.YearRealise = int.Parse(Console.ReadLine());
                if (book.YearRealise < 1900 || book.YearRealise > DateTime.Now.Year)
                {
                    Console.WriteLine("Wrong year! Try again.");
                }
                else
                {
                    break;
                }
            }
            bookie.Add(book);
        }
        static void RemoveBooks()
        {
            int choice, count = 0;
            Console.WriteLine($"Are you sure you want to remove all books from the list?");
            while (true)
            {
                Console.WriteLine($"1) Yes\n2) No");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    bookie.Clear();
                    Console.WriteLine($"All books are successfully removed! :)");
                    break;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Bro... Fuck off then.");
                    break;
                }
                else if (count == 2)
                {
                    Console.WriteLine("BROO STOOOOP");
                }
                else if (choice != 1 && choice != 2)
                {
                    Console.WriteLine($"There are only 2 options. Why tf did u choose {choice}???");
                    count++;
                }
            }
        }
        static void OutputBooks()
        {
            Console.WriteLine("Books info:");
            if (bookie.Count == 0)
            {
                Console.WriteLine("No books info yet...");
                return;
            }
            for (int i = 0; i < bookie.Count; i++)
            {
                if (bookie[i].BookName == "")
                {
                    bookie[i].BookName = "No data";
                }
                if (bookie[i].AuthorName == "")
                {
                    bookie[i].AuthorName = "No data";
                }
            }
            for (int i = 0; i < bookie.Count; i++)
            {
                Console.WriteLine($"{i + 1})\nBook name: {bookie[i].BookName}." +
                    $"\nAuthor name: {bookie[i].AuthorName}." +
                    $"\nGenre: {bookie[i].Genre}." +
                    $"\nYear realise: {bookie[i].YearRealise}.\n");
            }
        }
        static void UpdateBook()
        {
            Book book = new Book();
            int choice, bookID, genreChoice;
            while (true)
            {
                Console.WriteLine("Choose a book to update its info: ");
                for (int i = 0; i < bookie.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
                }
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    bookID = choice - 1;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine($"1) Change author name\n" +
                    $"2) Change book genre\n" +
                    $"3) Change year realise\n" +
                    $"4) Exit");
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 4)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Input an author name: ");
                            bookie[bookID].AuthorName = Console.ReadLine();
                            break;
                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Choose one of book genres: \n");
                                for (int i = 0; i < book.GenreNames.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}) {book.GenreNames[i]}");
                                }
                                genreChoice = int.Parse(Console.ReadLine());
                                if (genreChoice < 1 || genreChoice > 6)
                                {
                                    Console.WriteLine("Wrong choice. Try again.");
                                }
                                else
                                {
                                    bookie[bookID].Genre = book.GenreNames[genreChoice - 1];
                                    break;
                                }
                            }
                            break;
                        case 3:
                            while (true)
                            {
                                Console.Write("Input a year realise: ");
                                bookie[bookID].YearRealise = int.Parse(Console.ReadLine());
                                if (bookie[bookID].YearRealise < 1900 || bookie[bookID].YearRealise > DateTime.Now.Year)
                                {
                                    Console.WriteLine("Wrong year! Try again.");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }
        static void SearchByParams()
        {
            Book book = new Book();
            int choice, foundBookId;
            while (true)
            {
                Console.WriteLine("Choose a parameter:\n" +
                    "1) Search by author name\n" +
                    "2) Search by genre\n" +
                    "3) Search by year realise");
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    break;
                }
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select author name: ");
                    for (int i = 0; i < bookie.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {bookie[i].AuthorName}");
                    }
                    while (true)
                    {
                        foundBookId = int.Parse(Console.ReadLine());
                        if (foundBookId < 1 || foundBookId > bookie.Count)
                        {
                            Console.WriteLine("Wrong choice. Try again.");
                        }
                        else
                        {
                            foundBookId--;
                            Console.WriteLine($"You were looking for \"{bookie[foundBookId].BookName}\"");
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Select a genre: ");
                    for (int i = 0; i < bookie.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {bookie[i].Genre}");
                    }
                    while (true)
                    {
                        foundBookId = int.Parse(Console.ReadLine());
                        if (foundBookId < 1 || foundBookId > bookie.Count)
                        {
                            Console.WriteLine("Wrong choice. Try again.");
                        }
                        else
                        {
                            foundBookId--;
                            Console.WriteLine($"You were looking for \"{bookie[foundBookId].BookName}\"");
                            break;
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Select a year realise: ");
                    for (int i = 0; i < bookie.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {bookie[i].YearRealise}");
                    }
                    while (true)
                    {
                        foundBookId = int.Parse(Console.ReadLine());
                        if (foundBookId < 1 || foundBookId > bookie.Count)
                        {
                            Console.WriteLine("Wrong choice. Try again.");
                        }
                        else
                        {
                            foundBookId--;
                            Console.WriteLine($"You were looking for \"{bookie[foundBookId].BookName}\"");
                            break;
                        }
                    }
                    break;
            }

        }
        static void InsertBookAtBeginning()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Choose a book to insert it at the beginning of the list: ");
                for (int i = 0; i < bookie.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
                }
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    choice--;
                    var temp = bookie[0].BookName;
                    bookie[0].BookName = bookie[choice].BookName;
                    bookie[choice].BookName = temp;
                    break;
                }
            }
            for (int i = 0; i < bookie.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
            }
        }
        static void InsertBookAtEnd()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Choose a book to insert it at the end of the list: ");
                for (int i = 0; i < bookie.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
                }
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    choice--;
                    var temp = bookie[bookie.Count - 1].BookName;
                    bookie[bookie.Count - 1].BookName = bookie[choice].BookName;
                    bookie[choice].BookName = temp;
                    break;
                }
            }
            for (int i = 0; i < bookie.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
            }
        }
        static void InsertBookByChoice()
        {
            int choice, choice_1;
            while (true)
            {
                Console.WriteLine("Choose a book to insert:");
                for (int i = 0; i < bookie.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {bookie[i].BookName}");
                }
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    choice--;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine($"Choose a place from 1 to {bookie.Count} to insert a book");
                choice_1 = int.Parse(Console.ReadLine());
                if (choice_1 < 1 || choice_1 > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    choice_1--;
                    var temp = bookie[choice_1].BookName;
                    bookie[choice_1].BookName = bookie[choice].BookName;
                    bookie[choice].BookName = temp;
                    break;
                }
            }
            for (int i = 0; i < bookie.Count; i++)
            {
                Console.WriteLine(bookie[i].BookName);
            }
        }
        static void RemoveBookAtBeginning()
        {
            int choice, count = 0;
            Book bookToRemove;
            Console.WriteLine($"Are you sure you want to remove \"{bookie[0].BookName}\" from the list?");
            while (true)
            {
                Console.WriteLine($"1) Yes\n2) No");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    bookToRemove = bookie.Find(b => b.BookName != null && b.BookName == bookie[0].BookName);
                    Console.WriteLine($"\"{bookie[0].BookName}\" is successfully removed! :)");
                    bookie.Remove(bookToRemove);
                    break;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Bro... Fuck off then.");
                    break;
                }
                else if (count == 2)
                {
                    Console.WriteLine("BROO STOOOOP");
                }
                else if (choice != 1 && choice != 2)
                {
                    Console.WriteLine($"There are only 2 options. Why tf did u choose {choice}???");
                    count++;
                }
            }
        }
        static void RemoveBookAtEnd()
        {
            int choice, count = 0;
            Book bookToRemove;
            Console.WriteLine($"Are you sure you want to remove \"{bookie[bookie.Count - 1].BookName}\" from the list?");
            while (true)
            {
                Console.WriteLine($"1) Yes\n2) No");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    bookToRemove = bookie.Find(b => b.BookName != null && b.BookName == bookie[bookie.Count - 1].BookName);
                    Console.WriteLine($"\"{bookie[bookie.Count - 1].BookName}\" is successfully removed! :)");
                    bookie.Remove(bookToRemove);
                    break;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Bro... Fuck off then.");
                    break;
                }
                else if (count == 2)
                {
                    Console.WriteLine("BROO STOOOOP");
                }
                else if (choice != 1 && choice != 2)
                {
                    Console.WriteLine($"There are only 2 options. Why tf did u choose {choice}???");
                    count++;
                }
            }
        }
        static void RemoveBookByChoice()
        {
            int choice, choice_1, count = 0;
            Book bookToRemove;
            while (true)
            {
                Console.WriteLine($"Choose a number from 1 to {bookie.Count} to remove the book from the list: ");
                choice_1 = int.Parse(Console.ReadLine());
                if (choice_1 < 1 || choice_1 > bookie.Count)
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
                else
                {
                    choice_1--;
                    Console.WriteLine($"Are you sure you want to remove \"{bookie[choice_1].BookName}\" from the list?");
                    while (true)
                    {
                        Console.WriteLine($"1) Yes\n2) No");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            bookToRemove = bookie.Find(b => b.BookName != null && b.BookName == bookie[choice_1].BookName);
                            Console.WriteLine($"\"{bookie[choice_1].BookName}\" is successfully removed! :)");
                            bookie.Remove(bookToRemove);
                            break;
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("Bro... Fuck off then.");
                            break;
                        }
                        else if (count == 2)
                        {
                            Console.WriteLine("BROO STOOOOP");
                        }
                        else if (choice != 1 && choice != 2)
                        {
                            Console.WriteLine($"There are only 2 options. Why tf did u choose {choice}???");
                            count++;
                        }
                    }
                    break;
                }
            }
        }
        static void SaveInfo()
        {
            Console.WriteLine("Saving info...");
            if (bookie.Count == 0)
            {
                Console.WriteLine("Create at least one book info first!\n");
                return;
            }
            string directoryPath = @"C:\Users\Acer\Desktop";
            string fileName = "data.txt";
            string filePath = Path.Combine(directoryPath, fileName);
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < bookie.Count; i++)
                {
                    if (bookie[i].BookName == "")
                    {
                        bookie[i].BookName = "No data";
                    }
                    else if (bookie[i].AuthorName == "")
                    {
                        bookie[i].AuthorName = "No data";
                    }
                    sw.Write($"{i + 1})\n" +
                        $"Book name: {bookie[i].BookName}." +
                        $"\nAuthor name: {bookie[i].AuthorName}." +
                        $"\nGenre: {bookie[i].Genre}" +
                        $"\nYear realise: {bookie[i].YearRealise}\n");
                }
            }
            Console.WriteLine("Saved successfully!");
        }
    }
}
