using System;
using System.Collections.Generic;
using System.Text;
using UITMBER.Enums;

namespace UITMBER.Models.Orders
{
   public class OrderAcceptResponse
    {
        public bool Success { get; set; }
        public OrderStatus Status { get; set; }
        public string Error { get; set; }
    }
}
