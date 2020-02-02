using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SbsWeb.Data
{
    public class Board 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Square> Squares { get; set; }
        public virtual Owner Owner { get; set; }
        public long OwnerId { get; set; }
        public bool IsPublic { get; set; }

        public string RowLabel { get; private set; }
        public string ColLabel { get; private set; }
        
        [NotMapped]
        public short[] RowNumberArray
        {
            get
            {
                string[] tab = this.RowNumbers.Split(',');
                return new short[] { short.Parse(tab[0]), short.Parse(tab[1]), short.Parse(tab[2]), short.Parse(tab[3]), short.Parse(tab[4]), short.Parse(tab[5]), short.Parse(tab[6]), short.Parse(tab[7]), short.Parse(tab[8]), short.Parse(tab[9]) };
            }
            set
            {
                this.RowNumbers =
                    $"{value[0]},{value[1]},{value[2]},{value[3]},{value[4]},{value[5]},{value[6]},{value[7]},{value[8]},{value[9]}";
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ColNumbers { get; set; }


        [NotMapped]
        public short[] ColNumberArray
        {
            get
            {
                string[] tab = this.ColNumbers.Split(',');
                return new short[] { short.Parse(tab[0]), short.Parse(tab[1]), short.Parse(tab[2]), short.Parse(tab[3]), short.Parse(tab[4]), short.Parse(tab[5]), short.Parse(tab[6]), short.Parse(tab[7]), short.Parse(tab[8]), short.Parse(tab[9]) };
            }
            set
            {
                this.ColNumbers =
                    $"{value[0]},{value[1]},{value[2]},{value[3]},{value[4]},{value[5]},{value[6]},{value[7]},{value[8]},{value[9]}";
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RowNumbers { get; set; }

        #region Privates
        private int NumRows { get; }
        private int NumCols { get; }
        #endregion

        public Board(string rowLabel, string colLabel, string name) : this()
        {
            RowLabel = rowLabel;
            ColLabel = colLabel;
            Name = name;
        }
        private Board()
        {
            Squares = new List<Square>();
            NumCols = 10;
            NumRows = 10;
            SetupBoard();
        }

        private void SetupBoard()
        {
            RowNumberArray = GenerateNumbers();
            ColNumberArray = GenerateNumbers();
            var squareNumber = 1;
            for (var row = 0; row < RowNumberArray.Length; row++)
            {
                for (var col = 0; col < ColNumberArray.Length; col++)
                {
                    var square = new Square(squareNumber++, RowNumberArray[row], ColNumberArray[col]);
                    Squares.Add(square);
                }
            }
        }

        
        public short[] GenerateNumbers()
        {
            var result = new List<short>();
            while (result.Count != BoardSettings.PossibleNumbers.Length)
            {
                var pick = BoardSettings.PossibleNumbers[BoardSettings.Random.Next(BoardSettings.PossibleNumbers.Except(result).Min(), BoardSettings.PossibleNumbers.Except(result).Max())];
                if (result.Contains(pick)) continue;
                result.Add(pick);
            }
            return result.ToArray();
        }


    }
}
