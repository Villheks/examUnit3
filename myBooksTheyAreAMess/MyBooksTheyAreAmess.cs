
using System.Text.Json;



public class Program
{

    static void Main(string[] args)
    {
        
            
            string filePath = "books.json";
            List<Book> books = MyFunctions.ReadBooksFromFile(filePath);
            List<string> allAuthors = MyFunctions.GetAllAuthors(books);
            Console.WriteLine("Books starting with 'The':");
            foreach (Book book in MyFunctions.BooksStartingWithThe(books))
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("\nBooks by authors with 't' in their name:");
            foreach (Book book in MyFunctions.BooksByAuthorsWithT(books))
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine($"\nNumber of books written after 1992: {MyFunctions.NumberOfBooksWrittenAfter1992(books)}");
            Console.WriteLine($"Number of books written before 2004: {MyFunctions.NumberOfBooksWrittenBefore2004(books)}");


            Console.WriteLine("Authors in the file:");
            foreach (string author in allAuthors)
            {
                Console.WriteLine(author);
            }

            List<string> isbns = null;
            string authorInput;
            do
            {
                Console.WriteLine("\nEnter author name:");
                authorInput = Console.ReadLine();

                isbns = MyFunctions.IsbnNumbersForAuthor(books, authorInput);
                if (isbns == null)
                {
                    Console.WriteLine("Author not found or no books found for the author. Try again.");
                }
            } while (isbns == null);

            Console.WriteLine("\nISBN numbers for author " + authorInput);
            foreach (string isbn in isbns)
            {
                Console.WriteLine(isbn);
            }
        
            Console.WriteLine("Do you want to see the books listed alphabetically acsending or descending?");
            string userInput = Console.ReadLine();
            if (userInput == "acsending")
            {
                List<Book> sortedAlphabeticallyAscending = MyFunctions.SortBooksAlphabeticallyAscending(books);
                foreach (Book book in sortedAlphabeticallyAscending)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }
            else if (userInput == "descending")
            {
                List<Book> sortedAlphabeticallyDescending = MyFunctions.SortBooksAlphabeticallyDescending(books);
                foreach (Book book in sortedAlphabeticallyDescending)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }
            else 
            {
                Console.WriteLine("Please send a valid input!");
            }
            Console.WriteLine("Do you want to see the books listed chronologically acsending or descending?");
            string userInput2 = Console.ReadLine();
            if (userInput2 == "acsending")
            {
                List<Book> sortedChronologicallyAscending = MyFunctions.SortBooksChronologicallyAscending(books);
                foreach (Book book in sortedChronologicallyAscending)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }
            else if (userInput2 == "descending")
            {
                List<Book> sortedChronologicallyDescending = MyFunctions.SortBooksChronologicallyDescending(books);
                foreach (Book book in sortedChronologicallyDescending)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }
            else 
            {
                Console.WriteLine("Please send a valid input!");
            }
            Dictionary<string, List<Book>> groupedByLastName = MyFunctions.GroupBooksByAuthorLastName(books);
            foreach (KeyValuePair<string, List<Book>> kvp in groupedByLastName)
            {
                Console.WriteLine($"Books by {kvp.Key}:");
                foreach (Book book in kvp.Value)
                {
                    Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
                }
            }
            Dictionary<string, List<Book>> groupedByFirstName = MyFunctions.GroupBooksByAuthorFirstName(books);
            foreach (KeyValuePair<string, List<Book>> kvp in groupedByFirstName)
            {
                Console.WriteLine($"Books by {kvp.Key}:");
                foreach (Book book in kvp.Value)
                {
                    Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
                }
            }
        
    }
}

public class MyFunctions
{
    public static List<string> GetAllAuthors(List<Book> books)
    {
        HashSet<string> allAuthors = new HashSet<string>();
        foreach (Book book in books)
        {
            allAuthors.Add(book.Author);
        }
        return new List<string>(allAuthors);
    }
    public static List<Book> ReadBooksFromFile(string filePath)
    {
        List<Book> books = new List<Book>();
        using (StreamReader file = File.OpenText(filePath))
        {
            string jsonString = file.ReadToEnd();
            JsonDocument doc = JsonDocument.Parse(jsonString);
            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            {
                Book book = new Book();
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    if (property.NameEquals("title"))
                        book.Title = property.Value.GetString();
                    else if (property.NameEquals("publication_year"))
                        book.PublicationYear = property.Value.GetInt32();
                    else if (property.NameEquals("author"))
                        book.Author = property.Value.GetString();
                    else if (property.NameEquals("isbn"))
                        book.Isbn = property.Value.GetString();
                }
                books.Add(book);
            }
        }
        return books;
    }

    public static List<Book> BooksStartingWithThe(List<Book> books)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Title.StartsWith("The"))
            {
                result.Add(book);
            }
        }
        return result;
    }

    public static List<Book> BooksByAuthorsWithT(List<Book> books)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Author.ToLower().Contains('t'))
            {
                result.Add(book);
            }
        }
        return result;
    }

    public static int NumberOfBooksWrittenAfter1992(List<Book> books)
    {
        int count = 0;
        foreach (Book book in books)
        {
            if (book.PublicationYear > 1992)
            {
                count++;
            }
        }
        return count;
    }

    public static int NumberOfBooksWrittenBefore2004(List<Book> books)
    {
        int count = 0;
        foreach (Book book in books)
        {
            if (book.PublicationYear < 2004)
            {
                count++;
            }
        }
        return count;
    }

    public static List<string> IsbnNumbersForAuthor(List<Book> books, string author)
    {
        List<string> result = new List<string>();
        foreach (Book book in books)
        {
            if (book.Author.ToLower().Contains(author.ToLower()))
            {
                result.Add(book.Isbn);
            }
        }
        return result.Count > 0 ? result : null; 
    }
    public static List<Book> SortBooksAlphabeticallyAscending(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = 0; j < books.Count - 1 - i; j++)
            {
                if (string.Compare(books[j].Title, books[j + 1].Title) > 0)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
        return books;
    }

    public static List<Book> SortBooksAlphabeticallyDescending(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = 0; j < books.Count - 1 - i; j++)
            {
                if (string.Compare(books[j].Title, books[j + 1].Title) < 0)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
        return books;
    }

    public static List<Book> SortBooksChronologicallyAscending(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = 0; j < books.Count - 1 - i; j++)
            {
                if (books[j].PublicationYear > books[j + 1].PublicationYear)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
        return books;
    }

    public static List<Book> SortBooksChronologicallyDescending(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = 0; j < books.Count - 1 - i; j++)
            {
                if (books[j].PublicationYear < books[j + 1].PublicationYear)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
        return books;
    }

     public static Dictionary<string, List<Book>> GroupBooksByAuthorLastName(List<Book> books)
    {
        Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();

        foreach (Book book in books)
        {
            string[] authorNameParts = book.Author.Split(' ');
            string lastName = authorNameParts[authorNameParts.Length - 1];

            if (!groupedBooks.ContainsKey(lastName))
            {
                groupedBooks[lastName] = new List<Book>();
            }

            groupedBooks[lastName].Add(book);
        }

        return groupedBooks;
    }
    public static Dictionary<string, List<Book>> GroupBooksByAuthorFirstName(List<Book> books)
    {
        Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();

        foreach (Book book in books)
        {
            string[] authorNameParts = book.Author.Split(' ');
            string firstName = authorNameParts[0];

            if (!groupedBooks.ContainsKey(firstName))
            {
                groupedBooks[firstName] = new List<Book>();
            }

            groupedBooks[firstName].Add(book);
        }

        return groupedBooks;
    }

}
public class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
}
