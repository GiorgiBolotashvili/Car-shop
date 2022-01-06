using Microsoft.AspNetCore.Mvc;
using Shop.Data.InterFaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Comtrollers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allcars, ICarsCategory allCategories)
        {
            _allCars = allcars;
            _allCategories = allCategories;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category = "")
        {
            ViewBag.Title = "page with cars";
            CarsListViewModel obj = new CarsListViewModel();
            if (category.Equals("electro", StringComparison.OrdinalIgnoreCase))
            {
                obj.AllCars = _allCars.Cars.Where(c => c.Category.categoryName.Equals("electro car"));
                obj.currCategoty = "Electro Cars";
            }
            else if (category.Equals("fuel", StringComparison.OrdinalIgnoreCase))
            {
                obj.AllCars = _allCars.Cars.Where(c => c.Category.categoryName.Equals("classic car"));
                obj.currCategoty = "Classic Cars";
            }
            else
            {
                obj.AllCars = _allCars.Cars;
                obj.currCategoty = "All Cars";
            }
            
            
            return View(obj);
        }
    }
}
