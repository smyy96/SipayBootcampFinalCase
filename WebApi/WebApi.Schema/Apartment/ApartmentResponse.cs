using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Schema.Apartment
{
    public class ApartmentResponse
    {
        public string Block { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public int? ResidentId { get; set; }
    }
}
