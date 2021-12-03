using System.Data.Entity;

namespace EDXSolutions.PersonService
{
    public class PersonServiceContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonServiceContext() : base("PersonsDB")
        {

        }
    }
}