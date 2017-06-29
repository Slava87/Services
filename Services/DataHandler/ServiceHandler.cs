using System;
using System.Collections.Generic;
using System.Linq;
using Services.IOServices;
using Services.Entity;

namespace Services.DataHandler
{
    public class ServiceHandler
    {
        public const int MAX_LENGTH_SERVICE = 200;
        public const int MAX_LENGTH_RESPONSIBLE = 20;

        public List<Service> GetAllServices()
        {
            List<Service> list = new List<Service>();
            DBService dbService = new DBService();
            list = dbService.GetAllServices();
            dbService.Dispose();
            return list;
        }

        public void AddServiceToList(Service newService)
        {
            DBService dbService = new DBService();
            dbService.CreateService(newService);
            dbService.Dispose();
        }

        public List<Service> GetListSortedBy(SortType myEnum)
        {
            List<Service> list = new List<Service>();
            DBService dbService = new DBService();
            list = dbService.GetAllServices();

            switch (myEnum)
            {
                case SortType.Name:
                    return list.OrderBy(x => x.ServiceName).ToList();
                case SortType.Type:
                    return list.OrderByDescending(x => x.ServiceType).ToList();
            }
            return new List<Service>();
        }

        List<Service> _services = new List<Service>();


        public List<Service> DownloadServices()
        {
            switch (Global.InputDataType)
            {
                case DataType.JSON:
                    JsonService jsonReadService = new JsonService();
                    _services = jsonReadService.ReadJsonFromFile();
                    break;
                case DataType.XML:
                    XmlService xmlReadService = new XmlService();
                    _services = xmlReadService.ReadXmlFromFile();
                    break;
            }
            return _services;
        }


        public Service CreateServiceFromConsole()
        {
            Service newCustomService = new Service();
            OutputService.DisplayConsole("Enter Service Name: ");
            newCustomService.ServiceName = StringValidation.ValidateLength(MAX_LENGTH_SERVICE);

            OutputService.DisplayConsole("Enter Service Type (choose number): "); 
            newCustomService.ServiceType = (ServiceType)InputService.GetValidatedUserChoice(new ServiceType());
            newCustomService.PersonId = PersonHandler.GetPersonId(); 

            return newCustomService;
        }




    }
}
