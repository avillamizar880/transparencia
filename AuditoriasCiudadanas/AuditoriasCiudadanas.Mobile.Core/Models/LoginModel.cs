using System;
using System.Collections.Generic;
using System.Text;

namespace AuditoriasCiudadanas.Mobile.Core.Models
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public int UserId { get; set; }
    }
}