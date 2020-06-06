using IdentityManaging.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IdentityManaging.Infrastructure.Repositories.ConnectionFactories
{
    public class DbConnectionFactory : IdbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetDefaultServerConnectionString() => Create("DefaultServer");
        public IDbConnection GetDefaultServerConnectionStringAsync() => CreateAcync("DefaultServer");


        private IDbConnection Create(string connectionStringKey)
        {
            SqlConnection sqlConnection = GetSqlConnection(connectionStringKey);
            sqlConnection.Open();

            return sqlConnection;
        }

        private IDbConnection CreateAcync(string connectionStringKey)
        {
            SqlConnection sqlConnection = GetSqlConnection(connectionStringKey);
            sqlConnection.OpenAsync();

            return sqlConnection;
        }

        private SqlConnection GetSqlConnection(string connectionStringKey)
        {
            string connectionString = string.IsNullOrWhiteSpace(connectionStringKey) ? throw new IdentityManagingInfrastructureException() : _configuration.GetConnectionString(connectionStringKey);
            if (string.IsNullOrWhiteSpace(connectionString)) throw new IdentityManagingInfrastructureException($"There is any connection string named {connectionStringKey}.");

            return new SqlConnection(connectionString);
        }

    }
}
