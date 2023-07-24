using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class GetCategoryDetailDTO
    {
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public static explicit operator GetCategoryDetailDTO(CategoryDetail categoryDetail)
        {
            return new GetCategoryDetailDTO
            {
                SubCategoryId = categoryDetail.SubCategoryId,
                CategoryId = categoryDetail.CategoryId,
                Name = categoryDetail.Name,
            };
        }
    }
}
