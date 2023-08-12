using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Purchase : EntityDefaults
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Dated { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int QuantityPurchased { get; set; }
    }
}
