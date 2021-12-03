using System.Linq;
using System.Collections.Generic;

namespace EDXSolutions.PersonService
{
    public class Service1 : IPersonService
    {
        public void DeletePeople(int id)
        {
            PersonServiceContext _personServiceContext = new PersonServiceContext();
            var people = (from per in _personServiceContext.People
                          where per.Id == id
                          select per).FirstOrDefault();

            if (people != null)
            {
                _personServiceContext.People.Remove(people);
            }

            _personServiceContext.SaveChanges();
        }

        public IEnumerable<Person> GetPeople()
        {
            List<Person> peoples = new List<Person>();
            PersonServiceContext _personServiceContext = new PersonServiceContext();
            peoples = _personServiceContext.People.ToList();

            return peoples;
        }

        public void InsertPeople(Person person)
        {
            PersonServiceContext _personServiceContext = new PersonServiceContext();
            _personServiceContext.People.Add(person);

            _personServiceContext.SaveChanges();
        }

        public void UpdatePeople(Person person)
        {
            PersonServiceContext _personServiceContext = new PersonServiceContext();
            var people = (from per in _personServiceContext.People
                          where per.Id == person.Id
                          select per).FirstOrDefault();

            if (people != null) 
            {
                people.Nombre = person.Nombre;
                people.ApPaterno = person.ApPaterno;
                people.ApMaterno = person.ApMaterno;

                _personServiceContext.SaveChanges();
            }
        }
    }
}
