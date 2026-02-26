using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IProducrRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsByName( string name );
        Task<IEnumerable<Product>> GetAllProductsByBrand( string name );
        Task<Product> GetProductById( string id);
        Task<bool> DeleteProduct( string id);
        Task<bool> UpdateProduct( Product product);
        Task<Product> CreateProduct( Product product);
    }
}
