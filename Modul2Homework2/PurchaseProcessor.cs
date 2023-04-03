namespace Modul2Homework2
{
    public static class PurchaseProcessor
    {
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
    }
}
