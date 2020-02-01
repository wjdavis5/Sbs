using System.ComponentModel.DataAnnotations.Schema;

namespace SbsWeb.Data
{
    public class Square 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Location { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Board Board { get; set; }
        public long OwnerId { get; set; }
        public long BoardId { get; set; }
        public short ValueX { get; set; }
        public short ValueY { get; set; }

        public Square(int location, short valueX, short valueY)
        {
            Location = location;
            Owner = Owner.NoOwner;
            ValueX = valueX;
            ValueY = valueY;
        }

        public override string ToString()
        {
            return $"Location: {Location}\r\nXVal:{ValueX}\r\nYVal:{ValueY}";
        }
    }
}