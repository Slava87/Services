using Services.DataHandler;

namespace Services.Entity
{ 
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public string PhoneNumber { get; set; }
        public string Responsible { get; set; }           
    }
}
