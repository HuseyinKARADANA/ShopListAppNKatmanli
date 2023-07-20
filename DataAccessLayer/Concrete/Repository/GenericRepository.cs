using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
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
        private readonly DbContextOptions<AppDbContext> options;
        public GenericRepository(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }
        public void Delete(T t)
        {

            var context = new AppDbContext(options);
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetElementById(int id)
        {
            
            using var context = new AppDbContext(options);
            return context.Set<T>().Find(id);
        }

        public User GetElementByUsername(string username)
        {
            using var context = new AppDbContext(options);
            return context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public List<T> GetListAll()
        {
            
            using var context = new AppDbContext(options);
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
           
            using var context = new AppDbContext(options);
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
        
            using var context = new AppDbContext(options);
            context.Update(t);
            context.SaveChanges();
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            using var context = new AppDbContext(options);
            return context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
