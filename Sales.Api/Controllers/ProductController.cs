using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.DTOs;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Lista a todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        [Route(nameof(ProductController.GetProducts))]
        public IEnumerable<ProductDTO> GetProducts()
        {
            return _productService.GetProducts();
        }

        /// <summary>
        /// Lista a todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        [Route(nameof(ProductController.GetProductByID))]
        public ProductDTO GetProductByID(int Id)
        {
            return _productService.GetProduct(Id);
        }

        /// <summary>
        /// Lista un producto
        /// </summary>
        /// <returns>Lista un producto</returns>
        [HttpPost]
        [Route(nameof(ProductController.SaveProduct))]
        public string SaveProduct(ProductDTO product)
        {
            return _productService.SaveProduct(product);
        }

        /// <summary>
        /// Editar un producto
        /// </summary>
        /// <returns>Lista un producto</returns>
        [HttpPost]
        [Route(nameof(UpdateProduct))]
        public string UpdateProduct(ProductDTO product)
        {
            return _productService.UpdateProduct(product);
        }
    }
}
