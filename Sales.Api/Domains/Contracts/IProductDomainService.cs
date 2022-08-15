using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Contracts
{
    public interface IProductDomainService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int Id);
        string SaveProduct(ProductDTO product);
        string UpdateProduct(ProductDTO product);
    }
}
