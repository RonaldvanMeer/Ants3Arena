using System.ComponentModel.DataAnnotations;

namespace Ants3Arena.Api.Models.ViewModels
{
    public class CreateAntViewModel : BaseViewModel
    {
        [Required]
        public Guid DirectionId { get; set; }
        [Required]
        public int VerticalVelocity { get; set; }
        [Required]
        public int HorizontalVelocity { get; set; }
        [Required]
        public Guid ColorId { get; set; }
    }
}
