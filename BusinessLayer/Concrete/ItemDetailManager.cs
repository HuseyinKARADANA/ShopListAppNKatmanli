using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ItemDetailManager : IItemDetailService
    {
        private readonly IItemDetailDal _itemDetailDal;

        public ItemDetailManager(IItemDetailDal itemDetailDal)
        {
            _itemDetailDal = itemDetailDal;
        }
        public void Delete(ItemDetail t)
        {
            _itemDetailDal.Delete(t);
        }

        public ItemDetail GetElementById(int id)
        {
            return _itemDetailDal.GetElementById(id);
        }

        public List<ItemDetail> GetListAll()
        {
            return _itemDetailDal.GetListAll();
        }

        public void Insert(ItemDetail t)
        {
            _itemDetailDal.Insert(t);
        }

        public void Update(ItemDetail t)
        {
            _itemDetailDal.Update(t);
        }
    }
}
