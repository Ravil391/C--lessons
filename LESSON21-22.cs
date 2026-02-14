using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;



//sdas

class Author
{
    public string Name { get; set; }
    public string Country { get; set; }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public List<string> Tags { get; set; }
}

class Program
{
    static void Main()
    {
        string authorsJson = File.ReadAllText("authors.json");
        string booksJson = File.ReadAllText("books.json");

        var authors = JsonSerializer.Deserialize<List<Author>>(authorsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


        var topPriceBooks = books
            .Where(b => b.Year >= 1950)
            .OrderByDescending(b => b.Price)
            .Take(3)
            .ToList();


        var bookLabels = books
            .OrderBy(b => b.Title)
            .Select(b => $"{b.Title} ({b.Year}) — {b.Price}")
            .ToList();

      
        var booksWithAuthors = books
            .Join(authors, 
                b => b.Author, 
                a => a.Name, 
                (b, a) => $"{b.Title} — {a.Name} ({a.Country})")
            .OrderBy(s => s.Split(" — ")[1])
            .ToList();

   
        var uniqueTags = books
            .SelectMany(b => b.Tags)
            .Distinct()
            .OrderBy(t => t)
            .ToList();

    
        topPriceBooks.ForEach(b => Console.WriteLine($"{b.Title}: {b.Price}"));
        Console.WriteLine("---");
        bookLabels.ForEach(Console.WriteLine);
        Console.WriteLine("---");
        booksWithAuthors.ForEach(Console.WriteLine);
        Console.WriteLine("---");
        uniqueTags.ForEach(Console.WriteLine);
    }
}
