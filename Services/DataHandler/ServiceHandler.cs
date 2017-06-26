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
            return Global.Services;
        }

        public void AddServiceToList(Service newService)
        {
            Global.Services.Add(newService);
        }

        public List<Service> GetListSortedBy(SortType myEnum)
        {
            List<Service> list = new List<Service>();
            switch (myEnum)
            {
                case SortType.Name:
                    list = Global.Services.OrderBy(x => x.Name).ToList();
                    break;
                case SortType.Type:
                    list = Global.Services.OrderByDescending(x => x.ServiceType).ToList();
                    break;
            }
            return list;
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

        public Service CreateService()
        {
            Service newCustomService = new Service();
            OutputService.Display("Enter Service Name: ");
            newCustomService.Name = StringValidation.ValidateLength(MAX_LENGTH_SERVICE);

            OutputService.Display("Enter Service Type (choose number): ");

            newCustomService.ServiceType = (ServiceType)InputService.GetValidatedUserChoice(new ServiceType());

            OutputService.Display("Enter Phone Number: ");
            newCustomService.PhoneNumber = StringValidation.ValidatePhone();

            OutputService.Display("Enter Responsible Person Name: ");
            newCustomService.Responsible = StringValidation.ValidateLength(MAX_LENGTH_RESPONSIBLE); ;

            return newCustomService;
        }




    }
}
