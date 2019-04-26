using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMake.Models;

namespace WebAPIMake.Controllers
{
    public class OrderItemController : ApiController
    {
       abhinav_testEntities2 db = new abhinav_testEntities2();

        [HttpGet]
        public IEnumerable<OrderItem> GetOrderItems()
        {
           return  db.OrderItems.ToList();
        }

        [HttpGet]
        public OrderItem GetOrderItem(int id)
        {
            var getOrderIt = db.OrderItems.SingleOrDefault(x => x.Id == id);

            if(getOrderIt == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return getOrderIt;
        }

        [HttpPost]
        public OrderItem CreateOrderItem(OrderItem orderit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                db.OrderItems.Add(orderit);
                db.SaveChanges();

                return orderit;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public void UpOrderItem(int id, OrderItem orderitem)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var Orderss = db.OrderItems.SingleOrDefault(x => x.Id == id);
            if(Orderss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            orderitem.OrderId = Orderss.OrderId;
            orderitem.ItemId = Orderss.ItemId;
            orderitem.ItemQuantity = Orderss.ItemQuantity;
            orderitem.ItemPrice = Orderss.ItemPrice;
            orderitem.ItemTotal = Orderss.ItemTotal;

            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteOrderItem(int id)
        {
            var orderitem = db.OrderItems.SingleOrDefault(x => x.Id == id);
            if(orderitem == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.OrderItems.Remove(orderitem);
            db.SaveChanges();


        }
    }
}
