using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SbsLib
{
    public class Owner
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Board> Boards { get; set; }
        public ICollection<Square> Squares { get; set; }
        public static Owner NoOwner => new Owner(){EmailAddress = "NOOWNER"};

    }

    
}