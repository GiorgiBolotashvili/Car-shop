using Microsoft.AspNetCore.Mvc;
using Shop.Data.InterFaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetListShopCartItem();

            if (shopCart.ListShopItems.Count ==0)
            {
                ModelState.AddModelError("", "You must have the products!");
            }
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            shopCart.ListShopItems.Clear();
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Order processed successfully";
            return View();
        }
    }
}
