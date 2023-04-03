namespace Modul2Homework2
{
    public class Customer
    {
        public string? Name { get; init; }

        public CustomerBag Bag { get; private set; } = new CustomerBag();

        public decimal Money { get; init; }
    }
}
