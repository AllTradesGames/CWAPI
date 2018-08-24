using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CWAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrianglesController : ControllerBase
    {
        // GET api/triangles
        [HttpGet]
        public ActionResult Get([FromQuery] string points = null, [FromQuery] string row = null, [FromQuery] int column = -1)
        {
            Triangle triangle;

            if (points != null && points.Length > 0)
            {
                try
                {
                    int[][] dsPoints = JsonConvert.DeserializeObject<int[][]>(points);
                    Point[] inputPoints = new Point[dsPoints.Length];
                    for (int ii = 0; ii < dsPoints.Length; ii++)
                    {
                        inputPoints[ii] = new Point(dsPoints[ii][0], dsPoints[ii][1]);
                    }
                    triangle = new Triangle(inputPoints);
                    return Ok(triangle);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else if (row != null && column > 0)
            {
                triangle = new Triangle(row, column);
                return Ok(triangle.GetPoints());
            }
            return BadRequest();
        }

    }
}
