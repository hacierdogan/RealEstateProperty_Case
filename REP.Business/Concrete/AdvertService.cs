using REP.Business.Abstract;
using REP.DataAccess.Abstract;
using REP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.Business.Concrete
{
    public class AdvertService : IAdvertService
    {
        protected IAdvertRepository _advertRepository;
        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public async Task<Advert> GetAdvertById(int id)
        {
            return await _advertRepository.GetById(id);
        }

        public async Task<List<Advert>> GetAllAdvert()
        {
            return await _advertRepository.GetAll();
        }

        public async Task<Advert> Create(Advert advert)
        {
            return await _advertRepository.Create(advert);
        }

        public async Task Delete(int id)
        {
            await _advertRepository.Delete(id);
        }

        public async Task<Advert> Update(Advert advert)
        {
            return await _advertRepository.Update(advert);
        }
    }
}
