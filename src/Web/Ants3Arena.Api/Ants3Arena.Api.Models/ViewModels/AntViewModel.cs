using System.ComponentModel.DataAnnotations;

namespace Ants3Arena.Api.Models.ViewModels
{
    public class AntViewModel : BaseViewModel
    {
        [Required]
        public DirectionViewModel Direction { get; set; } = new DirectionViewModel();
        [Required]
        public int VerticalVelocity { get; set; }
        [Required]
        public int HorizontalVelocity { get; set; }
        [Required]
        public AntColorViewModel Color { get; set; } = new AntColorViewModel();
    }
}
