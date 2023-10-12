using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Infrastructure
{
   
    public abstract class DomainBase
    {
        [Key]
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
