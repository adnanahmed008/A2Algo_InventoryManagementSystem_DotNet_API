using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class SaleDTO
    {
        public Guid Id { get; set; }
        public DateTime Dated { get; set; }
        public Guid ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
