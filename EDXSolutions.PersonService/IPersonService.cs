using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EDXSolutions.PersonService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPersonService
    {

        [OperationContract]
        IEnumerable<Person> GetPeople();

        [OperationContract]
        void InsertPeople(Person person);
        [OperationContract]
        void UpdatePeople(Person person);
        [OperationContract]
        void DeletePeople(int id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Person
    {
        [Key]
        [Required]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string Nombre { get; set; }
        [Required]
        [DataMember]
        public string ApPaterno { get; set; }
        [Required]
        [DataMember]
        public string ApMaterno { get; set; }
    }
}
