using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository.EntityFramework
{       
    public class EfUserDal :GenericRepository<User>,IUserDal //User işlemlerine erişebilmek için yaptık
    {

    }
}
