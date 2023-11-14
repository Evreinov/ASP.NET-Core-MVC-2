using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Организация
            var p = new Product { Name = "Test", Price = 100M };

            // Действие
            p.Name = "New Name";

            // Утверждение
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Организация
            var p = new Product { Name = "Test", Price = 100M };

            // Действие
            p.Price = 200M;

            // Утверждение
            Assert.Equal(200M, p.Price);
        }
    }
}
