using System.Collections.Generic;
using Services.Entity;

namespace Services.DataHandler
{
    public enum SortType
    {
        Name,
        Type
    }

    public enum Commands
    {
        Show,
        Sort,
        Add,
        Export,
        Exit
    }

    public enum DataType
    {
        JSON,
        XML
    }

    public enum DataSource
    {
        DefaultLocation,
        ChooseManually
    }

    public enum ServiceType
    {
        Education,
        Commerce,
        Service,
        Other
    }

    public static class Global
    {
        //public static string PathToXmlDefault = @"..\..\Data\services.xml";
        public static string InputPath = @"..\..\Data\services.xml";
        public static string OutputPath = @"..\..\Data\services.xml";

        public static DataSource DataSource = DataSource.DefaultLocation;
        public static DataType InputDataType = DataType.XML;
        public static DataType OutputDataType = DataType.XML;
        public static SortType SortType = SortType.Name;
        public static Commands Command = Commands.Show; 

        public static List<Service> Services = new List<Service>();
    }
}
