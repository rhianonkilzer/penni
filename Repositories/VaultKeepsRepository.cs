

using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        IDbConnection _db;
        public string TableName = "vaultkeeps";

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<VaultKeep> GetAll()
        {
            return _db.Query<VaultKeep>($"SELECT * FROM {TableName}");
        }
        public VaultKeep Update(VaultKeep vaultkeep)
        {
            _db.Execute(@"
            UPDATE vaultkeeps SET (vaultId, userId, keepId) 
            VALUES (@VaultId, @UserId, @KeepId)
            WHERE id = @Id", vaultkeep
            );
            return vaultkeep;
        }
    }
}