using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Figures.Lib;

namespace Figures.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiguresController : ControllerBase
    {
        // api/figures/getAvailableFigures
        [HttpGet]
        [Route("getAvailableFigures")]
        public IEnumerable<string> GetAvailableFigures()
        {
            FiguresFactory figuresFactory = new FiguresFactory();
            var list = figuresFactory.GetAvailableFigures();
            return list;
        }

        // POST api/figures/calculateArea
        [HttpPost]
        [Route("calculateArea")]
        public IActionResult CalculateArea([FromBody] JToken jsonData)
        {
            if (jsonData.Type != JTokenType.Object)
            {
                return BadRequest(new
                {
                    error = "Figure must be object"
                });
            }

            var jfigure = (JObject)jsonData;

            string figureName = jfigure.Value<string>("figure");

            if (figureName == null)
            {
                return BadRequest(new
                {
                    error = "Figure object must contain figure key"
                });
            }

            FiguresFactory figuresFactory = new FiguresFactory();
            IFigure figure = figuresFactory.GetFigure(figureName);

            if (figure == null)
            {
                return BadRequest(new
                {
                    error = "Unknown figure type"
                });
            }

            var jtokenParams = jfigure["params"];

            try
            {
                figure.SetParamsFromJson(jtokenParams);
            }
            catch
            {
                return BadRequest(new
                {
                    error = "Invalid figure arguments"
                });
            }

            decimal area = 0m;

            try
            {
                area = figure.CalculateArea();
            }
            catch (System.ArgumentException)
            {
                return BadRequest(new
                {
                    error = "Invalid figure arguments"
                }); 
            }
            catch (System.OverflowException)
            {
                return BadRequest(new
                {
                    error = "Overflow caused during calculation. Arguments is too big"
                }); 
            }

            return Ok(new { area = area });
        }
    }
}
