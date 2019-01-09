using System;
using System.Text;

namespace Figures.Lib
{
    public class Circle: IFigure
    {
        protected decimal _radius;

        public bool IsValid()
        {
            return _radius > 0;
        }

        public void SetParams(decimal radius)
        {
            _radius = radius;
        }

        public void SetParamsFromJson(Newtonsoft.Json.Linq.JToken figureParams)
        {
            if (figureParams.Type != Newtonsoft.Json.Linq.JTokenType.Object)
            {
                throw new System.ArgumentException();
            }

            decimal? radius = figureParams.Value<decimal?>("radius");

            if (!radius.HasValue)
            {
                throw new System.ArgumentException();
            }

            _radius = (decimal)radius;
        }

        public decimal CalculateArea()
        {
            if (!IsValid()) throw new System.ArgumentException("The circle is invalid");

            decimal PI = (decimal)Math.PI;
            decimal area = PI * _radius * _radius;

            return area;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Circle: ");
            sb.Append("radius = " + _radius);

            return sb.ToString();
        }
    }
}
