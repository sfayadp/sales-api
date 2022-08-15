using Microsoft.EntityFrameworkCore;
using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Products
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly StoreDBContext _context;
        public ProductDomainService(StoreDBContext context)
        {
            _context = context;
        }

        public Product GetProduct(int Id)
        {
            return _context.Products.Where(x => x.Id == Id).First();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public string SaveProduct(ProductDTO product)
        {
            Product newProduct = new Product();
            string result = "";
            if (product != null)
            {
                newProduct.Name = product.NameDTO;
                newProduct.UnitPrice = product.UnitPriceDTO;
            }
            _context.Products.Add(newProduct);

            if (newProduct != null)
            {
                result = "ok";
                _context.SaveChanges();
            }
            else
            {
                result = "No se pudo guardar el registro";
            }

            return result;
        }

        public string UpdateProduct(ProductDTO product)
        {
            Product updateProduct = _context.Products.Where(x => x.Id == product.IdDTO).First();
            string result = "";
            if (updateProduct != null)
            {
                updateProduct.Name = product.NameDTO;
                updateProduct.UnitPrice = product.UnitPriceDTO;
            }

            _context.Entry(updateProduct).State = EntityState.Modified;

            if (updateProduct != null)
            {
                result = "Ok";
                _context.SaveChanges();
            }
            else
            {
                result = "No se pudo editar el registro";
            }
            return result;
        }
    }
}
