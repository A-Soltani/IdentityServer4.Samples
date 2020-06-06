using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository
{
    public class UserRegistrationResultDto
    {
        public int Username { get; set; }
        public string ErrorMessage { get; set; }
    }
}
