using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProfile.DataAccess;
using RPE.DataAccess.Entities;

namespace RPE.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        ApplicationDbContext _context = null;
        public SampleDataController(ApplicationDbContext context)
        {
            _context = context;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        [HttpPost("Populate")]
        public async Task<ActionResult> PopulateTables()
        {
            try
            {
                Purchase purchase = new Purchase(1, "Office supply", "Staples", "12365456", "266L", 100.5, DateTime.Now, "Planning");

                purchase.Notes.Add(new Note("Follow up with John", "John Doe", DateTime.Now));
                purchase.Notes.Add(new Note("Updated the amount", "John Doe", DateTime.Now));
                purchase.Notes.Add(new Note("Got Approved", "John Doe", DateTime.Now));
                purchase.Notes.Add(new Note("Delivery is delayed", "John Doe", DateTime.Now));
                purchase.Notes.Add(new Note("Delivered", "John Doe", DateTime.Now));

                purchase.Tags.Add(new Tag("Purchase", "John Doe", DateTime.Now));
                purchase.Tags.Add(new Tag("Office Supply", "John Doe", DateTime.Now));

                Travel travel = new Travel(1, "John Doe", "Annandale", "VA", "US", "125745896", DateTime.Now.AddDays(5), "Planning");

                travel.Notes.Add(new Note("Follow up with John", "John Doe", DateTime.Now));
                travel.Notes.Add(new Note("Updated the amount", "John Doe", DateTime.Now));
                travel.Notes.Add(new Note("Denied", "John Doe", DateTime.Now));

                travel.Tags.Add(new Tag("Travel", "John Doe", DateTime.Now));
                travel.Tags.Add(new Tag("Out-Of-State", "John Doe", DateTime.Now));

                Training training = new Training(1, "Doe, John", "Microsoft", 10, "851452364", DateTime.Now, 250.00, "Planning");

                training.Notes.Add(new Note("Follow up with John", "John Doe", DateTime.Now));
                training.Notes.Add(new Note("Updated the amount", "John Doe", DateTime.Now));
                training.Notes.Add(new Note("Denied", "John Doe", DateTime.Now));

                training.Tags.Add(new Tag("Training", "John Doe", DateTime.Now));
                training.Tags.Add(new Tag("React Training", "John Doe", DateTime.Now));

                _context.Trainings.Add(training);
                _context.Travels.Add(travel);
                _context.Purchases.Add(purchase);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

            return Json("OK");
        }
    }
}
