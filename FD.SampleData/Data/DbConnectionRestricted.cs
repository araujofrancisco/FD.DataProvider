using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace FD.SampleData.Data
{
    /// <summary>
    /// A subset of DbConnection class to allow access to certain methods of the database connection exposing only
    /// the ones that are safe without compromise changing database or closing the connection.
    /// </summary>
    public class DbConnectionRestricted
    {
        private DbConnection _connection;
        private Guid _uidRestricted;

        public DbConnectionRestricted(DbConnection connection, out Guid uidRestricted)
        {
            _connection = connection;
            // this unique id will be used to only allow call dispose to the object that created the instance
            // to avoid issue by it killing the dbfactory connection
            _uidRestricted = new Guid();
            uidRestricted = _uidRestricted;
        }

        #region " DbConnection Methods Allowed "
        public DbCommand CreateCommand() =>
            _connection.CreateCommand();

        public DbTransaction BeginTransaction() =>
            _connection.BeginTransaction();

        public ValueTask<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
            _connection.BeginTransactionAsync(cancellationToken);

        public ValueTask<DbTransaction> BeginTransactionAsync(System.Data.IsolationLevel isolationLevel, CancellationToken cancellationToken = default) =>
            _connection.BeginTransactionAsync(isolationLevel, cancellationToken);

        public void EnlistTransaction(Transaction? transaction) =>
            _connection.EnlistTransaction(transaction);

        public DataTable GetSchema() =>
            _connection.GetSchema();

        public DataTable GetSchema(string collectionName) =>
            _connection.GetSchema(collectionName);

        public DataTable GetSchema(string collectionName, string[]? restrictionValues) =>
            _connection.GetSchema(collectionName, restrictionValues);

        public Task<DataTable> GetSchemaAsync(CancellationToken cancellationToken = default) =>
            _connection.GetSchemaAsync(cancellationToken);

        public Task<DataTable> GetSchemaAsync(string collectionName, CancellationToken cancellationToken = default) =>
            _connection.GetSchemaAsync(collectionName, cancellationToken);

        public Task<DataTable> GetSchemaAsync(string collectionName, string[]? restrictionValues, CancellationToken cancellationToken = default) =>
            _connection.GetSchemaAsync(collectionName, restrictionValues, cancellationToken);
        #endregion

        /// <summary>
        /// Only allows to release the connection to the object that created this instance.
        /// </summary>
        /// <param name="uidRestricted"></param>
        public void DisposeRestricted(Guid uidRestricted)
        {
            if (uidRestricted == _uidRestricted && _connection != null)
                _connection = null;
        }
    }
}
