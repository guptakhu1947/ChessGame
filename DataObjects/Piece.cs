using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class PieceComparer : IEqualityComparer<Piece>
    {
        public bool Equals(Piece x, Piece y)
        {
           return x.Color == y.Color && x.Type == y.Type;
        }

        public int GetHashCode(Piece obj)
        {
            return (obj.Type.GetHashCode()+obj.Color.GetHashCode());
        }
    }

    public abstract class Piece
    {
        public Color Color { get; private set; }
        public CoOrdinate FromCoOrdinate { get; private set; }
        public CoOrdinate CurrentCoOrdinate { get; private set; }
        public Image Image { get; private set; }
        public PieceType Type { get; protected set; }
        private int yCoOrdinateFirst = 0;
        private int yCoOrdinateSecond = 7;
                
        protected int GetYCoOrdinate(Color color)
        {
            return color == Color.White ? yCoOrdinateFirst : yCoOrdinateSecond;
        }

        public abstract Dictionary<CoOrdinate, Piece> SetUp(Color color);
        public abstract bool IsValidMove(CoOrdinate to, History history);

        protected Piece() { }

        protected Piece(Color color, CoOrdinate coOrdinate, PieceType name)
        {
            Type = name;
            Color = color;
            FromCoOrdinate = CurrentCoOrdinate = coOrdinate;
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);   
            string path = Path.Combine(@"..\..\Images", Color.ToString());
            Image = Image.FromFile(Path.Combine(path, Type + "_" + Color.ToString() + ".png"));
            Image = (Image)(new Bitmap(Image, new Size(30,30)));
        }

        public void Move(CoOrdinate coOrdinate)
        {
            FromCoOrdinate = CurrentCoOrdinate;
            CurrentCoOrdinate = coOrdinate;
        }
    }
}
