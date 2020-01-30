using System.ComponentModel.DataAnnotations.Schema;

namespace SbsLib
{
    public class Square 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Location { get; set; }
        public Owner Owner { get; set; }
        public Board Board { get; set; }
        public short ValueX { get; set; }
        public short ValueY { get; set; }

        public Square(int location, Board board, short valueX, short valueY)
        {
            Location = location;
            Owner = Owner.NoOwner;
            Board = board;
            ValueX = valueX;
            ValueY = valueY;
        }

        public override string ToString()
        {
            return $"Location: {Location}\r\nXVal:{ValueX}\r\nYVal:{ValueY}";
        }
    }
}