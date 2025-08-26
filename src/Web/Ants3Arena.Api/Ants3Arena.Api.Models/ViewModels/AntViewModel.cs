using System.ComponentModel.DataAnnotations;

namespace Ants3Arena.Api.Models.ViewModels
{
    public class AntViewModel : BaseViewModel
    {
        public DirectionViewModel Direction { get; set; } = new DirectionViewModel();
        public int VerticalVelocity { get; set; }
        public int HorizontalVelocity { get; set; }
        public AntColorViewModel Color { get; set; } = new AntColorViewModel();
    }
}
