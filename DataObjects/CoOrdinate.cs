using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class CoOrdinateCompare : IEqualityComparer<CoOrdinate>
    {
        public bool Equals(CoOrdinate left, CoOrdinate right)
        {
            if (left.XCoOrdinate == right.XCoOrdinate && left.YCoOrdinate == right.YCoOrdinate)
                return true;
            return false;
        }

        public int GetHashCode(CoOrdinate coOrdinate)
        {
            return (coOrdinate.XCoOrdinate + coOrdinate.YCoOrdinate);
        }
    }

    public class CoOrdinate 
    {
        public int XCoOrdinate { get; private set; }
        public int YCoOrdinate { get; private set; }

        public CoOrdinate(int xCoOrdinate, int yCoOrdinate)
        {
            XCoOrdinate = xCoOrdinate;
            YCoOrdinate = yCoOrdinate;
        }

        public static CoOrdinate GetCoOrdinate(string text)
        {
            string[] coOrdinates = text.Split('_');
            return new CoOrdinate(Int32.Parse(coOrdinates[0]), Int32.Parse(coOrdinates[1])); 
        }

        public bool Equals(CoOrdinate incomingCoOrdinate)
        {
            if (XCoOrdinate == incomingCoOrdinate.XCoOrdinate && YCoOrdinate == incomingCoOrdinate.YCoOrdinate)
                return true;
            return false;
        }
    }
}
