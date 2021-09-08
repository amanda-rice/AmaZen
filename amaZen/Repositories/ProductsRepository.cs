using System.Collections.Generic;
using System.Data;
using System.Linq;
using amaZen.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List<Product> GetAll()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql).ToList();
    }

    internal Product GetById(int id)
    {
      string sql = @"
      SELECT 
        *
      FROM products b
      WHERE b.id = @id;
      ";
      return _db.Query<Product>(sql, new { id }).FirstOrDefault();
    }

    internal Product Create(Product newProduct)
    {
      string sql = @"
        INSERT INTO products
        (name, creatorId)
        VALUES
        (@Name, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, newProduct);
      return GetById(id);
    }

    internal Product Update(Product original)
    {
      string sql = @"
        UPDATE products
        SET
            name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return GetById(original.Id);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}