using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Common
{
    public class EntityDefaults : IEntityDefaults
    {
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public string? ModifiedBy { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
