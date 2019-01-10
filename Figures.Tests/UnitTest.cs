using System;
using Xunit;
using Figures.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Figures.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestCircleValue()
        {
            FiguresFactory factory = new FiguresFactory();
            IFigure figure = factory.GetFigure("circle");

            var jparams = JToken.Parse(@"{ 'radius': 10 }");

            figure.SetParamsFromJson(jparams);

            decimal expected = 314.15926535897900m;
            decimal area = figure.CalculateArea();

            Assert.Equal(expected, area, 25);
        }

        [Fact]
        public void TestCircleOverflow()
        {
            Circle circle = new Circle();

            circle.SetParams(Decimal.MaxValue - 1);

            Assert.Throws<OverflowException>( () => circle.CalculateArea());
        }

        [Fact]
        public void TestCircleArgumentException()
        {
            Circle circle = new Circle();

            circle.SetParams(-5);

            Assert.Throws<ArgumentException>( () => circle.CalculateArea());
        }

        [Fact]
        public void TestTriangleValue()
        {
            FiguresFactory factory = new FiguresFactory();
            IFigure figure = factory.GetFigure("triangle");

            var jparams = JToken.Parse(@"{ 'a': 10, 'b': 10, 'c': 10 }");

            figure.SetParamsFromJson(jparams);

            decimal expected = 43.30127018922193233818615854m;
            decimal area = figure.CalculateArea();

            Assert.Equal(expected, area, 25);
        }

        [Fact]
        public void TestTriangleIsRecnagle()
        {
            bool isRectangular = false;

            Triangle triangle = new Triangle();
            triangle.SetParams(10, 10, 10);
            
            isRectangular = triangle.IsRectangular();

            Assert.Equal(isRectangular, false);

            triangle.SetParams(3, 4, 5);

            isRectangular = triangle.IsRectangular();

            Assert.Equal(isRectangular, true);

            triangle.SetParams(3, 3, 4.242640687m);

            isRectangular = triangle.IsRectangular(0.00000001m);

            Assert.Equal(isRectangular, true);
        }

        [Fact]
        public void TestTriangleOverflow()
        {
            Triangle triangle = new Triangle();

            triangle.SetParams(Decimal.MaxValue - 1, Decimal.MaxValue - 1, Decimal.MaxValue - 1);

            Assert.Throws<OverflowException>( () => triangle.CalculateArea());
        }

        [Fact]
        public void TestTriangleArgumentException()
        {
            Triangle triangle = new Triangle();

            triangle.SetParams(-1, -2, -3);

            Assert.Throws<ArgumentException>( () => triangle.CalculateArea());
        }
    }
}
