using IdentityManaging.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate
{
    public class UserProfileInfo : Entity
    {
        public string Username { get; private set; }
        public bool IsActive { get; private set; }
        public string Description { get; private set; }
        public UserType UserType { get; private set; }
        public int UserId { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}
