using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty or contain only whitespace.");
            }

            if (Summaries.Any(s => s.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("Name already exists.");
            }

            Summaries.Add(name);
            return Ok();
        }


        [HttpPut]

        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Invalid index!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty or contain only whitespace.");
            }

            if (Summaries.Any(s => s.Equals(name, StringComparison.OrdinalIgnoreCase) && !s.Equals(Summaries[index], StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("Name already exists.");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Invalid index!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return  "NotFound";
            }

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int GetCountByName(string name)
        {
            return Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            // ���� �������� sortStrategy �� ���� ��������, ���������� ������ ��� ���������.
            if (!sortStrategy.HasValue)
            {
                return Ok(Summaries);
            }

            // ���� �������� sortStrategy ����� 1, ���������� ��������������� �� ����������� ������.
            if (sortStrategy.Value == 1)
            {
                return Ok(Summaries.OrderBy(s => s));
            }

            // ���� �������� sortStrategy ����� -1, ���������� ��������������� �� �������� ������.
            if (sortStrategy.Value == -1)
            {
                return Ok(Summaries.OrderByDescending(s => s));
            }

            // ��� ��������� �������, ���������� ������ � ��������������� ����������.
            return BadRequest("Incorrect value of sortStrategy parameter.");
        }


    }
}