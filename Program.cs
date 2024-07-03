// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

List<Product> products = new List<Product>()
{
  new Product()
  {
    Name = "Football",
    Price = 15.00M,
    Sold = false,
    Color = "Brown",
    StockDate = new DateTime(2024, 6, 20),
    ManufactureYear = 2010,
    Condition = 4.2
  },
  new Product()
  {
    Name = "Hockey Stick",
    Price = 12.00M,
    Sold = false,
    Color = "Pink",
    StockDate = new DateTime(2024, 1, 28),
    ManufactureYear = 2024,
    Condition = 3.7
  },
  new Product()
  {
    Name = "Volleyball",
    Price = 7.00M,
    Sold = false,
    Color = "Purple",
    StockDate = new DateTime(2023, 11, 20),
    ManufactureYear = 2023,
    Condition = 3.9
  },
  new Product()
  {
    Name = "Frisbee",
    Price = 12.00M,
    Sold = true,
    Color = "Blue",
    StockDate = new DateTime(2024, 5, 20),
    ManufactureYear = 2009,
    Condition = 4.6
  },
  new Product()
  {
    Name = "Golf Putter",
    Price = 125.00M,
    Sold = false,
    Color = "Silver",
    StockDate = new DateTime(2023, 7, 20),
    ManufactureYear = 2010,
    Condition = 4.9
  },
  new Product()
  {
    Name = "Skis",
    Price = 99.00M,
    Sold = false,
    Color = "Red",
    StockDate = new DateTime(2022, 10, 20),
    ManufactureYear = 2002,
    Condition = 3.3
  }
};

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{
    ListProducts();
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only type integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
{chosenProduct.Color} {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old.
The condition of the item is rated at {chosenProduct.Condition}.
It {(chosenProduct.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine(products);
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    List<Product> latestProducts = new List<Product>();
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    foreach (Product product in products)
    {
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i+1}. {latestProducts[i].Name}");
    }
}