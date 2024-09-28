using System;
using System.Collections.Generic;

namespace Caffeine_Overflow
{
    public class ProductMenu
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductMenu(string name, string category, string description, decimal price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Description: {Description}, Price: ${Price}";
        }
    }

    public class CoffeeShop
    {
        private List<ProductMenu> menuItems;
        public CoffeeShop() => menuItems = new List<ProductMenu>
            {
                new ProductMenu("Espresso", "Beverage", "Rich and bold espresso shot.", 2.50m),
                new ProductMenu("Latte", "Beverage", "Smooth espresso with steamed milk.", 4.00m),
                new ProductMenu("Cappuccino", "Beverage", "Espresso with steamed milk and foam.", 4.00m),
                new ProductMenu("Americano", "Beverage", "Espresso with hot water.", 3.00m),
                new ProductMenu("Mocha", "Beverage", "Espresso with chocolate and steamed milk.", 4.50m),
                new ProductMenu("Bagel with Cream Cheese", "Food", "Fresh bagel served with cream cheese.", 3.00m),
                new ProductMenu("Croissant", "Food", "Buttery and flaky croissant.", 2.75m),
                new ProductMenu("Blueberry Muffin", "Food", "Moist muffin with fresh blueberries.", 2.50m),
                new ProductMenu("Turkey Sandwich", "Food", "Turkey sandwich with lettuce and tomato.", 6.50m),
                new ProductMenu("Veggie Wrap", "Food", "Wrap filled with fresh vegetables.", 5.50m),
                new ProductMenu("Chocolate Chip Cookie", "Food", "Classic cookie with chocolate chips.", 1.75m),
                new ProductMenu("Fruit Smoothie", "Beverage", "Blend of fresh fruits and yogurt.", 5.00m)

            };
        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
