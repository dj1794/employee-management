using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Infrastructure
{
    public class LookupType:DomainBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
