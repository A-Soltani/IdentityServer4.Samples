using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Infrastructure.Exceptions
{
    public class IdentityManagingInfrastructureException : Exception
    {
        public IdentityManagingInfrastructureException() { }

        public IdentityManagingInfrastructureException(string message)
            : base(message)
        { }

        public IdentityManagingInfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
