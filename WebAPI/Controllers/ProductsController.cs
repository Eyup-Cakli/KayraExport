﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    
    IProductService _productService; 
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getall")]

    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult PostAdd(Product product)
    {
        var result = _productService.Add(product);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult PostUpdate(Product product)
    {
        var result = _productService.Update(product);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("delete")]
    public IActionResult PostDelete(Product product)
    {
        var result = _productService.Delete(product);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
