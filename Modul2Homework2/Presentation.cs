namespace Modul2Homework2
{
    public static class Presentation
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
    }
}
