using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Precision(18, 2)]
        [Range(0.01, 9999999)]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; } = 0;
    }
}
