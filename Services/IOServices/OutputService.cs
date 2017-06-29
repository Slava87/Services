using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Services.Entity;

namespace Services.IOServices
{
    public static class OutputService
    {
        public static void DisplayConsole(List<Service> services)
        {
            foreach (Service customService in services)
            {
                Console.WriteLine("Service Id " + customService.Id);
                Console.WriteLine("Service Name: " + customService.ServiceName);
                Console.WriteLine("Service Type: " + customService.ServiceType);
                Console.WriteLine("Phone number: " + customService.Person.PhoneNumber);
                Console.WriteLine("Contact Name: " + customService.Person.PersonName);
            }
        }

        public static void DisplayConsole(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("Service Id " + person.Id);
                Console.WriteLine("Service Name: " + person.PersonName);
                Console.WriteLine("Phone number: " + person.PhoneNumber);    
            }
        }

        public static void DisplayConsole(Service service)
        {
            Console.WriteLine("Service Id " + service.Id);
            Console.WriteLine("Service Name: " + service.ServiceName);
            Console.WriteLine("Service Type: " + service.ServiceType);
            Console.WriteLine("Phone number: " + service.Person.PhoneNumber);
            Console.WriteLine("Contact Name: " + service.Person.PersonName);
        }

        public static void DisplayConsole(string str)
        {
            Console.WriteLine(str);
        }
    }
}
