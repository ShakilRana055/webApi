using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.EntityModel
{
    public class Address
    {
        public int Id { get; set; }
        public string Village { get; set; }
        public string PostOffice { get; set; }
        public string PoliceStation { get; set; }
        public string District { get; set; }
        public int InformationId { get; set; }
        public virtual Information Information { get; set; }

    }
}
