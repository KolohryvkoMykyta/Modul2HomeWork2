namespace Modul2Homework2
{
    public static class Actions
    {
        public static Customer GetCustomer()
        {
            string? customerName;
            decimal moneyOnCard;
            bool isValidCart;

            Console.WriteLine("\tWelcome to Tire Store 'Tires by Nikita'\n");
            Console.Write("Please enter your name: ");

            customerName = Console.ReadLine();
            customerName = customerName?.Trim();

            while (string.IsNullOrEmpty(customerName))
            {
                Console.Write("Name must not be empty. Try again: ");
                customerName = Console.ReadLine();
                customerName = customerName?.Trim();
            }

            Console.WriteLine($"\nHello {customerName}!");
            Console.Write("\nPlease enter the amount of money on the card (in UAH): ");

            isValidCart = decimal.TryParse(Console.ReadLine(), out moneyOnCard);

            while (!isValidCart || moneyOnCard <= 0)
            {
                Console.Write("Incorrect value! Input a number greater than zero: ");
                isValidCart = decimal.TryParse(Console.ReadLine(), out moneyOnCard);
            }

            return new Customer() { Name = customerName, Money = moneyOnCard };
        }

        public static void MakePurchase(CustomerBag customerBag, Product[] selectedProducts)
        {
            int productNumber;
            int sumProduct;
            bool isConversionSuccessful;
            bool isSumCorrect;

            Console.WriteLine("\nSelect the tires you want to add to bag");
            Console.WriteLine($"(Input item number from 1 to {selectedProducts.Length})");
            isConversionSuccessful = int.TryParse(Console.ReadLine(), out productNumber);

            while (!isConversionSuccessful || productNumber <= 0 || productNumber > selectedProducts.Length)
            {
                Console.WriteLine("The selected product does not exist");
                Console.WriteLine($"Try again: Input item number from 1 to {selectedProducts.Length}");
                isConversionSuccessful = int.TryParse(Console.ReadLine(), out productNumber);
            }

            productNumber--;
            Console.WriteLine($"\nYou choosed: {selectedProducts[productNumber].Name} {selectedProducts[productNumber].Size} {selectedProducts[productNumber].Radius} {selectedProducts[productNumber].Price} UAH\n");
            Console.WriteLine($"How many tires do you want to add to bag? (Max - {10 - customerBag.PurchasesNumer})");
            isSumCorrect = int.TryParse(Console.ReadLine(), out sumProduct);

            while (!isSumCorrect || sumProduct <= 0 || sumProduct > (10 - customerBag.PurchasesNumer))
            {
                Console.WriteLine($"Incorrect value! Input number from 1 to {10 - customerBag.PurchasesNumer}");
                isSumCorrect = int.TryParse(Console.ReadLine(), out sumProduct);
            }

            for (int i = 0; i < sumProduct; i++)
            {
                customerBag.AddProduct(selectedProducts[productNumber]);
            }

            Console.WriteLine($"\nAdded to Bag: {sumProduct} {selectedProducts[productNumber].Name} {selectedProducts[productNumber].Size} {selectedProducts[productNumber].Radius} {selectedProducts[productNumber].Price * sumProduct} UAH");
        }

        public static Order? ProcessingOrder(Customer customer)
        {
            Order? order;

            if (customer.Money >= customer.Bag.TotalPrice)
            {
                order = new Order() { Products = customer.Bag.Bag };
            }
            else
            {
                order = null;
            }

            return order;
        }
    }
}
