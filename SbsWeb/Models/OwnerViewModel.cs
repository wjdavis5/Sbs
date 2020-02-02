using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SbsWeb.Data;

namespace SbsWeb.Models
{
    public class OwnerViewModel
    {
        public Owner Owner { get; set; }
        public bool HasSquares => Owner.Squares.Any();
        public bool HasBoards => Owner.Boards.Any();
    }
}
