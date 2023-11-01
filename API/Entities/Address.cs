using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Addresses")]
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public bool IsMain { get; set; }
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
        
    }
}