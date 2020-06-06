using IdentityManaging.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate.UserPersonalInformation
{
    public class UserPersonalInfo : Entity
    {
        public UserContactInfo UserContactInfo { get; private set; }
        public UserPersonalIdentityInfo UserPersonalIdentityInfo { get; private set; }

    }
}
