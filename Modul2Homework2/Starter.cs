namespace Modul2Homework2
{
    public static class Starter
    {
        public static void Run()
        {
            bool repeatFlag = true;
            var customer = Presentation.GetCustomer();

            while (repeatFlag)
            {
                Product[] selectedProducts = ProductsList.DisplayProduct();
                PurchaseProcessor.MakePurchase(customer.Bag, selectedProducts);

                repeatFlag = AskCustomerToProceed(customer);
            }

            var order = OrderProcessor.ProcessingOrder(customer);

            if (order != null)
            {
                Console.WriteLine($"\nYour order {order.Number} successfully created");
                Console.WriteLine("You ordered:");

                for (int i = 0; i < order.Products!.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {order.Products[i].Name} {order.Products[i].Size} {order.Products[i].Radius} {order.Products[i].Price} UAH");
                }

                Console.WriteLine("Thank you for choosing our store!");
            }
            else
            {
                Console.WriteLine("\nFailed to create order!");
                Console.WriteLine("Not enough money on the card to pay!");
            }

            Console.ReadKey();
        }

        private static bool AskCustomerToProceed(Customer customer)
        {
            if (customer.Bag.PurchasesNumer < 10)
            {
                return AskCustomerToProceedWithNotFullBag(customer);
            }
            else
            {
                return AskCustomerToProceedWithFullBag(customer);
            }
        }

        private static bool AskCustomerToProceedWithFullBag(Customer customer)
        {
            Console.WriteLine("\nTo place an order press 1");
            Console.WriteLine("To clean bag press 2");

            char customerChoice = Console.ReadKey(true).KeyChar;

            while (customerChoice != '1' && customerChoice != '2')
            {
                Console.WriteLine("Incorrect input! Press 1 or 2!");
                customerChoice = Console.ReadKey(true).KeyChar;
            }

            if (customerChoice == '1')
            {
                return false;
            }

            customer.Bag.CleanBag();

            return true;
        }

        private static bool AskCustomerToProceedWithNotFullBag(Customer customer)
        {
            Console.WriteLine("\nTo continue shopping press 1");
            Console.WriteLine("To place an order press 2");
            Console.WriteLine("To clean bag press 3");

            char customerChoice = Console.ReadKey(true).KeyChar;

            while (customerChoice != '1' && customerChoice != '2' && customerChoice != '3')
            {
                Console.WriteLine("Incorrect input! Press 1, 2 or 3!");
                customerChoice = Console.ReadKey(true).KeyChar;
            }

            if (customerChoice == '3')
            {
                customer.Bag.CleanBag();
                return true;
            }

            return customerChoice == '1' ? true : false;
        }
    }
}
