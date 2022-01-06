using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        public string ShopCartID { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", shopCartId);

            return new ShopCart(context) { ShopCartID = shopCartId };
        }
        public void AddCarToCart(Car car)
        {
            ShopCartItem shopCartItem = new ShopCartItem { shopCartID = ShopCartID, car = car, price = car.price };
            appDBContent.ShopCartItems.Add(shopCartItem);
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetListShopCartItem()
        {
            return appDBContent.ShopCartItems.Where(s => s.shopCartID == ShopCartID).Include(c => c.car).ToList();
        }
    }
}
