using Microsoft.AspNetCore.Mvc;
using Shop.Data.InterFaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Controllers
{
    public class ShopCartController :Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRep = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index() //------------------------------------------------------ !
        {
            _shopCart.ListShopItems = _shopCart.GetListShopCartItem();
            var obj = new ShopCartViewModel { ShopCart = _shopCart };
            
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(c => c.id == id);
            if (item != null)
            {
                _shopCart.AddCarToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
