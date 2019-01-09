using System;
using System.Text;

namespace Figures.Lib
{
    public class Triangle : IFigure
    {
        protected decimal _sideA;
        protected decimal _sideB;
        protected decimal _sideC;

        /// <summary>
        /// Calculates square root for decimal.
        /// Uses newton algrorithm. For worst case (x = Decimal.MaxValue, epsilon = 0) the loop
        /// executes three times.
        /// <summary>
        protected decimal Sqrt(decimal x, decimal epsilon = 0.0M)
        {
            if (x < 0) throw new OverflowException("Cannot calculate square root from a negative number");

            decimal current = (decimal)Math.Sqrt((double)x), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }
        public bool IsValid()
        {
            bool valid = true;

            valid = valid && _sideA > 0 && _sideB > 0 && _sideC > 0;
            valid = valid && _sideA + _sideB > _sideC;
            valid = valid && _sideA + _sideC > _sideB;
            valid = valid && _sideB + _sideC > _sideA;

            return valid;
        }

        public bool IsRectangular()
        {
            decimal sideA2 = _sideA * _sideA;
            decimal sideB2 = _sideB * _sideB;
            decimal sideC2 = _sideC * _sideC;

            if (sideA2 == sideB2 + sideC2) return true;
            if (sideB2 == sideA2 + sideC2) return true;
            if (sideC2 == sideA2 + sideB2) return true;

            return false;
        }

        public void SetParams(decimal sideA, decimal sideB, decimal sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        public void SetParamsFromJson(Newtonsoft.Json.Linq.JToken figureParams)
        {
            if (figureParams.Type != Newtonsoft.Json.Linq.JTokenType.Object)
            {
                throw new System.ArgumentException();
            }

            decimal? sideA = figureParams.Value<decimal?>("a");
            decimal? sideB = figureParams.Value<decimal?>("b");
            decimal? sideC = figureParams.Value<decimal?>("c");

            if (!sideA.HasValue || !sideB.HasValue || !sideC.HasValue)
            {
                throw new System.ArgumentException();
            }

            _sideA = (decimal)sideA;
            _sideB = (decimal)sideB;
            _sideC = (decimal)sideC;
        }

        public decimal CalculateArea()
        {
            if (!IsValid()) throw new System.ArgumentException("The triangle is invalid");

            decimal p = (_sideA + _sideB + _sideC) / 2;
            decimal a2 = p * (p - _sideA) * (p - _sideB) * (p - _sideC);
            decimal area = Sqrt(a2);

            return area;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Triangle: ");
            sb.Append("a = " + _sideA);
            sb.Append(", b = " + _sideB);
            sb.Append(", c = " + _sideC);

            return sb.ToString();
        }
    }
}
