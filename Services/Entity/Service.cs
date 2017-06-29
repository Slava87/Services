using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Services.DataHandler;

namespace Services.Entity
{

    public class Service
    {
        public int Id { get; set; } 
        public string ServiceName { get; set; }   
        public ServiceType ServiceType { get; set; }  

        public int PersonId { get; set; }

        [XmlIgnore]
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }  
    }

    public class Person
    { 
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; } 
    }


    public class Serialization
    {
         public List<Service> Services { get; set; } 
         public List<Person> Persons { get; set; } 
    }
}
