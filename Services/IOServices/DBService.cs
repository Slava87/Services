using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Services.DataHandler;
using Services.Entity;

namespace Services.IOServices
{
    public class DBService
    {
        private ApplicationDbContext db;
        public DBService()
        {
            db = new ApplicationDbContext();
        }

        public List<Service> GetAllServices()
        {
            return db.Services.ToList();
        }

        public List<Person> GetAllPersons()
        {
            return db.Persons.ToList();
        }

        public Service GetService(int id)
        {
            return db.Services.FirstOrDefault(x => x.Id == id);
        }

        public Person GetPerson(int id)
        {
            return db.Persons.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Service service)
        {
            Service updateService = db.Services.FirstOrDefault(x => x.Id == service.Id);
            if (updateService != null)
             //updateService = service;
            {
                updateService.ServiceType = service.ServiceType;
                updateService.ServiceName = service.ServiceName; 
                updateService.PersonId = service.PersonId;  
            }
            //db.Services.AddOrUpdate(service);
            db.SaveChanges();
        }

        public bool ServiceExist(int id)
        {
            return db.Services.FirstOrDefault(x => x.Id == id) != null;
        }

        public Person PersonExist(Person person)
        {
           return db.Persons.FirstOrDefault(x => x.PersonName == person.PersonName 
                                               && x.PhoneNumber == person.PhoneNumber);
        }

        public void RemoveService(int id)
        {
            Service removeService = db.Services.FirstOrDefault(x => x.Id == id);
            if (removeService != null)
            {
                db.Services.Remove(removeService);
                OutputService.DisplayConsole("Service was successfully removed");
            }                
            else
            {
                OutputService.DisplayConsole("There is no element with such Id. Please try again.");
            }
            db.SaveChanges();
        }  


        public void Create(List<Service> services)
        {
            foreach (Service service in services)
                if (!db.Services.ToList().Any(x => x.ServiceType == service.ServiceType
                                               && x.ServiceName == service.ServiceName  
                                               && x.PersonId == service.PersonId))
                    db.Services.Add(service);
            db.SaveChanges();
        }

        public void CreateService(Service service)
        {
            if (!db.Services.ToList().Any(x => x.ServiceType == service.ServiceType
                                                 && x.ServiceName == service.ServiceName
                                                 && x.PersonId == service.PersonId))
                db.Services.Add(service);

            db.SaveChanges();
        }

        public int CreatePerson(Person person)
        {
            if (!db.Persons.ToList().Any(x => x.PersonName == person.PersonName
                                                 && x.PhoneNumber == person.PhoneNumber))
                db.Persons.Add(person);

            db.SaveChanges();
            return person.Id;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
