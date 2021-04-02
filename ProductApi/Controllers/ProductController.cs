using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApi.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        static List<Product> _ProductList = null;
        void Initialize()
        {
            _ProductList = new List<Product>()
           {
               new Product() {ProductId=1,Name="Tea",QtyInStock=5,Description="High in Quality",Supplier="Parth"},
               new Product() {ProductId=2,Name="Sugar",QtyInStock=4,Description="High in Quality",Supplier="Parth"},
               new Product() {ProductId=3,Name="Milk",QtyInStock=7,Description="High in Quality",Supplier="Parth"}
           };

        }
        public ProductController()
        {
            if (_ProductList == null)
            {
                Initialize();
            }
        }

        // GET: api/Students
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ProductList);
        }

        // GET: api/Students/5
 
        public HttpResponseMessage Get(int id)
        {
            Product product = _ProductList.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
        }


        // POST: api/Students
        public HttpResponseMessage Post(Product product)
        {
            if (product != null)
            {
                _ProductList.Add(product);

                return Request.CreateResponse(HttpStatusCode.Created, "Record Inserted Successfully");
            }
            else
            {
                return (Request.CreateResponse(HttpStatusCode.BadRequest,"Product is empty"));
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            Product product = _ProductList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (product != null)
                {
                    _ProductList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Record Deleted Successfully");
            }

        }
           public HttpResponseMessage Put(int id, Product ProObj)
        {
            Product product = _ProductList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not Found");
            } else {
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
                return Request.CreateResponse(HttpStatusCode.OK, "Details Modified");
            }
        }


    }
}