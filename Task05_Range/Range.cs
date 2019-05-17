using System;

namespace Task05_Range
{
    class Range
    {
        private double from;
        private double to;

        public Range(double from, double to)
        {
            if (from <= to)
            {
                this.from = from;
                this.to = to;
            }
            else
            {
                this.from = to;
                this.to = from;
            }

        }

        public double From
        {
            get { return from; }
            set { from = value; }
        }

        public double To
        {
            get { return to; }
            set { to = value; }
        }

        public double getLength()
        {
            return Math.Abs(to - from);
        }

        public bool IsInside(double point)
        {
            return (from <= point) && (point <= to);
        }

        public override string ToString()
        {
            return "[" + from + " ; " + to + "]";
        }
    }
}
