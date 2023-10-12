using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Infrastructure
{
    public class Lookup:DomainBase
    {
        [ForeignKey("LookupTypeId")]
        public long LookupTypeId { get; set; }
        public virtual required LookupType LookupType { get; set; }
        public required string Name { get; set; }
        public string? Discription { get; set; }
    }
}
