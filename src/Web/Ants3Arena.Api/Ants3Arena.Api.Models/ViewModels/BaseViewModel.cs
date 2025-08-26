using System.ComponentModel.DataAnnotations;

namespace Ants3Arena.Api.Models.ViewModels
{
    public class BaseViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
