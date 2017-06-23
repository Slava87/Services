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
        public static void WriteConsole(List<Service> services)
        {
            foreach (Service customService in services)
            {
                Console.WriteLine("Service number " + (services.IndexOf(customService) + 1));
                Console.WriteLine("Service Name: " + customService.Name);   
                Console.WriteLine("Service Type: " + customService.ServiceType);   
                Console.WriteLine("Phone number: " + customService.PhoneNumber);   
                Console.WriteLine("Contact Name: " + customService.Responsible);
            }
        }

        public static void Display(string str)
        {
            Console.WriteLine(str);
        }
    }
}
