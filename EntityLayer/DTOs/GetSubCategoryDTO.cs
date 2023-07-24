using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class GetSubCategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public static explicit operator GetSubCategoryDTO(SubCategory subCategory)
        {
            return new GetSubCategoryDTO
            {
                CategoryId = subCategory.CategoryId,
                Name = subCategory.Name
            };
        }
    }
}
