using System;
using System.Collections.Generic;
using System.Text;
using UITMBER.Enums;

namespace UITMBER.Models.Orders
{
    public class OrderPaymentResponse
    {
        public bool Success { get; set; }
        public bool IsPaid { get; set; }
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public PaymentType paymentType { get; set; }
        public string Error { get; set; }
    }
}
