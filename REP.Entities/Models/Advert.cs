using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.Entities.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
