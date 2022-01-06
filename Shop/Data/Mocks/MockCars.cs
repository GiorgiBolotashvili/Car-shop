using Shop.Data.InterFaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car { 
                        name = "Tesla Model S", 
                        shortDesc = "Fast car", 
                        longDesc = "Beautiful, fast and very quiet car from Tesla", 
                        img = "/img/tesla-model-s.jpg", 
                        price = 45000, 
                        isFavourite = true, 
                        available = true, 
                        Category = _categoryCars.AllCategories.First() 
                    },
                    new Car {
                        name = "Ford fiesta",
                        shortDesc = "Quiet and calm",
                        longDesc = "Comfortable car for city life",
                        img = "/img/ford-fiesta-mk7-st180.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "BMW M3",
                        shortDesc = "Cool and stylish",
                        longDesc = "Comfortable car for city life",
                        img = "/img/BMW.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "Mercedes C class",
                        shortDesc = "Cozy and large",
                        longDesc = "Comfortable car for city life",
                        img = "/img/Mercedes.png",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "Nissan leaf",
                        shortDesc = "Silent and economical",
                        longDesc = "Comfortable car for city life",
                        img = "/img/Nissan.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    }

                };

            }
        }
        public IEnumerable<Car> GetFavCars { get; }

        public Car GetObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
