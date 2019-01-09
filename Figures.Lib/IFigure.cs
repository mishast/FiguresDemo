using System;

namespace Figures.Lib
{
    public interface IFigure
    {
        /// <summary>
        /// Calculate area of figure
        /// </summary>
        decimal CalculateArea();

        /// <summary>
        /// Check is figure valid
        /// </summary>
        bool IsValid();

        void SetParamsFromJson(Newtonsoft.Json.Linq.JToken figureParams);
    }
}
