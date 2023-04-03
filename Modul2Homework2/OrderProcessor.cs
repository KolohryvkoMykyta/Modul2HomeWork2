namespace Modul2Homework2
{
    public static class OrderProcessor
    {
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
