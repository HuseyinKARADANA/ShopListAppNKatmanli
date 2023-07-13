using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()//bu kod bloğundan emin değilim işe  yaramazsa düzenlenir 
             .UseSqlServer("connectionString")                      // AppDbContext  sayfasında options istediği için bunu yapıyoruz
             .Options;


            var context = new AppDbContext(options);
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetElementById(int id)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlServer("connectionString")
             .Options;

            using var context = new AppDbContext(options);
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlServer("connectionString")
             .Options;
            using var context = new AppDbContext(options);
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlServer("connectionString")
             .Options;
            using var context = new AppDbContext(options);
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlServer("connectionString")
             .Options;
            using var context = new AppDbContext(options);
            context.Update(t);
            context.SaveChanges();
        }
    }
}
