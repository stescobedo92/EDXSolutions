using EDXSolutions.Models.Request;
using EDXSolutions.Models.Response;
using Microsoft.Extensions.Logging;
using PersonService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDXSolutions.PersonClient.PersonServiceClient
{
    public class PersonServiceClient : IPersonServiceClient
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonServiceClient> _logger;

        public PersonServiceClient(IPersonService personService, ILogger<PersonServiceClient> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        public async Task DeletePeople(int idPerson)
        {
            try
            {     
                await _personService.DeletePeopleAsync(idPerson);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
            }
        }

        public async Task<List<PersonResponse>> GetPeoples()
        {
            try
            {
                var peoples = await _personService.GetPeopleAsync();
                List<PersonResponse> personResponse = new List<PersonResponse>();

                foreach (var person in peoples)
                {
                    var translateResult = new PersonResponse()
                    {
                        Id = person.Id,
                        Nombre = person.Nombre,
                        ApMaterno = person.ApMaterno,
                        ApPaterno = person.ApPaterno
                    };

                    personResponse.Add(translateResult);
                }

                return personResponse;
            }
            catch (Exception error) 
            {
                _logger.LogError(error.Message);
            }

            return null;
        }

        public async Task InsertPeople(People person)
        {
            try
            {
                Person personTranslate = new Person();
                personTranslate.Nombre = person.Nombre;
                personTranslate.ApPaterno = person.ApPaterno;
                personTranslate.ApMaterno = person.ApMaterno;

                await _personService.InsertPeopleAsync(personTranslate);
            }
            catch (Exception error) 
            {
                _logger.LogError(error.Message);
            }
        }

        public async Task UpdatePeople(People person)
        {
            try
            {
                Person personTranslate = new Person();
                personTranslate.Nombre = person.Nombre;
                personTranslate.ApPaterno = person.ApPaterno;
                personTranslate.ApMaterno = person.ApMaterno;

                await _personService.UpdatePeopleAsync(personTranslate);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
            }
        }
    }
}
