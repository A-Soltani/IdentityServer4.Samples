using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate.UserPersonalInformation
{
    public class UserPersonalIdentityInfo
    {
        public string FullNameOfOwner { get; private set; }
        public string CodeMelli { get; private set; }
        public string BDate { get; private set; }
        public string FatherName { get; private set; }
    }
}
