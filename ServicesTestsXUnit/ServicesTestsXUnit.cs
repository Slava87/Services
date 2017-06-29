using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DataHandler;
using Services.Entity;
using Xunit;

namespace ServicesTestsXUnit
{
    public class ServicesTestsXUnit
    {
        [Fact]
        public void LoadFromFileTest()
        {
            Global.InputPath = @"..\..\..\Services\Data\services.xml";
            Global.InputDataType = DataType.XML;
            ServiceHandler serviceHdlr = new ServiceHandler();
            List<Service> services = serviceHdlr.DownloadServices();
            //Assert.Equal("098-765-43-20", services.FirstOrDefault()?.PhoneNumber);
            //Assert.Equal("098-765-43-25", services.LastOrDefault()?.PhoneNumber);
        }
    }
}
