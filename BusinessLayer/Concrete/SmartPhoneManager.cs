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
    public class SmartPhoneManager : ISmartPhoneService
    {
        private readonly ISmartPhoneDal _smartPhoneDal;

        public SmartPhoneManager(ISmartPhoneDal smartPhoneDal)
        {
            _smartPhoneDal = smartPhoneDal;
        }
        public void Delete(SmartPhone t)
        {
            _smartPhoneDal.Delete(t);
        }

        public SmartPhone GetElementById(int id)
        {
            return _smartPhoneDal.GetElementById(id);
        }

        public List<SmartPhone> GetListAll()
        {
            return _smartPhoneDal.GetListAll();
        }

        public void Insert(SmartPhone t)
        {
            _smartPhoneDal.Insert(t);
        }

        public void Update(SmartPhone t)
        {
            _smartPhoneDal.Update(t);
        }
    }
}
