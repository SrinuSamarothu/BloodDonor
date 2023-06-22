using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class DonorLogin
    {
        public Guid id { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
