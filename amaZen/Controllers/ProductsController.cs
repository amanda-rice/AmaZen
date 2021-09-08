using System;
using System.Collections.Generic;
using amaZen.Models;
using contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _bs;

    public ProductsController(ProductsService service)
    {
      _bs = service;
    }

    [HttpGet]
    public ActionResult<List<Product>> Get()
    {
      try
      {
        List<Product> products = _bs.Get();
        return Ok(products);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      try
      {
        Product product = _bs.Get(id);
        return Ok(product);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product newProduct)
    {
      try
      {
        Product created = _bs.Create(newProduct);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        Product product = _bs.Delete(id);
        return Ok(product);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }




  }
}