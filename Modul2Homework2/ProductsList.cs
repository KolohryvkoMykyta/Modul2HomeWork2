namespace Modul2Homework2
{
    public static class ProductsList
    {
        public static Product[] Products { get; } = new Product[]
        {
            new Product() { Name = "Hankook", Size = "185/65", Radius = "R14", Price = 2789 },
            new Product() { Name = "Hankook", Size = "175/65", Radius = "R14", Price = 2071 },
            new Product() { Name = "Hankook", Size = "225/60", Radius = "R17", Price = 4972 },
            new Product() { Name = "Hankook", Size = "235/65", Radius = "R17", Price = 4575 },
            new Product() { Name = "Hankook", Size = "245/45", Radius = "R19", Price = 7659 },
            new Product() { Name = "Hankook", Size = "285/45", Radius = "R19", Price = 7040 },
            new Product() { Name = "Toyo", Size = "185/80", Radius = "R14", Price = 2349 },
            new Product() { Name = "Toyo", Size = "175/65", Radius = "R14", Price = 2106 },
            new Product() { Name = "Toyo", Size = "225/60", Radius = "R17", Price = 4926 },
            new Product() { Name = "Toyo", Size = "235/65", Radius = "R17", Price = 4890 },
            new Product() { Name = "Toyo", Size = "245/45", Radius = "R19", Price = 7179 },
            new Product() { Name = "Toyo", Size = "285/45", Radius = "R19", Price = 6897 },
            new Product() { Name = "Pirelli", Size = "185/65", Radius = "R14", Price = 3300 },
            new Product() { Name = "Pirelli", Size = "175/65", Radius = "R14", Price = 3814 },
            new Product() { Name = "Pirelli", Size = "225/60", Radius = "R17", Price = 5596 },
            new Product() { Name = "Pirelli", Size = "235/65", Radius = "R17", Price = 5582 },
            new Product() { Name = "Pirelli", Size = "245/45", Radius = "R19", Price = 7656 },
            new Product() { Name = "Pirelli", Size = "245/45", Radius = "R19", Price = 7344 },
        };

        public static Product[] DisplayProduct()
        {
            string wheelRadius;
            string companyManufacturer;
            Product[] selectedProducts;

            wheelRadius = ChooseRadius();
            companyManufacturer = ChooseCompanyManufacturer();
            selectedProducts = PrintProduct(wheelRadius, companyManufacturer);

            return selectedProducts;
        }

        private static string ChooseRadius()
        {
            char selectedRadius;
            bool isCorrectRadius = false;
            string wheelRadius = string.Empty;

            while (!isCorrectRadius)
            {
                Console.WriteLine("\nWhich size tires are you interested in?: (Input number from 1 to 4)\n");
                Console.WriteLine("1 R14\n2 R17\n3 R19\n4 Show all");
                selectedRadius = Console.ReadKey(true).KeyChar;

                switch (selectedRadius)
                {
                    case '1':
                        Console.WriteLine("\nSelected R14 radius\n");
                        wheelRadius = "R14";
                        isCorrectRadius = true;
                        break;
                    case '2':
                        Console.WriteLine("\nSelected R17 radius\n");
                        wheelRadius = "R17";
                        isCorrectRadius = true;
                        break;
                    case '3':
                        Console.WriteLine("\nSelected R19 radius\n");
                        wheelRadius = "R19";
                        isCorrectRadius = true;
                        break;
                    case '4':
                        Console.WriteLine("\nSelected all\n");
                        wheelRadius = "All";
                        isCorrectRadius = true;
                        break;
                    default:
                        Console.WriteLine("\nSelected radius does not exist");
                        Console.WriteLine("Please try again");
                        break;
                }
            }

            return wheelRadius;
        }

        private static string ChooseCompanyManufacturer()
        {
            char selectedCompanyManufacturer;
            bool isCorrectCompanyManufacturer = false;
            string companyManufacturer = string.Empty;

            while (!isCorrectCompanyManufacturer)
            {
                Console.WriteLine("Which tire manufacturer are you interested in?: (Input number from 1 to 4)\n");
                Console.WriteLine("1 Hankook\n2 Toyo\n3 Pirelli\n4 Show all");
                selectedCompanyManufacturer = Console.ReadKey(true).KeyChar;

                switch (selectedCompanyManufacturer)
                {
                    case '1':
                        Console.WriteLine("\nSelected Hankook tires\n");
                        companyManufacturer = "Hankook";
                        isCorrectCompanyManufacturer = true;
                        break;
                    case '2':
                        Console.WriteLine("\nSelected Toyo tires\n");
                        companyManufacturer = "Toyo";
                        isCorrectCompanyManufacturer = true;
                        break;
                    case '3':
                        Console.WriteLine("\nSelected Pirelli tires\n");
                        companyManufacturer = "Pirelli";
                        isCorrectCompanyManufacturer = true;
                        break;
                    case '4':
                        Console.WriteLine("\nSelected all\n");
                        companyManufacturer = "All";
                        isCorrectCompanyManufacturer = true;
                        break;
                    default:
                        Console.WriteLine("\nSelected manufacturer does not exist");
                        Console.WriteLine("Please try again");
                        break;
                }
            }

            return companyManufacturer;
        }

        private static Product[] PrintProduct(string wheelRadius, string companyManufacturer)
        {
            int counter = 0;

            Console.WriteLine("List of tires matching your criteria");
            Console.WriteLine($"Company Manufacturer: {companyManufacturer}\nWheel Radius: {wheelRadius}\n");

            foreach (var product in Products)
            {
                if (product.Radius == wheelRadius || wheelRadius == "All")
                {
                    if (product.Name == companyManufacturer || companyManufacturer == "All")
                    {
                        counter++;
                    }
                }
            }

            var selectedProducts = new Product[counter];
            counter = 0;

            foreach (var product in Products)
            {
                if (product.Radius == wheelRadius || wheelRadius == "All")
                {
                    if (product.Name == companyManufacturer || companyManufacturer == "All")
                    {
                        Console.WriteLine($"{counter + 1} {product.Name} {product.Size} {product.Radius} {product.Price} UAH");
                        selectedProducts[counter] = product;
                        counter++;
                    }
                }
            }

            return selectedProducts;
        }
    }
}
