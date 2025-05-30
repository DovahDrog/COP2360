using System;

public class Stock
{
    // Backing fields
    private decimal currentPrice;
    private int sharesOwned;

    // Public properties
    public decimal CurrentPrice
    {
        get => currentPrice;
        set => currentPrice = value;
    }

    public int SharesOwned
    {
        get => sharesOwned;
        set => sharesOwned = value;
    }

    // Read-only calculated property
    public decimal Worth => CurrentPrice * SharesOwned;

    // Constructor
    public Stock(decimal price, int shares)
    {
        CurrentPrice = price;
        SharesOwned = shares;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the price per share:");
            string priceInput = Console.ReadLine();

            Console.WriteLine("Enter the number of shares you own:");
            string sharesInput = Console.ReadLine();

            decimal price = Convert.ToDecimal(priceInput);
            int shares = Convert.ToInt32(sharesInput);

            Stock myStock = new Stock(price, shares);

            Console.WriteLine($"Total worth of your stock holdings: ${myStock.Worth}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Input error: Please enter valid numbers.");
            Console.WriteLine($"Details: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine($"Details: {ex.Message}");
        }
    }
}

