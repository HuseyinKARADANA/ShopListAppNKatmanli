using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class AddSubCategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public static explicit operator AddSubCategoryDTO(SubCategory subCategory)
        {
            return new AddSubCategoryDTO
            {
                CategoryId = subCategory.CategoryId,
                Name = subCategory.Name
            };
        }
    }
}
