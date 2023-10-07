using Microsoft.EntityFrameworkCore;
using REP.DataAccess.Abstract;
using REP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.DataAccess.Concrete
{
    public class AdvertRepository : IAdvertRepository
    {
        public async Task<List<Advert>> GetAll()
        {
            using (var db = new DataContext())
            {
                return await db.Set<Advert>().ToListAsync();
            }
        }

        public async Task<Advert> GetById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Set<Advert>().FindAsync(id);
            }
        }

        public async Task<Advert> Create(Advert advert)
        {
            using (var db = new DataContext())
            {
                db.Add(advert);
                await db.SaveChangesAsync();
                return advert;
            }
        }

        public async Task<Advert> Update(Advert advert)
        {
            using (var db = new DataContext())
            {
                db.Update(advert);
                await db.SaveChangesAsync();
                return advert;
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new DataContext())
            {
                var deleteItem = await GetById(id);
                db.Remove(deleteItem);
                await db.SaveChangesAsync();
            }
        }
    }
}
