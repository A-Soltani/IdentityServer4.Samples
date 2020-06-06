using IdentityManaging.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate
{
    public class UserPasswordInfo: Entity
    {
        public string Password { get; private set; }
        public string USSDPassword { get; private set; }
    }
}
