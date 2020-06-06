using IdentityManaging.Infrastructure.Repositories.ConnectionFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Infrastructure.Repositories.Dapper
{
    public class DapperRepositoryContext : RepositoryContext
    {
        public DapperRepositoryContext(IdbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
    }
}
