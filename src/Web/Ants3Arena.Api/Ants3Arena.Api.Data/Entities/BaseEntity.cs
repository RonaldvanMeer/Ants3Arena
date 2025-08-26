using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ants3Arena.Api.Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
