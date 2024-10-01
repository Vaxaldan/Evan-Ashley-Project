using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Caffeine_Overflow
{
    public class Payment
    {
        public double SubTotal()
        {
            double subTotal;

            Console.WriteLine("Please enter the subtotal: ");

            while (true)
            {
                subTotal = double.Parse(Console.ReadLine());
                if (subTotal < 0)
                {
                    Console.WriteLine("Invalid input, please enter a positive numeric value.");
                    Console.WriteLine("Enter the subtotal: ");
                    continue;
                }
                break;
            }
            return subTotal;
        }

        public double Total()  // Ask about how to set up a method as an intake, if not work on simplifying
        {
            double total = SubTotal() * 0.006;
            return total;
        }


        public double CashPayment(double total, double amountTendered) // put total method in as parameter
        { 
            double change = amountTendered - total;
            return change;
        }

        public string CheckPayment(double total)
        {
            string checkNumber = "";

            Console.WriteLine("Please enter the check number (numeric value only)");

            while (true)
            {
                checkNumber = Console.ReadLine();
                if (checkNumber.Length != 21)
                {
                    Console.WriteLine("Invalid input, please double check the check numbers");
                    Console.WriteLine("Enter the check numbers");
                    continue;
                }
                Console.WriteLine($"Check number {checkNumber} accepted for a total payment of {total}.");
                break;
            }
                return checkNumber;
        }
        public string CreditCardPayment(double total)
        {
            string cardNumber = "";
            
            Console.WriteLine("Please enter your 16 digit card number. (numeric value only)");

            while (true)
            {
                cardNumber = Console.ReadLine();
                if (cardNumber.Length != 16)
                {
                    Console.WriteLine("Invalid card number.");
                    Console.WriteLine("Please enter your 16 digit card number");
                    continue;
                }
                break;
            }
            
            string expireDate = "";
            
            Console.WriteLine("Please enter your experation date. (MM/YY)"); //check that date is valid
            expireDate = Console.ReadLine();

            string cvv = "";
           
            Console.WriteLine("Please enter your CVV.");

            while (true)
            {
                cvv = Console.ReadLine();
                if (cvv.Length != 3)
                {
                    Console.WriteLine("Invalid CVV.");
                    Console.WriteLine("Re-enter your CVV.");
                    continue;
                }
                break;
            }
            return $"Your payment for {cardNumber} is approved."; 
        }

        public string Recipt() 
        {
           
            // want this to take input from menu method to see what they order,
            // subtotal and total to print the subtotal and the total and the tax,
            // and to be able to take that into the payment method to be able to return a recipt 
            
            
            string printRecipt = "";

            return printRecipt;
        }





    } // end of class

   
    
} // end of namespace
