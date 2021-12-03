using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EDXSolutions.Client.Models;
using EDXSolutions.PersonClient.PersonServiceClient;
using EDXSolutions.Models.Request;
using EDXSolutions.Models.Response;

namespace EDXSolutions.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonServiceClient _personServiceClient;

        public HomeController(ILogger<HomeController> logger, IPersonServiceClient personServiceClient)
        {
            _logger = logger;
            _personServiceClient = personServiceClient;
        }

        public async Task<IActionResult> Index()
        {
            var listPersons = await _personServiceClient.GetPeoples();
            ViewData["ListPersons"] = listPersons.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task Delete(int id) 
        {
            await _personServiceClient.DeletePeople(id);
        }

        [HttpPost]
        public async Task Insert(People person)
        {
            await _personServiceClient.InsertPeople(person);
        }

        [HttpGet]
        public async Task<PersonResponse> GetPeopleById(int id) 
        {
            var listPersons = await _personServiceClient.GetPeoples();
            var result = listPersons.ToList().Where(lp => lp.Id == id).ToList().FirstOrDefault();

            return result;
        }

        [HttpPost]
        public async Task Update(People person)
        {
            await _personServiceClient.UpdatePeople(person);
        }
    }
}
