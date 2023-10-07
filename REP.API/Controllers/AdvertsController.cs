using Microsoft.AspNetCore.Mvc;
using REP.Business.Abstract;
using REP.Entities.Models;


namespace REP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        protected IAdvertService _advertService;
        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Advert> list = await _advertService.GetAllAdvert();
            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Advert advert = await _advertService.GetAdvertById(id);
            if (advert != null)
            {
                return Ok(advert);
            }
            return NoContent();
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string type,string city,double minPrice,double maxPrice)
        {
            List<Advert> list = await _advertService.GetAllAdvert();
            
            if (!string.IsNullOrEmpty(type))
            {
                list = list.Where(w => w.Type == type).ToList();
            }
            if (!string.IsNullOrEmpty(city))
            {
                list = list.Where(w => w.City == city).ToList();
            }
            if (minPrice>0)
            {
                list = list.Where(w => w.Price >=minPrice).ToList();
            }
            if (maxPrice>0)
            {
                list = list.Where(w => w.Price <=maxPrice).ToList();
            }

            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Advert advert)
        {
            var createAdvert = await _advertService.Create(advert);
            return CreatedAtAction("Get", new { id = createAdvert.Id }, createAdvert);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Advert advert)
        {
            if (await _advertService.GetAdvertById(advert.Id) != null)
            {
                return Ok(await _advertService.Update(advert));
            }
            return NotFound();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _advertService.GetAdvertById(id) != null)
            {
                await _advertService.Delete(id);
            }
            return NotFound();
        }
    }
}
