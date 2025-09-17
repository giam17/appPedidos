using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public User? Cliente { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [Required, StringLength(20)]
        public string Estado { get; set; } = "Pendiente"; 

        [Precision(18, 2)]
        [Range(0, 999999999)]
        public decimal Total { get; set; } = 0m; 

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
