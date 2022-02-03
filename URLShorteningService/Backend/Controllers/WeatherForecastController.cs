using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        //End point responsible for redirecting to original URL
        [HttpGet("{urlID}")]
        public  RedirectResult Get(string urlID)
        {
            try
            {

              
                StreamReader sr = new StreamReader(@"C:\Users\mualvi\Documents\Cronofy\URLShorteningService\URLShorteningService\DB\" + urlID + ".txt");
               
                string redirectURL = sr.ReadLine();
               
                sr.Close();

                return Redirect(redirectURL);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return Redirect("");
            }
          
        }
    }
}
