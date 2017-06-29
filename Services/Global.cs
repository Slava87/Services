using System.Collections.Generic;
using Services.Entity;

namespace Services.DataHandler
{
    public enum NoYes
    {
        No,
        Yes
    }

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
        Edit,
        Delete,
        Load,
        Export,
        Exit
    }

    public enum DataType
    {
        XML,
        JSON,
    }

    public enum DataSource
    {
        DefaultLocation,
        ChooseManually, 
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

        public static DataSource InputDataSource = DataSource.DefaultLocation;
        public static DataSource OutputDataSource = DataSource.DefaultLocation;
        public static DataType InputDataType = DataType.XML;
        public static DataType OutputDataType = DataType.XML;
        public static SortType SortType = SortType.Name;
        public static Commands Command = Commands.Show; 

        public static List<Service> Services = new List<Service>();
    }
}
