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

        public double CalculateTotal(double subTotal)  
        {
            return (subTotal * 0.06) + subTotal;
        }


        public double CashPayment(double total, double amountTendered)
        {
            {
                if (amountTendered >= total)
                {
                    double change = amountTendered - total;
                    Console.WriteLine($"Cash payment successful. Change: {change:C2}");
                    return change;
                }
                else
                {
                    Console.WriteLine("Insufficient cash provided. Payment failed.");
                    return -1;  
                }
            }
        }

        public void CheckPayment(double total)
        {
            Console.WriteLine("Please enter the check number (21 digits, numeric only):");
            string checkNumber = Console.ReadLine();

            while (string.IsNullOrEmpty(checkNumber) || checkNumber.Length != 21 || !long.TryParse(checkNumber, out _))
            {
                Console.WriteLine("Invalid check number. Please enter a valid 21-digit check number:");
                checkNumber = Console.ReadLine();
            }

            Console.WriteLine($"Check number {checkNumber} accepted for a total payment of {total:C2}.");
        }

        public void CreditCardPayment(double total)
        {
            Console.WriteLine("Please enter your 16-digit card number:");
            string cardNumber = Console.ReadLine();

            while (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16 || !long.TryParse(cardNumber, out _))
            {
                Console.WriteLine("Invalid card number. Please enter a valid 16-digit card number:");
                cardNumber = Console.ReadLine();
            }

            Console.WriteLine("Please enter your expiration date (MM/YY):");
            string expireDate = Console.ReadLine();
            // Additional validation for expiration date could be added here

            Console.WriteLine("Please enter your CVV (3 digits):");
            string cvv = Console.ReadLine();

            while (string.IsNullOrEmpty(cvv) || cvv.Length != 3 || !int.TryParse(cvv, out _))
            {
                Console.WriteLine("Invalid CVV. Please enter a valid 3-digit CVV:");
                cvv = Console.ReadLine();
            }

            Console.WriteLine($"Credit card payment for {total:C2} is approved.");
        }

        public static void Receipt(double subTotal, double total)
        {
            double tax = total - subTotal;
            Console.WriteLine("\n======= Receipt =======");
            Console.WriteLine($"Subtotal:    {subTotal:C2}");
            Console.WriteLine($"Tax (6%):    {tax:C2}");
            Console.WriteLine($"Total:       {total:C2}");
            Console.WriteLine("=======================");
        }





    } // end of class

   
    
} // end of namespace
