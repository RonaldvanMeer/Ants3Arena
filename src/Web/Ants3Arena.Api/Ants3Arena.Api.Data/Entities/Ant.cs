namespace Ants3Arena.Api.Data.Entities
{
    public class Ant : BaseEntity
    {
        public virtual Direction Direction { get; set; } = new Direction();
        public int VerticalVelocity { get; set; }
        public int HorizontalVelocity { get; set; }
        public virtual AntColor Color { get; set; } = new AntColor();
    }
}
