using CsvHelper;
using EnnakkoTehtävä2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnnakkoTehtävä2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EnergiaContext _context;
        static readonly HttpClient client = new HttpClient();

        public IEnumerable<EnergiankulutusData> Datat { get; set; }

        public HomeController(ILogger<HomeController> logger, EnergiaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {        
            return View();
        }

        // Jos haluaisin muokata päivämääräväliä: 
            // Tekisin uuden modelin jossa on vaikka from ja to kentät ja näiden datatype olisi date.
            // Viewiin laittaisin input-kentät päivämäärän valintaa varten.
            // Controllerissa käyttäisin UriBuilderia kasatakseni halutun haun.         
        
        // Jos haluaisin datan viikottaisena
            // Päivämääräväliä muokkaamalla voidaan hakea vain viikon datat.

        // Jos haluaisin hakea dataa toisesta palvelusta
            // Tekisin toisen funktion jossa data haetaan eri kyselyllä.
        public async Task<IActionResult> Hae()
        {
            // Pyydetään dataa
            HttpResponseMessage response = await client.GetAsync("https://helsinki-openapi.nuuka.cloud/api/v1.0/EnergyData/Daily/ListByProperty?Record=LocationName&SearchString=1000%20Hakaniemen%20kauppahalli&ReportingGroup=Electricity&StartTime=2019-01-01&EndTime=2019-12-31");
            response.EnsureSuccessStatusCode();  
            
            // Parsitaan data
            string responseBody = await response.Content.ReadAsStringAsync();
            Datat = JsonConvert.DeserializeObject<List<EnergiankulutusData>>(responseBody);

            Console.WriteLine(responseBody);

            // Luodaan Ennakkotehtava-nimiseen kansioon energiadata + päivämäärä-niminen csv-tiedosto.
            var csvPath = Path.Combine($"C:\\Ennakkotehtava\\energiadata-{DateTime.Now}.csv");
            
            using (var writer = new StreamWriter(csvPath)) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                               
            {
               csv.WriteRecords(Datat);
            }

            // Palautetaan data käyttöliittymälle
            return View("EnergiaData", Datat.OrderBy(m => m.Timestamp));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
