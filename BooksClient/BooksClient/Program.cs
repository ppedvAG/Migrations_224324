// See https://aka.ms/new-console-template for more information
using BooksClient;
using System.Text.Json;

Console.WriteLine("Hello, World!");


var url = "https://www.googleapis.com/books/v1/volumes?q=dotnet";

var http = new HttpClient();
var json = await http.GetStringAsync(url);

var books = JsonSerializer.Deserialize<BookResult>(json);

//Console.WriteLine(json);

foreach (var book in books.items)
    Console.WriteLine(book.volumeInfo.title);
