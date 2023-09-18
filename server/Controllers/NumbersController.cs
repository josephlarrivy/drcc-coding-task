using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Cors;


namespace server.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly ILogger<NumbersController> _logger;

        public NumbersController(ILogger<NumbersController> logger)
        {
            _logger = logger;
        }

        [HttpPost("add")]
        public IActionResult AddNumbers([FromBody] int[] numbers)
        {
            LogRequest("server action: ADD", numbers); // Log the request
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest("No numbers provided.");
            }

            int sum = numbers.Sum();
            return Ok($"Sum of numbers: {sum}");
        }

        [HttpPost("average")]
        public IActionResult CalculateAverage([FromBody] int[] numbers)
        {
            LogRequest("server action: AVERAGE", numbers); // Log the request
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest("No numbers provided.");
            }

            double average = numbers.Average();
            return Ok($"Average of numbers: {average}");
        }

        [HttpPost("lowest")]
        public IActionResult FindLowest([FromBody] int[] numbers)
        {
            LogRequest("server action: FIND LOWEST", numbers); // Log the request
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest("No numbers provided.");
            }

            int lowest = numbers.Min();
            return Ok($"Lowest number: {lowest}");
        }

        [HttpPost("highest")]
        public IActionResult FindHighest([FromBody] int[] numbers)
        {
            LogRequest("server action: FIND HIGHEST", numbers); // Log the request
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest("No numbers provided.");
            }

            int highest = numbers.Max();
            return Ok($"Highest number: {highest}");
        }

        [HttpPost("difference")]
        public IActionResult CalculateDifference([FromBody] int[] numbers)
        {
            LogRequest("server action: FIND DIFFERENCE", numbers); // Log the request
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest("No numbers provided.");
            }

            int difference = numbers.Max() - numbers.Min();
            return Ok($"Difference between highest and lowest: {difference}");
        }

        // Add this method to log requests
        private void LogRequest(string endpoint, int[] numbers)
        {
            _logger.LogInformation($"Received request: {endpoint} - Numbers: [{string.Join(", ", numbers)}]");
        }
    }
}