using Caffeine_Overflow;

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

// menu class responsible for handling the display of products
public class Menu
{
    public List<ProductMenu> MenuItems { get; private set; }  // List of menu items, accessible only within this class

   
    public Menu()
    {
        MenuItems = new List<ProductMenu>  // List of products 
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

    // Method to display the menu to the user
    public void DisplayMenu()
    {
        Console.WriteLine("Welcome to Caffeine Overflow! Here's our menu:\n");

        // Print table header
        Console.WriteLine("---------------------------------------------------------------------------------------------------");
        Console.WriteLine("Name                      | Category     | Price  | Description");
        Console.WriteLine("---------------------------------------------------------------------------------------------------");

        // Loop through each menu item and display its details
        foreach (var item in MenuItems)
        {
            string name = item.Name.PadRight(25);                  // Format name with padding
            string category = item.Category.PadRight(12);          // Format category with padding
            string price = item.Price.ToString("C2").PadLeft(6);   // Format price as currency
            string description = item.Description.Length > 55 ?    
                item.Description.Substring(0, 37) + "..." :
                item.Description;

            // print the menu item
            Console.WriteLine($"{name} | {category} | {price} | {description}");
        }

        Console.WriteLine("---------------------------------------------------------------------------------------------------");
    }
    // Method to find a product by its name
    public ProductMenu FindProductByName(string productName)
    {
        foreach (var item in MenuItems)
        {
            if (string.Equals(item.Name, productName, StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }
        return null;
    }
}

// Order class stores the ordered items and calculates the subtotal.
public class Order
{
    public List<ProductMenu> OrderedItems { get; private set; }
    public double SubTotal { get; private set; }

    public Order()
    {
        OrderedItems = new List<ProductMenu>();
        SubTotal = 0;
    }

    public void AddItem(ProductMenu item)
    {
        OrderedItems.Add(item);
        SubTotal += (double)item.Price;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("\nYour order:");
        foreach (var item in OrderedItems)
        {
            Console.WriteLine($"{item.Name} - {item.Price:C2}");
        }
        Console.WriteLine($"Subtotal: {SubTotal:C2}");
    }
}

// OrderManager class handles taking the order and processing payments.
public class OrderManager
{
    private Menu menu;
    private Order currentOrder;
    private Payment payment;

    public OrderManager(Menu menu)
    {
        this.menu = menu;
        currentOrder = new Order();
        payment = new Payment();
    }

    public void TakeOrder()
    {
        while (true)
        {
            Console.WriteLine("\nWould you like to see the menu again? (yes/no)");
            string seeMenu = Console.ReadLine();
            if (seeMenu.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                menu.DisplayMenu();
            }

            Console.WriteLine("Enter the name of the product you want to order:");
            string orderName = Console.ReadLine();
            ProductMenu selectedProduct = menu.FindProductByName(orderName);

            if (selectedProduct != null)
            {
                currentOrder.AddItem(selectedProduct);
                Console.WriteLine($"{selectedProduct.Name} added to your order.");
            }
            else
            {
                Console.WriteLine("Sorry, we don't have that item on the menu.");
            }

            Console.WriteLine("Would you like to order another item? (yes/no)");
            string continueOrder = Console.ReadLine();
            if (continueOrder.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }

        currentOrder.DisplayOrder();
        ProcessPayment();
    }

    private void ProcessPayment()
    {
        double subTotal = currentOrder.SubTotal;
        double total = payment.CalculateTotal(subTotal);

        Console.WriteLine($"\nYour total (including tax) is: {total:C2}");
        Console.WriteLine("Select payment method (cash/check/card):");
        string paymentMethod = Console.ReadLine().ToLower();

        switch (paymentMethod)
        {
            case "cash":
                Console.WriteLine("Enter amount tendered:");
                double amountTendered = Convert.ToDouble(Console.ReadLine());
                double change = payment.CashPayment(total, amountTendered);
                if (change >= 0)
                {
                    Payment.Receipt(subTotal, total);
                }
                break;

            case "check":
                payment.CheckPayment(total);
                Payment.Receipt(subTotal, total);
                break;

            case "card":
                payment.CreditCardPayment(total);
                Payment.Receipt(subTotal, total);
                break;

            default:
                Console.WriteLine("Invalid payment method selected. Please try again.");
                ProcessPayment();
                break;
        }
    }
}

