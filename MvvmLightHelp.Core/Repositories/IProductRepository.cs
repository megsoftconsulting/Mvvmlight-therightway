using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmLightHelp.Core
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }

    public class MockProductRepository : IProductRepository
    {

        readonly List<Product> _items = new List<Product>
        {
                new Product{Id = "abcd1", Name="Coffee", Category="Important", Price=1.0M},
                new Product{Id = "abcd1", Name="Coffee+", Category="Important", Price=2.1M},
                new Product{Id = "abcd1", Name="Coffee+++", Category="Important", Price=4.0M},
                new Product{Id = "abcd1", Name="Guest what more coffee", Category="Important", Price=6.0M},
                new Product{Id = "abcd1", Name="Alright no more coffee", Category="Important", Price=1.5M},
        };

        public async Task<List<Product>> GetProductsAsync()
        {
            // Mock the API call
            await Task.Delay(1500);
            return await Task.FromResult<List<Product>>(_items);
        }
    }
}

