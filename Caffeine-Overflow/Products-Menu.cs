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
            new ProductMenu("Debugger Brew", "Beverage", "A strong coffee that helps you troubleshoot your day.", 3.00m),
            new ProductMenu("Lambda Latte", "Beverage", "A smooth espresso with a hint of vanilla, perfect for functional coding.", 4.50m),
            new ProductMenu("C# Cheesecake", "Dessert", "Creamy cheesecake with a touch of C# sweetness.", 5.00m),
            new ProductMenu("Namespace Nachos", "Food", "Crunchy nachos organized in a cheesy namespace.", 6.00m),
            new ProductMenu("Object-Oriented Omelette", "Food", "A fluffy omelette filled with your choice of ingredients, encapsulated for flavor.", 7.50m),
            new ProductMenu("Async Smoothie", "Beverage", "A refreshing blend of fruits, prepared asynchronously for maximum flavor.", 4.00m),
            new ProductMenu("Array of Cookies", "Dessert", "A selection of cookies, perfectly indexed for your enjoyment.", 3.50m),
            new ProductMenu("Constructor Curry", "Food", "A flavorful curry dish that initializes your hunger.", 8.00m),
            new ProductMenu("Generic Grits", "Food", "Versatile grits that can be paired with any dish.", 4.00m),
            new ProductMenu("Refactoring Wrap", "Food", "A fresh wrap that improves your lunch experience with every bite.", 6.50m),
            new ProductMenu("Inheritance Ice Cream", "Dessert", "A layered ice cream dessert that builds on classic flavors.", 5.50m),
            new ProductMenu("Unit Test Tea", "Beverage", "A calming herbal tea that's always a passing test.", 2.50m)

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
