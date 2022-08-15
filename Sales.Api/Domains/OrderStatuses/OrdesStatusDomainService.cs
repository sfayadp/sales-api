using Microsoft.EntityFrameworkCore;
using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.OrderStatuses
{
    public class OrderStatusDomainService : IOrderStatusDomainService
    {
        private readonly StoreDBContext _context;
        public OrderStatusDomainService(StoreDBContext context)
        {
            _context = context;
        }

        public OrderStatus GetOrderStatus(int Id)
        {
            return _context.OrderStatuses.Where(x => x.Id == Id).First();
        }

        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            return _context.OrderStatuses.ToList();
        }

        public string SaveOrderStatus(OrderStatusDTO orderStatus)
        {
            OrderStatus newOrderStatus = new OrderStatus();
            string result = "";
            if (orderStatus != null)
            {
                newOrderStatus.Name = orderStatus.NameDTO;                
            }
            _context.OrderStatuses.Add(newOrderStatus);

            if (newOrderStatus != null)
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

        public string UpdateOrderStatus(OrderStatusDTO orderStatus)
        {
            OrderStatus updateOrderStatus = _context.OrderStatuses.Where(x => x.Id == orderStatus.IdDTO).First();
            string result = "";
            if (updateOrderStatus != null)
            {
                updateOrderStatus.Name = orderStatus.NameDTO;                
            }

            _context.Entry(updateOrderStatus).State = EntityState.Modified;

            if (updateOrderStatus != null)
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
