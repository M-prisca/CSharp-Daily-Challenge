using System;
using System.Linq;
using System.Collections.Generic;

public class ShoppingCart
{
    private readonly List<decimal> _prices = new();

    public void AddItem(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than Zero.");
        }
        _prices.Add(price);

    }
    public decimal GetTotal()
    {
        return _prices.Sum();

    }
    public int GetItemCount()
    {
        return _prices.Count();

    }

}
class Program
{
    static void Main(string[] args)
    {
        ShoppingCart Cart = new ShoppingCart();

        Cart.AddItem(100);
        Cart.AddItem(20);

        Console.WriteLine(Cart.GetTotal());
        Console.WriteLine(Cart.GetItemCount());
    }
}
