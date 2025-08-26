namespace Ants3Arena.Api.Models.Dtos
{
    public class AntDto : BaseDto
    {
        public DirectionDto Direction { get; set; } = new DirectionDto();
        public int VerticalVelocity { get; set; }
        public int HorizontalVelocity { get; set; }
        public AntColorDto Color { get; set; } = new AntColorDto();
    }
}
