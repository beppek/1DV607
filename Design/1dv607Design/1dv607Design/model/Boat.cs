using System;

namespace _1dv607Design.model
{
    public class Boat
    {
        private double _length;

        /// <summary>
        /// Cosntructor for Boat
        /// </summary>
        /// <param name="boatType">Enum BoatType - Sailboat, Motorsailer, Kayak, Other</param>
        /// <param name="length"></param>
        public Boat(BoatType boatType, double length)
        {
            Type = boatType;
            Length = length;
        }

        public double Length
        {
            get { return _length; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _length = value;
            }
        }

        public BoatType Type
        { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, Length: {Length}";
        }
    }
}