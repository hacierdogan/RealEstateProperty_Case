using REP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.Business.Abstract
{
    public interface IAdvertService
    {
        Task<List<Advert>> GetAllAdvert();
        Task<Advert> GetAdvertById(int id);
        Task<Advert> Create(Advert advert);
        Task<Advert> Update(Advert advert);
        Task Delete(int id);
    }
}
