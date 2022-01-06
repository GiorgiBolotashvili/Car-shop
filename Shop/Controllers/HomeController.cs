using Microsoft.AspNetCore.Mvc;
using Shop.Data.InterFaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;


        public HomeController(IAllCars carRepository)
        {
            _carRep = carRepository;
        }
        public ViewResult Index()
        {
            var homecCars = new HomeViewModel { favCars = _carRep.GetFavCars };

            return View(homecCars);
        }

    }
}
