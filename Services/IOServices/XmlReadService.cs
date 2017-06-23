using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Services.Model;

namespace Services.ReadWriteServices
{
    public class XmlReadService
    {
        
        public List<Service> ReadXmlFromFile ()
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
                    services = (List<Service>) new XmlSerializer(typeof (List<Service>)).Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }
            return services;
        }
    }
}
