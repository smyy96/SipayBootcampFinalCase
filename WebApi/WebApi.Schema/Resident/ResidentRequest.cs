using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Schema.Resident
{
    public class ResidentRequest
    {
        public string FullName { get; set; }
        public string TCNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehiclePlate { get; set; }
    }
}
