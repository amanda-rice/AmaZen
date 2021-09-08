using System;
using System.Collections.Generic;
using amaZen.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }
    internal List<Product> Get()
    {
      List<Product> products = _repo.GetAll();
      return products;
    }
    internal Product Get(int id)
    {
      Product product = _repo.GetById(id);
      if (product == null)
      {
        throw new Exception("Invalid Id");
      }
      return product;
    }

    internal Product Create(Product newProduct)
    {
      return _repo.Create(newProduct);
    }

    internal Product Update(Product editedProduct)
    {
      Product original = Get(editedProduct.Id);
      original.Name = editedProduct.Name.Length > 0 ? editedProduct.Name : original.Name;
      return _repo.Update(original);
    }

    internal Product Delete(int productId)
    {
      Product productToDelete = Get(productId);
      _repo.Delete(productId);
      return productToDelete;
    }
  }
}