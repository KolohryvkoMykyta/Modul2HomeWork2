namespace Modul2Homework2
{
    public class Order
    {
        public Product[]? Products { get; init; }

        public int Number { get; private set; } = new Random().Next(1000000);
    }
}
