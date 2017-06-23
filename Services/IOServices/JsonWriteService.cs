using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Services.Model;

namespace Services.ReadWriteServices
{
    public class JsonWriteService
    {
        public void WriteServiceToJsonFile(List<Service> servicesList)
        {
            string json = JsonConvert.SerializeObject(servicesList);
            File.WriteAllText(Global.InputPath, json, Encoding.UTF32);  
        }
    }
}
