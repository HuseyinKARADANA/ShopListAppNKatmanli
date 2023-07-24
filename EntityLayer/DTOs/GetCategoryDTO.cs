using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class GetCategoryDTO
    {
        public string Name { get; set; }

        public static explicit operator GetCategoryDTO(Category category)
        {
            return new GetCategoryDTO
            {
                Name = category.Name
            };
        }
    }
}
