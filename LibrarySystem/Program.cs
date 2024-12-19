using System;

namespace LibrarySystem
{
    class Program
    {
        static Library library = new Library();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nLibrary Terminal - Main Menu");
                Console.WriteLine("1. Display all books");
                Console.WriteLine("2. Search books by title");
                Console.WriteLine("3. Search books by author");
                Console.WriteLine("4. Check out a book");
                Console.WriteLine("5. Return a book");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.DisplayBooks();
                        break;
                    case "2":
                        Console.Write("Enter a title keyword to search: ");
                        library.SearchByTitle(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Enter an author's name to search: ");
                        library.SearchByAuthor(Console.ReadLine());
                        break;
                    case "4":
                        library.DisplayBooks();
                        Console.Write("Enter the number of the book to check out: ");
                        if (int.TryParse(Console.ReadLine(), out int checkOutIndex))
                        {
                            library.CheckOutBook(checkOutIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "5":
                        library.DisplayBooks();
                        Console.Write("Enter the number of the book to return: ");
                        if (int.TryParse(Console.ReadLine(), out int returnIndex))
                        {
                            library.ReturnBook(returnIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}