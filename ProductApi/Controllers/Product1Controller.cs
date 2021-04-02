using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApi.Controllers
{
    public class Product1Controller : ApiController
    {
        static List<Product> _ProductList = null;
        void Initializer()
        {
            _ProductList = new List<Product>()
            {
                new Product(){ProductId=1,Name="Bag",QtyInStock=2,Description="Laptop Bag",Supplier="Rakesh"},
                 new Product(){ProductId=2,Name="Shirt",QtyInStock=5,Description="Full Sleeves",Supplier="Siddharth"}

            };
        }
        public Product1Controller()
        {
            if (_ProductList == null)
            {
                Initializer();
            }
        }

        public IHttpActionResult Get()
        {
            return Ok(_ProductList);
        }


        public IHttpActionResult Get(int? id)
        {
            Product product = _ProductList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        public IHttpActionResult Post(Product product)
        {
            if (product != null)
            {
                _ProductList.Add(product);
            }
            return Content(HttpStatusCode.Created, "Created Succesfully");

        }
        public IHttpActionResult Put(int id, Product ProObj)
        {
            Product product = _ProductList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                if (product != null)
                {
                    foreach (var temp in _ProductList)
                    {
                        if (temp.ProductId == id)
                        {
                            temp.Name = ProObj.Name;
                            temp.QtyInStock = ProObj.QtyInStock;
                            temp.Description = ProObj.Description;
                            temp.Supplier = ProObj.Supplier;
                        }
                    }
                }
                return Content(HttpStatusCode.OK, "Modified Succesfully");
            }
        }

        public IHttpActionResult Delete(int id)
        {

            Product product = _ProductList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)

            {
                return NotFound();

            }
            else
            {
                if (product != null)
                {
                    _ProductList.Remove(product);
                }
                return Content(HttpStatusCode.OK, "Deleted Succesfully");
            }

        }
    }
}
