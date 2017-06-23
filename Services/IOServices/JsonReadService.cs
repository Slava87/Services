using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Services.Model;

namespace Services.ReadWriteServices
{
    public class JsonReadService
    {
        public List<Service> ReadJsonFromFile()
        {
            List<Service> items = new List<Service>();
            try
            {
                using (StreamReader r = new StreamReader(Global.InputPath))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Service>>(json);
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }
            return items;
        }  
    }
}
