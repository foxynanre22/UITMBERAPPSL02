using System;
using System.Collections.Generic;
using System.Text;

namespace UITMBER.Models.Authentication
{
    public class AuthenticationReponse
    {
        public string AccessToken { get; set; }
        public int ExpireInSeconds { get; set; }
        public string Roles { get; set; }

        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
