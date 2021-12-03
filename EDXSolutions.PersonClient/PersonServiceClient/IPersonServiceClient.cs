using EDXSolutions.Models.Request;
using EDXSolutions.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDXSolutions.PersonClient.PersonServiceClient
{
    public interface IPersonServiceClient
    {
        Task InsertPeople(People person);
        Task UpdatePeople(People person);
        Task DeletePeople(int idPerson);
        Task<List<PersonResponse>> GetPeoples();
    }
}
