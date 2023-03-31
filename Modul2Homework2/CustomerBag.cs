namespace Modul2Homework2
{
    public class CustomerBag
    {
        private int _numberPurchases = 0;

        private Node _bag;
        public decimal TotalPrice { get; private set; } = 0;

        public void AddProduct(Product product)
        {
            if (_numberPurchases < 10)
            {
                if (_bag != null)
                {
                    var temp = _bag;
                    _bag = new Node() { Product = product, Next = temp };
                }
                else
                {
                    _bag = new Node() { Product = product };
                }

                TotalPrice += product.Price;
                _numberPurchases++;
            }
            else
            {
                Console.WriteLine("Maximum items added to bag!");
            }
        }
    }
}
