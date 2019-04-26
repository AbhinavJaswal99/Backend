using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMake.Models;

namespace WebAPIMake.Controllers
{
    public class ItemController : ApiController
    {
        abhinav_testEntities2 db = new abhinav_testEntities2();

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return db.Items.ToList();
        }

        [HttpGet]
        public Item GetItem(int id)
        {
            var items = db.Items.SingleOrDefault(x => x.Id == id);

            if(items == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return items;
        }

        [HttpPost]
        public Item CreateItem(Item item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                db.Items.Add(item);
                db.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public void UpdateItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var itemss = db.Items.SingleOrDefault(x => x.Id == id);

            if(itemss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            itemss.ItemName = item.ItemName;
            itemss.ItemQuantity = item.ItemQuantity;
            itemss.ItemPrice = item.ItemPrice;
            itemss.ItemDescription = item.ItemDescription;
           
            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteItem(int id)
        {
            var itemss = db.Items.SingleOrDefault(x => x.Id == id);

            if(itemss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Items.Remove(itemss);
            db.SaveChanges();
        }

    }
}
