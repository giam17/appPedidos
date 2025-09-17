using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace TuProyecto.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }

        [Required, StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string PasswordHash { get; set; } = string.Empty; 

        [Required, StringLength(20)]
        public string Rol { get; set; } = "cliente"; 

        public ICollection<Order>? Orders { get; set; }
    }
}
