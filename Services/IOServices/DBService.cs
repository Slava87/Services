using System.Collections.Generic;
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

        public void Save(List<Service> services)
        {  
            foreach (Service service in services)
                if (!db.Services.ToList().Any(x => x.ServiceType == service.ServiceType
                                               && x.Name == service.Name
                                               && x.PhoneNumber == service.PhoneNumber
                                               && x.Responsible == service.Responsible))
                    db.Services.Add(service);
            db.SaveChanges(); 
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
