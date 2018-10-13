

using System;
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
        public void Create(VaultKeep vaultkeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps (userId, keepId, vaultId)
            VALUES (@UserId, @KeepId, @VaultId);
            SELECT LAST_INSERT_ID();", vaultkeep
            );

            return;
        }
        public IEnumerable<Keep> GetAll(string vaultId)
        {
            return _db.Query<Keep>(@"SELECT *
            FROM
            vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId WHERE(vaultId = @vaultId)", new { vaultId });
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

        internal void Delete(VaultKeep vk)
        {
            _db.Execute(@"
            DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId;
            ", vk);
        }
    }
}