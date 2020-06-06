using IdentityManaging.Infrastructure.Repositories.ConnectionFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Infrastructure.Repositories
{
    public class RepositoryContext
    {
        protected readonly IdbConnectionFactory _dbConnectionFactory;

        public RepositoryContext(IdbConnectionFactory dbConnectionFactory) => _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));

    }
}
