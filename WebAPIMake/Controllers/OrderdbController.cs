using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMake.Models;

namespace WebAPIMake.Controllers
{
    public class OrderdbController : ApiController
    {
        abhinav_testEntities2 db = new abhinav_testEntities2();
        
        [HttpGet]
        public IEnumerable<Orderdb> GetOrderdbs()
        {
            return  db.Orderdbs.ToList();
           //var hello = db.Orderdbs.Include("tblCustomer").ToList();
           // return hello;
        }

        [HttpGet]
        public Orderdb GetOrderdb(int id)
        {
            var getord = db.Orderdbs.SingleOrDefault(x => x.Id == id);

            if(getord == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return getord;
        }

        [HttpPost]
        public Orderdb CreateOrderdb(Orderdb orderdb)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                db.Orderdbs.Add(orderdb);
                db.SaveChanges();

                return orderdb;
            }
        
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public void UpdateOrderdb(int id, Orderdb orderdb)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var orderss = db.Orderdbs.SingleOrDefault(x => x.Id == id);

            if(orderss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            orderdb.OrderNo = orderss.OrderNo;
            orderdb.TotalPrice = orderss.TotalPrice;
            orderdb.TotalQuantity = orderss.TotalQuantity;
            orderdb.OrderDate = orderss.OrderDate;

            db.SaveChanges();
        }

        public void DeleteOrderdb(int id)
        {
            var orderss = db.Orderdbs.SingleOrDefault(x => x.Id == id);

            if(orderss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Orderdbs.Remove(orderss);
            db.SaveChanges();
        }


    }
}
