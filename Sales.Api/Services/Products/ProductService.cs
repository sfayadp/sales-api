using AutoMapper;
using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Models;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IMapper _mapper;

        #region Builder
        public ProductService(
            IProductDomainService productDomainService,
            IMapper mapper)
        {
            _productDomainService = productDomainService;
            _mapper = mapper;
        }
        #endregion Builder

        #region Methods

        public ProductDTO GetProduct(int Id)
        {
            try
            {
                Product product = _productDomainService.GetProduct(Id);
                if (product == null)
                    return new ProductDTO();

                ProductDTO result = _mapper.Map<Product, ProductDTO>(product);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            try
            {
                IEnumerable<Product> productList = _productDomainService.GetProducts();
                
                IEnumerable<ProductDTO> result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productList);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string SaveProduct(ProductDTO product)
        {
            string result = _productDomainService.SaveProduct(product);
            return result;
        }

        public string UpdateProduct(ProductDTO product)
        {
            string result = _productDomainService.UpdateProduct(product);
            return result;
        }

        #endregion Methods
    }
}
