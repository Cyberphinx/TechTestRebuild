using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Models
{
    public class PersonUpdate
    {
        public bool Authorised { get; set; }
        
        public bool Enabled { get; set; }

        public IEnumerable<Colour> Colours { get; set; }
    }
}