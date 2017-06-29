using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Services.DataHandler;
using Services.Entity;

namespace Services.IOServices
{
    public class XmlService
    {
        public List<Service> ReadXmlFromFile()
        {
            string path = Global.InputPath;
            List<Service> services = new List<Service>();
            try
            {
                if (!File.Exists(path))
                    using (File.Create(path))
                    {
                    }

                using (StreamReader stream = new StreamReader(path))
                {
                    services = (List<Service>)new XmlSerializer(typeof(List<Service>)).Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                OutputService.DisplayConsole("Error: " + ex.InnerException);
                InputService.ReadDataFromConsole();
            }
            return services;
        }

        public void WriteServicesToXmlFile()
        {
            DBService dbService = new DBService();
            Serialization serialization = new Serialization
            {
                Services = dbService.GetAllServices(),
                Persons = dbService.GetAllPersons()
            };
            dbService.Dispose();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Service>));
            List<Service> test = new List<Service>();

            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xmlSerializer.Serialize(writer, test);
                    xml = sw.ToString();
                    File.WriteAllText(Global.OutputPath, xml, Encoding.UTF8);
                }
            }
        }
    }
}
