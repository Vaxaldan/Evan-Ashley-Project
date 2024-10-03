using System;
using System.Collections.Generic;

namespace Caffeine_Overflow
{
    // Product class to represent a menu item
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
    }

    // Menu class responsible for handling the display of products
    public class Menu
    {
        public List<ProductMenu> MenuItems { get; private set; }

        public Menu()
        {
            MenuItems = new List<ProductMenu>
            {
                new ProductMenu("Debugger Brew", "Beverage", "A coffee that helps troubleshoot your day.", 3.00m),
                new ProductMenu("Lambda Latte", "Beverage", "Smooth espresso with vanilla, ideal for coding.", 4.50m),
                new ProductMenu("C# Cheesecake", "Dessert", "Creamy cheesecake with a touch of C# sweetness.", 5.00m),
                new ProductMenu("Namespace Nachos", "Food", "Crunchy nachos organized in a cheesy namespace.", 6.00m),
                new ProductMenu("Object-Oriented Omelette", "Food", "Fluffy omelette, encapsulated for flavor.", 7.50m),
                new ProductMenu("Async Smoothie", "Beverage", "Refreshing fruit blend, prepared asynchronously.", 4.00m),
                new ProductMenu("Array of Cookies", "Dessert", "A selection of cookies, perfectly indexed.", 3.50m),
                new ProductMenu("Constructor Curry", "Food", "A flavorful curry dish that initializes your hunger.", 8.00m),
                new ProductMenu("Generic Grits", "Food", "Versatile grits that can be paired with any dish.", 4.00m),
                new ProductMenu("Refactoring Wrap", "Food", "A fresh wrap that improves with each bite.", 6.50m),
                new ProductMenu("Inheritance Ice Cream", "Dessert", "Layered ice cream with classic flavors.", 5.50m),
                new ProductMenu("Unit Test Tea", "Beverage", "A calming herbal tea that's always a passing test.", 2.50m)
            };
        }

        // Display menu
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Caffeine Overflow! Here's our menu:\n");

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Name                      | Category     | Price  | Description");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var item in MenuItems)
            {
                string name = item.Name.PadRight(25);
                string category = item.Category.PadRight(12);
                string price = item.Price.ToString("C2").PadLeft(6);
                string description = item.Description.Length > 55 ? item.Description.Substring(0, 37) + "..." : item.Description;

                Console.WriteLine($"{name} | {category} | {price} | {description}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        // Find a product by name
        public ProductMenu FindProductByName(string productName)
        {
            return MenuItems.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }
    }

    // Order class to store the details of an order
    public class Order
    {
        public List<ProductMenu> OrderedItems { get; private set; }
        public double SubTotal { get; private set; }

        public Order()
        {
            OrderedItems = new List<ProductMenu>();
            SubTotal = 0;
        }

        // Add item to the order
        public void AddItem(ProductMenu item)
        {
            OrderedItems.Add(item);
            SubTotal += (double)item.Price;
        }

       
    }

    // OrderManager class that handles taking orders and storing them
    public class OrderManager
    {
        private Menu menu;
        private List<Order> allOrders; // Store all orders

        public OrderManager(Menu menu)
        {
            this.menu = menu;
            allOrders = new List<Order>(); // Initialize the list of orders
        }

        // Take an order from a customer
        public void TakeOrder()
        {
            Order newOrder = new Order();

            while (true)
            {
                Console.WriteLine("Would you like to see the menu again? (yes/no)");
                string seeMenu = Console.ReadLine();
                if (seeMenu.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    menu.DisplayMenu();
                }

                Console.WriteLine("What would you like to order?");
                string orderName = Console.ReadLine();
                ProductMenu selectedProduct = menu.FindProductByName(orderName);

                if (selectedProduct != null)
                {
                    newOrder.AddItem(selectedProduct);
                    Console.WriteLine($"You ordered a {selectedProduct.Name}. ");
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have that on the menu.");
                }

                Console.WriteLine("Would you like to order something else? (yes/no)");
                string continueOrder = Console.ReadLine();
                if (continueOrder.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            allOrders.Add(newOrder);
        }

        public void DisplayAllOrders()
        {
            Console.WriteLine("\n------- All Orders -------");
            foreach (var order in allOrders)
            {
                Console.WriteLine("\nOrder Details:");
                foreach (var item in order.OrderedItems)
                {
                    // Print only the item name, no price
                    Console.WriteLine($"{item.Name}");
                }
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Menu cafeMenu = new Menu(); 
            OrderManager orderManager = new OrderManager(cafeMenu);

            cafeMenu.DisplayMenu(); 
            orderManager.TakeOrder(); 

            orderManager.DisplayAllOrders();
        }
    }
}
