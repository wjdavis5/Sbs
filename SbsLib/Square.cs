using System.ComponentModel.DataAnnotations.Schema;

namespace SbsLib
{
    public class Square 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Owner Owner { get; set; }
        public Board Board { get; set; }
        public short ValueX { get; set; }
        public short ValueY { get; set; }

        public short BoardLocationX { get; set; }
        public short BoardLocationY { get; set; }

        public Square(short valueX,short valueY)
        {
            ValueX = valueX;
            ValueY = valueY;
            Owner = Owner.NoOwner;
        }
    }
}