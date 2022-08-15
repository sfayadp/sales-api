using Sales.Api.DTOs;

namespace Sales.Api.Services.Contratcs
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatusDTO> GetOrderStatuses();
        OrderStatusDTO GetOrderStatus(int id);
        string SaveOrderStatus(OrderStatusDTO orderStatus);
        string UpdateOrderStatus(OrderStatusDTO orderStatus);
    }
}
