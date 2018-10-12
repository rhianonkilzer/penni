
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
        IDbConnection _db;
        public string TableName = "keeps";
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }


        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>($"SELECT * FROM {TableName}");
        }
        // GET BY ID 
        public Keep GetById(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id", new { id }).FirstOrDefault();
        }
        // CREATE  
        public Keep Create(Keep keep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO keeps (name, description, userId, img, isPrivate, views, shares, keeps)
            VALUES (@Name, @Description, @UserId, @Img, @Views, @Shares, @Keeps, @IsPrivate);
            SELECT LAST_INSERT_ID();", keep
            );

            keep.Id = id;
            return keep;
        }

        // UPDATE 
        public Keep Update(Keep keep)
        {
            _db.Execute(@"
            UPDATE keeps SET (name, description, userid, img, isPrivate, views, shares, keeps) 
            VALUES (@Name, @Description, @UserId, @Img, @Views, @Shares, @Keeps, @IsPrivate)
            WHERE id = @Id", keep
            );
            return keep;
        }


        public IEnumerable<Keep> GetByUserId(string id)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM keeps
            WHERE userId = @id;
            ", new { id });
        }


        public bool Delete(int keepId)
        {
            return _db.Execute("DELETE FROM keeps WHERE id = @keepId", new { keepId }) == 1;
        }
    }
}