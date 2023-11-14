using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product product)
            {
                // Ничего не делать - для теста не требуется
            }
        }

        // Параметризация модульного теста
        //[Theory]
        //[InlineData(275, 48.95, 19.50, 24.95)]
        //[InlineData(5, 48.95, 19.50, 24.95)]
        //public void IndexActionModelsComplete(decimal price1, decimal price2, decimal price3, decimal price4)
        //{
        //    // Организация
        //    var controller = new HomeController();
        //    controller.Repository = new ModelCompleteFakeRepository
        //    {
        //        Products = new Product[]
        //        {
        //            new Product { Name = "P1", Price = price1 },
        //            new Product { Name = "P2", Price = price2 },
        //            new Product { Name = "P3", Price = price3 },
        //            new Product { Name = "P4", Price = price4 },
        //        }
        //    };

        //    // Действие
        //    var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        //    // Утверждение
        //    Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        //}

        // Получение тестовых данных из метода или свойства
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelsComplete(Product[] products)
        {
            // Организация c использование фиктивного класса
            //var controller = new HomeController();
            //controller.Repository = new ModelCompleteFakeRepository
            //{
            //    Products = products,
            //};

            // Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Утверждение
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;

            public IEnumerable<Product> Products
            {
                get
                {
                    PropertyCounter++;
                    return new[] {new Product {Name = "P1", Price = 100}};
                }
            }

            public void AddProduct(Product product)
            {
                // Ничего не делать - для теста не требуется
            }
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Организация c использование фиктивного класса
            //var repo = new PropertyOnceFakeRepository();
            //var controller = new HomeController {Repository = repo};

            // Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] {new Product {Name = "P1", Price = 100}});
            var controller = new HomeController {Repository = mock.Object};

            // Действие
            var result = controller.Index();

            // Утверждение c использование фиктивного класса
            //Assert.Equal(1, repo.PropertyCounter);
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
