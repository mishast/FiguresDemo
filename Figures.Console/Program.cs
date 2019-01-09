using System;
using System.IO;
using Figures.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Figures.Console
{
    //
    // Accepts a json-file describing figures.
    // Calculates area for each figure and total area.
    //
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello! It's batch calculator.");

            if (args.Length != 1)
            {
                System.Console.WriteLine("Usage: Program.exe <input json file>");
                return;
            }

            decimal totalArea = 0m;
            FiguresFactory figuresFactory = new FiguresFactory();

            using (StreamReader file = File.OpenText(args[0]))
            {
                JsonTextReader reader = new JsonTextReader(file);
                var jtoken = JToken.Load(reader);

                if (jtoken.Type != JTokenType.Array)
                {
                    System.Console.WriteLine("Error! File must contain json array");
                    return;
                }

                var jarray = (JArray)jtoken;

                foreach (JToken jtokenFigure in jarray)
                {
                    if (jtokenFigure.Type != JTokenType.Object)
                    {
                        System.Console.WriteLine("Error! Each element of array must contain object");
                    }

                    var jfigure = (JObject)jtokenFigure;

                    string figureName = jfigure.Value<string>("figure");

                    if (figureName == null)
                    {
                        System.Console.WriteLine("Error! Figure object must contain figure key");
                        return;
                    }

                    IFigure figure = figuresFactory.GetFigure(figureName);

                    if (figure == null)
                    {
                        System.Console.WriteLine("Error! Unknown figure");
                        return;
                    }

                    var jtokenParams = jfigure["params"];

                    figure.SetParamsFromJson(jtokenParams);

                    System.Console.WriteLine(figure.ToString());

                    decimal area = figure.CalculateArea();

                    System.Console.WriteLine("Area = " + area);
                    System.Console.WriteLine();

                    totalArea += area;
                }
            }

            System.Console.WriteLine("TotalArea = " + totalArea);

        }
    }
}
