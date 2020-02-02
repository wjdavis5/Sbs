using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SbsWeb.Data
{
    public class Owner
    {
        private ICollection<Board> _boards;
        private ICollection<Square> _squares;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }


        public ICollection<Board> Boards
        {
            get => _boards ?? new List<Board>();
            set => _boards = value;
        }

        public ICollection<Square> Squares
        {
            get => _squares ?? new List<Square>();
            set => _squares = value;
        }

        public static Owner NoOwner => new Owner(){EmailAddress = "NOOWNER"};

        public Owner(string emailAddress, string surName,string givenName,ICollection<Board> boards, ICollection<Square> squares)
        {
            EmailAddress = emailAddress;
            SurName = surName;
            GivenName = givenName;
            Boards = boards ?? new List<Board>();
            Squares = squares ?? new List<Square>();
        }

        private Owner() { }

    }

    
}