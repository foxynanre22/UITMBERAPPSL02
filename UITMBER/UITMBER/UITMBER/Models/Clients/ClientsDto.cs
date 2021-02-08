using System;
using System.Collections.Generic;
using System.Text;

namespace UITMBER.Models.Clients
{
    class ClientsDto
    {
        public long UserId { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDriver { get; set; }
    }
}
