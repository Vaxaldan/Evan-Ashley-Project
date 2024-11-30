public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        OrderManager orderManager = new OrderManager(menu);

        Console.WriteLine("Welcome to Caffeine Overflow!");

        // Display menu at the start
        menu.DisplayMenu();

        // Take order and process payment
        orderManager.TakeOrder();

        Console.WriteLine("Thank you for visiting Caffeine Overflow! Have a great day!");
    }
}
