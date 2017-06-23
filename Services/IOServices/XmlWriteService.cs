using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Services.Model;

namespace Services.ReadWriteServices
{
    public class XmlWriteService
    {
        public void WriteServicesToXmlFile(List<Service> servicesList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Service>));
            
            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xmlSerializer.Serialize(writer, servicesList);
                    xml = sw.ToString();
                    File.WriteAllText(Global.InputPath, xml, Encoding.UTF32);  //todo expert file path
                }
            }     
        }
    }
}
