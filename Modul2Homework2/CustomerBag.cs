namespace Modul2Homework2
{
    public class CustomerBag
    {
        public int PurchasesNumer { get; private set; } = 0;

        public Product[] Bag { get; private set; } = new Product[0];

        public decimal TotalPrice { get; private set; } = 0;

        public void AddProduct(Product product)
        {
            Product[] temp = new Product[Bag.Length + 1];

            for (int i = 0; i < Bag.Length; i++)
            {
                temp[i] = Bag[i];
            }

            temp[temp.Length - 1] = product;
            TotalPrice += product.Price;
            PurchasesNumer++;
            Bag = temp;
        }

        public void CleanBag()
        {
            Bag = new Product[0];
            PurchasesNumer = 0;
            TotalPrice = 0;
        }
    }
}
