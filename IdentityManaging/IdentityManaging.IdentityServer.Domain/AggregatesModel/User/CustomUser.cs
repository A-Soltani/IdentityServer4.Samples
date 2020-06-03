using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.IdentityServer.Domain.AggregatesModel.User
{
    public class CustomUser
    {
        public string SubjectId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
