using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SbsLib
{
    public class Board 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public ICollection<Square> Squares { get; set; }
        public Owner Owner { get; set; }
        public string RowLabel { get; private set; }
        public string ColLabel { get; private set; }
        public short[] RowNumbers { get; private set; }
        public short[] ColNumbers { get; private set; }

        #region Privates
        private int NumRows { get; }
        private int NumCols { get; }
        private Square[,] BoardArr { get; }
        #endregion

        public Board(string rowLabel, string colLabel) : this()
        {
            RowLabel = rowLabel;
            ColLabel = colLabel;
        }
        private Board()
        {
            NumCols = 10;
            NumRows = 10;
            BoardArr = new Square[NumCols, NumRows];
            SetupBoard();
        }

        private void SetupBoard()
        {
            RowNumbers = GenerateNumbers();
            ColNumbers = GenerateNumbers();
            for (var row = 0; row < RowNumbers.Length - 1; row++)
            {
                for (var col = 0; col < ColNumbers.Length - 1; col++)
                {
                    var square = new Square(RowNumbers[row], ColNumbers[col]);
                    BoardArr[row, col] = square;
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
