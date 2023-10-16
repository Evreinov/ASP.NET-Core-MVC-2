namespace LanguageFeatures.Models
{
    // Использование автоматически реализуемых свойств: инициализаторы =, ствойства только для чтения { get; }.
    public class Product
    {

        public Product(bool stock = true)
        {
            InStock = stock;
        }

        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; } = true;
        public bool NameBeginsWithS => Name?[0] == 'S';

        public static Product[] GetProducts()
        {
            var kayak = new Product()
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M,
            };

            var lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Price = 48.95M,
            };

            kayak.Related = lifejacket;

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
