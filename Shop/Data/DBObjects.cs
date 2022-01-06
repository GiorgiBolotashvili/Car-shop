using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Car.Any())
            {
                content.Car.AddRange(Cars.Select(c => c.Value));
            }

            content.SaveChanges();
        }
        private static Dictionary<String, Car> Car;
        private static Dictionary<String, Car> Cars
        {
            get
            {
                if (Car == null)
                {
                    var list = new Car[]
                    {
                        new Car {
                        name = "Tesla Model S",
                        shortDesc = "Fast car",
                        longDesc = "Beautiful, fast and very quiet car from Tesla",
                        img = "/img/tesla-model-s.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["electro car"]
                    },
                    new Car {
                        name = "Ford fiesta",
                        shortDesc = "Quiet and calm",
                        longDesc = "Comfortable car for city life",
                        img = "/img/ford-fiesta-mk7-st180.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["classic car"]
                    },
                    new Car {
                        name = "BMW M3",
                        shortDesc = "Cool and stylish",
                        longDesc = "Comfortable and fast car",
                        img = "/img/BMW.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["classic car"]
                    },
                    new Car {
                        name = "Mercedes C class",
                        shortDesc = "Cozy and large",
                        longDesc = "Comfortable car for city life",
                        img = "/img/Mercedes.png",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = Categories["classic car"]
                    },
                    new Car {
                        name = "Nissan leaf",
                        shortDesc = "Silent and economical",
                        longDesc = "Comfortable and economical car for city life",
                        img = "/img/Nissan.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["electro car"]
                    }
                    };
                    Car = new Dictionary<string, Car>();
                    foreach (var elem in list)
                    {
                        Car.Add(elem.name, elem);
                    }
                }
                return Car;
            }
        }

        private static Dictionary<String, Category> Category;
        public static Dictionary<String, Category> Categories {
            get {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "electro car", desc = "modern type of transport"},
                        new Category { categoryName = "classic car", desc = "internal combustion engine machines"}
                    };
                    Category = new Dictionary<string, Category>();
                    foreach (var elem in list)
                    {
                        Category.Add(elem.categoryName, elem);
                    }
                }
                return Category;
            }

        }
    }
}
