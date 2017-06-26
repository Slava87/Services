using System.Collections.Generic;
using System.Linq;
using Services.DataHandler;
using Services.Entity;
using Xunit;

namespace ServicesTests
{
    public class ServicesTestsXUnit
    {
        [Fact]
        public void LoadFromFileTest()
        {
            Global.InputPath = @"..\..\Data\services.xml";
            ServiceHandler serviceHdlr = new ServiceHandler();
            List<Service> services = serviceHdlr.DownloadServices();
            Assert.Equal("098-765-43-21", services.FirstOrDefault()?.PhoneNumber);
            //Assert.Equal("098-765-43-24", services.LastOrDefault()?.PhoneNumber);
        }
    }
}
