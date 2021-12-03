using System;
using System.Collections.Generic;
using System.Text;

namespace EDXSolutions.Models.Response
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
    }
}
