using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectA.Models;
using RestSharp;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        // GET: api/<WeatherApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WeatherApiController>/5
        [HttpGet]
        [Route("/GetWeather")]
        public Wind GetWeather()
        {

            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?lat=9.9312&lon=76.2673&appid=5c846ccb12d264eb0d469cd27ebf6ce9");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            var wheather= JsonConvert.DeserializeObject<Wheather>(response.Content);





            //response.Content.
            return wheather.wind;
        }

        // POST api/<WeatherApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
