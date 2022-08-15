using AutoMapper;
using Sales.Api.Domains.Contracts;
using Sales.Api.Domains.Employees;
using Sales.Api.DTOs;
using Sales.Api.Models;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Services.OrderStatuses
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusDomainService _orderStatusDomainService;
        private readonly IMapper _mapper;

        #region Builder

        public OrderStatusService(
            IOrderStatusDomainService orderStatusDomainService,
            IMapper mapper)
        {
            _orderStatusDomainService = orderStatusDomainService;
            _mapper = mapper;
        }

        #endregion Builder

        #region Methods

        public OrderStatusDTO GetOrderStatus(int Id)
        {
            try
            {
                OrderStatus orderStatus = _orderStatusDomainService.GetOrderStatus(Id);
                if (orderStatus == null)
                    return new OrderStatusDTO();

                OrderStatusDTO result = _mapper.Map<OrderStatus, OrderStatusDTO>(orderStatus);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<OrderStatusDTO> GetOrderStatuses()
        {
            try
            {
                IEnumerable<OrderStatus> orderStatusList = _orderStatusDomainService.GetOrderStatuses();

                IEnumerable<OrderStatusDTO> result = _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusDTO>>(orderStatusList);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string SaveOrderStatus(OrderStatusDTO orderStatus)
        {
            string result = _orderStatusDomainService.SaveOrderStatus(orderStatus);
            return result;
        }

        public string UpdateOrderStatus(OrderStatusDTO orderStatus)
        {
            string result = _orderStatusDomainService.UpdateOrderStatus(orderStatus); ;
            return result;
        }

        #endregion Methods
    }
}
