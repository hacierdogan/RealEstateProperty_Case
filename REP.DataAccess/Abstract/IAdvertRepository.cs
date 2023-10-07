using REP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.DataAccess.Abstract
{
    public interface IAdvertRepository
    {
        Task<List<Advert>> GetAll();
        Task<Advert> GetById(int id);
        Task<Advert> Create(Advert advert);
        Task<Advert> Update(Advert advert);
        Task Delete(int id);
    }
}
