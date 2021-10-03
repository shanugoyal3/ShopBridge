using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.Models;
using System.Net;
//using System.Web.Http;




namespace ShopBridge.Controllers
{
    [Route("api/[controller]/{id:int?}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext repoContext)
        {
            _context = repoContext;
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var product = _context.Products.ToList();

            return new JsonResult(product);
                
        }

        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();

                    return new JsonResult("Product Added Successfully");

                }
                else
                {
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
                    
                }
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPut]
        public JsonResult UpdateProduct (int id , Product product)
        {
            if (!ModelState.IsValid)
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);


            var productinDB = _context.Products.SingleOrDefault(c => c.Id == id);
            try
            {
                if (productinDB == null)
                {

                    return new JsonResult("Product Not Found in Records");
                }
                else
                {
                    productinDB.Name = product.Name;
                    productinDB.Description = product.Description;
                    productinDB.Price = product.Price;
                    productinDB.CategoryId = product.CategoryId;

                    _context.SaveChanges();

                    return new JsonResult("Product Updated Successfully");

                }
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var productinDb = _context.Products.SingleOrDefault(c => c.Id == id);
            try
            {
                if (productinDb == null)
                    return new JsonResult("Product Not Found in Records");
                else
                {
                    _context.Products.Remove(productinDb);
                    _context.SaveChanges();

                    return new JsonResult("Record Deleted Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }




    }
}
