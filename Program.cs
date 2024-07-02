// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

List<Product> products = new List<Product>()
{
  new Product()
  {
    Name = "Football",
    Price = 15,
    Sold = false,
    Color = "Brown",
    StockDate = new DateTime(2022, 10, 20),
    ManufactureYear = 2010
  },
  new Product()
  {
    Name = "Hockey Stick",
    Price = 12,
    Sold = false,
    Color = "Pink",
    StockDate = new DateTime(2024, 1, 28),
    ManufactureYear = 2024
  },
  new Product()
  {
    Name = "Volleyball",
    Price = 7,
    Sold = false,
    Color = "Purple",
    StockDate = new DateTime(2023, 11, 20),
    ManufactureYear = 2023
  },
  new Product()
  {
    Name = "Frisbee",
    Price = 12,
    Sold = true,
    Color = "Blue",
    StockDate = new DateTime(2020, 10, 20),
    ManufactureYear = 2009
  },
  new Product()
  {
    Name = "Golf Putter",
    Price = 125,
    Sold = false,
    Color = "Silver",
    StockDate = new DateTime(2023, 7, 20),
    ManufactureYear = 2010
  },
  new Product()
  {
    Name = "Skis",
    Price = 99,
    Sold = false,
    Color = "Red",
    StockDate = new DateTime(2022, 10, 20),
    ManufactureYear = 2002
  }
};

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);

Console.WriteLine(products);
for (int i = 0; i < products.Count; i++)
{
  Console.WriteLine($"{i + 1}. {products[i].Name}");
}
Console.WriteLine("Please enter a product number: ");
int response = int.Parse(Console.ReadLine().Trim());

while (response > products.Count || response < 1)
{
  Console.WriteLine("Choose a number between 1 and 5!");
  response = int.Parse(Console.ReadLine().Trim());
}
  Product chosenProduct = products[response-1];
  DateTime now = DateTime.Now;
  TimeSpan timeInStock = now - chosenProduct.StockDate;
  Console.WriteLine(@$"You chose: 
{chosenProduct.Color} {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old.
It {(chosenProduct.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}");
