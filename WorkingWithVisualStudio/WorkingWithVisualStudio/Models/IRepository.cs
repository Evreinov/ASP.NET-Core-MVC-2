namespace WorkingWithVisualStudio.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
}
