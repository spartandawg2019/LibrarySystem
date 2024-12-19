using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class LibraryManager
    {
        private readonly List<Book> books = new List<Book>(); // Correct reference to the Book class

        public LibraryManager()
        {
            InitializeDefaultBooks();
        }

        public void DisplayBooks()
        {
            Console.WriteLine("\nLibrary Catalog:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }

        public void SearchByTitle()
        {
            Console.Write("Enter a title keyword to search: ");
            string keyword = Console.ReadLine();
            var results = books.FindAll(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            if (results.Count > 0)
            {
                Console.WriteLine("\nBooks matching the title keyword:");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found with that title keyword.");
            }
        }

        public void SearchByAuthor()
        {
            Console.Write("Enter an author's name to search: ");
            string author = Console.ReadLine();
            var results = books.FindAll(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            if (results.Count > 0)
            {
                Console.WriteLine("\nBooks by the author:");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found by that author.");
            }
        }

        public void CheckOutBook()
        {
            DisplayBooks();
            Console.Write("Enter the number of the book to check out: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= books.Count)
            {
                var book = books[index - 1];
                if (book.CheckOut())
                {
                    Console.WriteLine($"You have checked out '{book.Title}'. Due date: {book.DueDate:MM/dd/yyyy}");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{book.Title}' is already checked out.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public void ReturnBook()
        {
            DisplayBooks();
            Console.Write("Enter the number of the book to return: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= books.Count)
            {
                var book = books[index - 1];
                book.ReturnBook();
                Console.WriteLine($"'{book.Title}' has been returned and is now available.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private void InitializeDefaultBooks()
        {
            var defaultBooks = new[]
            {
                new Book { Title = "Harry Potter", Author = "J.K. Rowling" },
                new Book { Title = "Tango", Author = "Slawomir Mrozek" },
                new Book { Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien" },
                new Book { Title = "High-Performance Programming in C# and .Net", Author = "Jason Alls" },
                new Book { Title = "Двенадцать стульев", Author = "Евгений Петров" },
                new Book { Title = "Hacking: The Art of Exploitation", Author = "Jon Erickson" },
                new Book { Title = "How to Stop Worrying and Start Living", Author = "Dale Carnegie" },
                new Book { Title = "Brave New World", Author = "Aldous Huxley" },
                new Book { Title = "Cybersecurity Handbook 2025", Author = "Royal Kenny" },
                new Book { Title = "Java Programming", Author = "Joyce Farrell" },
                new Book { Title = "Research Design", Author = "John W. Creswell" },
                new Book { Title = "Fundamentals of Management", Author = "Ricky W. Griffin" }
            };
            books.AddRange(defaultBooks);
        }
    }
}