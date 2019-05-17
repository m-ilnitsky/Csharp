using System;

namespace Task05_Range
{
    class Range
    {
        public Range(double from, double to)
        {
            if (from <= to)
            {
                From = from;
                To = to;
            }
            else
            {
                From = to;
                To = from;
            }
        }

        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double point)
        {
            return (From <= point) && (point <= To);
        }

        public override string ToString()
        {
            return "[" + From + " ; " + To + "]";
        }
    }
}
