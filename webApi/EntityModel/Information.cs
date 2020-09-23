using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.EntityModel
{
    public class Information
    {
        public Information()
        {
            Address = new List<Address>();
        }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Profession { get; set; }
        public virtual List<Address> Address { get; set; }
    }
}
