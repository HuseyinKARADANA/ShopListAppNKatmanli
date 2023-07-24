using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ItemManager : IItemService
    {
        private readonly IItemDal _itemDal;

        public ItemManager(IItemDal itemDal)
        {
            _itemDal=itemDal;
        }

        public void Delete(Item t)
        {
            _itemDal.Delete(t);
        }

        public Item GetElementById(int id)
        {
            return _itemDal.GetElementById(id);
        }

        public List<Item> GetListAll()
        {
           return _itemDal.GetListAll();
        }

        public void Insert(Item t)
        {
            _itemDal.Insert(t);
        }

        public void Update(Item t)
        {
            _itemDal.Update(t);
        }

        public Item GetItemByBrand(string brand)
        {
            return _itemDal.GetItemByBrand(brand);
        }
    }
}
