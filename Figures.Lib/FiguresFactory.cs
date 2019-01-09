using System;
using System.Collections.Generic;

namespace Figures.Lib
{
    public class FiguresFactory
    {
        protected Dictionary<string, Type> _figures;
        public FiguresFactory()
        {
            _figures = new Dictionary<string, Type>();
            _figures.Add("circle", typeof(Circle));
            _figures.Add("triangle", typeof(Triangle));
        }

        public List<string> GetAvailableFigures()
        {
            return new List<string>(_figures.Keys);
        }

        public IFigure GetFigure(string figureName)
        {
            if (_figures.ContainsKey(figureName))
            {
                return (IFigure)Activator.CreateInstance(_figures[figureName]);
            }
            else
            {
                return null;
            }
        }
    }
}