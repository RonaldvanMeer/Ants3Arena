namespace Ants3Arena.Api.Models.ViewModels
{
    public class AntViewModel : BaseViewModel
    {
        public DirectionViewModel Direction { get; set; }
        public int VerticalVelocity { get; set; }
        public int HorizontalVelocity { get; set; }
        public AntColorViewModel Color { get; set; }
    }
}
