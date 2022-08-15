using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.DTOs;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        /// <summary>
        /// Lista a todos los estados de orden
        /// </summary>
        /// <returns>Lista de estados de orden</returns>
        [HttpGet]
        [Route(nameof(OrderStatusController.GetOrderStatuses))]
        public IEnumerable<OrderStatusDTO> GetOrderStatuses()
        {
            return _orderStatusService.GetOrderStatuses();
        }

        /// <summary>
        /// Lista un estado de orden
        /// </summary>
        /// <returns>Lista un estado de orden</returns>
        [HttpGet]
        [Route(nameof(OrderStatusController.GetOrderStatusByID))]
        public OrderStatusDTO GetOrderStatusByID(int Id)
        {
            return _orderStatusService.GetOrderStatus(Id);
        }

        /// <summary>
        /// Guardar un estado de orden
        /// </summary>
        /// <returns>Guarda un estado de orden</returns>
        [HttpPost]
        [Route(nameof(OrderStatusController.SaveOrderStatus))]
        public string SaveOrderStatus(OrderStatusDTO orderStatus)
        {
            return _orderStatusService.SaveOrderStatus(orderStatus);
        }

        /// <summary>
        /// Editar un estado de orden
        /// </summary>
        /// <returns>Edita un estado de orden</returns>
        [HttpPost]
        [Route(nameof(OrderStatusController.UpdateOrderStatus))]
        public string UpdateOrderStatus(OrderStatusDTO orderStatus)
        {
            return _orderStatusService.UpdateOrderStatus(orderStatus);
        }
    }
}
