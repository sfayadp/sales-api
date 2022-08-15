using Sales.Api.DTOs;

namespace Sales.Api.Services.Contratcs
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(int id);
        string SaveProduct(ProductDTO product);
        string UpdateProduct(ProductDTO product);
    }
}
