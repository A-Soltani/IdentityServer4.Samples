﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [DataType( DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
    }
}
