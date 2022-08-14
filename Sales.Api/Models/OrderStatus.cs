using System;
using System.Collections.Generic;

namespace Sales.Api.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
