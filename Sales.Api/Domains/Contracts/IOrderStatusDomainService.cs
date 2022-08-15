using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Contracts
{
    public interface IOrderStatusDomainService
    {
        IEnumerable<OrderStatus> GetOrderStatuses();
        OrderStatus GetOrderStatus(int Id);
        string SaveOrderStatus(OrderStatusDTO orderStatus);
        string UpdateOrderStatus(OrderStatusDTO orderStatus);
    }
}
