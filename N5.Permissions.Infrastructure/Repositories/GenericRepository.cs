using Microsoft.EntityFrameworkCore;
using N5.Permissions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PermissionContext _context;
        private DbSet<T> table;

        public GenericRepository(PermissionContext context)
        {
            _context = context;
            table = _context.Set<T>(); ;
        }

        public void Delete(int id)
        {
            T existing = table.Find(id)!;
            table.Remove(existing!);
        }

        public IEnumerable<T> GetAll()
        {
            return table.AsEnumerable();
        }

        public T GetById(int id)
        {
            return table.SingleOrDefault(s => s.Id == id)!;
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
