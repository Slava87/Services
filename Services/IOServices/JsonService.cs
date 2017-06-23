using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Services.DataHandler;
using Services.Entity;

namespace Services.IOServices
{
    public class JsonService
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
                OutputService.Display("Error: " + ex.Message);
                InputService.ReadData();
            }
            return items;
        }

        public void WriteServiceToJsonFile(List<Service> servicesList)
        {
            string json = JsonConvert.SerializeObject(servicesList);
            File.WriteAllText(Global.OutputPath, json, Encoding.UTF8);
        }
    }
}
