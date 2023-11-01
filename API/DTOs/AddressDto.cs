using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public bool IsMain { get; set; }
        
    }
}