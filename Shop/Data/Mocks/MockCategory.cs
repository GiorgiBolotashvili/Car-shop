using Shop.Data.InterFaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "electro car", desc = "modern type of transport"},
                    new Category { categoryName = "classic car", desc = "internal combustion engine machines"}
                };
            }
        }
    }
}
