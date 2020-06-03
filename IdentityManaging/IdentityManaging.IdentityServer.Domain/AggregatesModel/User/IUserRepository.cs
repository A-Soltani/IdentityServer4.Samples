using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.IdentityServer.Domain.AggregatesModel.User
{
    public interface IUserRepository
    {
        bool ValidateCredentials(string username, string password);

        CustomUser FindBySubjectId(string subjectId);

        CustomUser FindByUsername(string username);
    }
}
