using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        // Пример null-условной операции ?. и операции объединения с null ??
        // Пример интерполяции стррок.
        //List<string> results = new List<string>();
        //foreach (Product product in Product.GetProducts())
        //{
        //    string name = product?.Name ?? "<No Name>";
        //    decimal? price = product?.Price ?? 0;
        //    string relateName = product?.Related?.Name ?? "<None>";
        //    results.Add($"Name: {name}, Price: {price:C2}, Related: {relateName}");
        //}
        //return View(results);

        // Использование инициализатора индексной коллекции.
        //Dictionary<string, Product> products = new Dictionary<string, Product> {
        //    ["Kayak"] = new Product { Name = "Kayak", Price = 275M  },
        //    ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M},
        //};
        //return View("Index", products.Keys);

        // Сопоставление с образцом
        //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
        //decimal total = 0;
        //for (int i = 0; i < data.Length; i++)
        //{
        //    //if (data[i] is decimal d)
        //    //{
        //    //    total += d;
        //    //}
        //    switch (data[i])
        //    {
        //        case decimal decimalValue:
        //            total += decimalValue;
        //            break;
        //        case int intValue when intValue > 50:
        //            total += intValue;
        //            break;
        //    }
        //}
        //return View("Index", new string[] { $"Total: {total:C2}" });

        // Использование расширяющих методов и фильтрующих расширяющих методов
        //ShoppingCart cart = new ShoppingCart {Products = Product.GetProducts()};

        //Product[] productArray =
        //{
        //    new Product { Name = "Kayak", Price = 275M },
        //    new Product { Name = "Lifejacket", Price = 48.95M },
        //    new Product { Name = "Soccer ball", Price = 19.50M },
        //    new Product { Name = "Corner flag", Price = 34.95M },
        //};

        //decimal cartTotal = cart.TotalPrices();
        //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
        //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

        //return View("Index", new string[]
        //{
        //    $"Cart Total: {cartTotal:C2}", 
        //    $"Array Price Total: {arrayTotal:C2}",
        //    $"Array Name Total: {nameFilterTotal:C2}",
        //});

        // Пример использования универсального фильтрующего метода
        //bool FilterByPrice(Product p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}

        //Product[] productArray =
        //{
        //    new Product { Name = "Kayak", Price = 275M },
        //    new Product { Name = "Lifejacket", Price = 48.95M },
        //    new Product { Name = "Soccer ball", Price = 19.50M },
        //    new Product { Name = "Corner flag", Price = 34.95M },
        //};

        //Func<Product, bool> nameFilter = delegate(Product prod)
        //{
        //    return prod?.Name?[0] == 'S';
        //};

        //decimal priceFilterTotal = productArray
        //    .Filter(FilterByPrice)
        //    .TotalPrices();

        //decimal nameFilterTotal = productArray
        //    .Filter(nameFilter)
        //    .TotalPrices();

        //return View("Index", new string[]
        //{
        //    $"Price Total: {priceFilterTotal:C2}",
        //    $"Name Total: {nameFilterTotal:C2}",
        //});

        // Пример использования универсального фильтрующего метода c использованием лямбда-выражений
        //Product[] productArray =
        //{
        //    new Product { Name = "Kayak", Price = 275M },
        //    new Product { Name = "Lifejacket", Price = 48.95M },
        //    new Product { Name = "Soccer ball", Price = 19.50M },
        //    new Product { Name = "Corner flag", Price = 34.95M },
        //};

        //decimal priceFilterTotal = productArray
        //    .Filter(p => (p?.Price ?? 0) >= 20)
        //    .TotalPrices();

        //decimal nameFilterTotal = productArray
        //    .Filter(p => p?.Name?[0] == 'S')
        //    .TotalPrices();

        //return View("Index", new string[]
        //{
        //    $"Price Total: {priceFilterTotal:C2}",
        //    $"Name Total: {nameFilterTotal:C2}",
        //});

        // Использование методов и свойст в форме лямбда-выражений
        //return View(Product.GetProducts().Select(p => p?.Name));
        //}

        // Метод действия представленный как лямбда-выражение
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));

        //public ViewResult Index()
        //{
        //    // Использование выведение типа или неявной типизацией
        //    //var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };
        //    //return View(names);

        //    // Создание анонимного типа
        //    var products = new[]
        //    {
        //        new { Name = "Kayak", Price = 275M },
        //        new { Name = "Lifejacket", Price = 48.95M },
        //        new { Name = "Soccer ball", Price = 19.50M },
        //        new { Name = "Corner flag", Price = 24.95M },
        //    };
        //    return View(products.Select(p => p.GetType().Name));
        //}

        //public async Task<ViewResult> Index()
        //{
        //    long? lenght = await MyAsyncMethods.GetPageLenght();
        //    return View(new string[] { $"Length: {lenght}" });
        //}

        public ViewResult Index()
        {
            var products = new[]
            {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 24.95M },
            };
            // Использование жестко закодированного имени в файле
            //return View(products.Select(p => $"Name: {p.Name}, Price: {p.Price}"));

            // Использование выражений nameof в файле
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}
