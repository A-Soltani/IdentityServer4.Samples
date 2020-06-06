using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate.UserPersonalInformation
{
    public class UserContactInfo
    {
        public string MobilePhone { get; private set; }
        public string HomeAddress { get; private set; }
        public string HomeTel { get; private set; }
        public string MailAddress { get; private set; }
    }
}
