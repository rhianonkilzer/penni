using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        IDbConnection _db;
        public string TableName = "vaults";
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }


        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>($"SELECT * FROM {TableName}");
        }
        // GET BY ID 
        public Vault GetById(int id)
        {
            return _db.Query<Vault>("SELECT *FROM vaults WHERE id = @id", new { id }).FirstOrDefault();
        }
        // CREATE  
        public Vault Create(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaults (name, description, userid)
            VALUES (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();", vault
            );

            vault.Id = id;
            return vault;
        }
        // UPDATE 
        public Vault Update(Vault vault)
        {
            _db.Execute(@"
            UPDATE vaults SET (name, description, userid) 
            VALUES (@Name, @Description, @UserId)
            WHERE id = @Id", vault
            );
            return vault;
        }
        //  DELETE
        public Vault Delete(Vault vault)
        {
            _db.Execute("DELETE FROM vaults WHERE id = @Id", vault);
            return vault;
        }
        public IEnumerable<Vault> GetByUserId(string id)
        {
            return _db.Query<Vault>(@"
            SELECT * FROM vaults
            WHERE userId = @id;
            ", new { id });
        }

    }
}