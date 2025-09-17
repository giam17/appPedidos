using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TuProyecto.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Range(1, 999999)]
        public int Cantidad { get; set; } = 1;

        [Precision(18, 2)]
        [Range(0.01, 9999999)]
        public decimal PrecioUnitario { get; set; }

    }
}
