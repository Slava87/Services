using System;
using System.Collections.Generic;
using System.IO;
using Services.Entity;
using Services.DataHandler;

namespace Services.IOServices
{
    public class InputService
    {
        public Action[] Actions = { Show, Sort, AddService, Export, Exit };

        public void GetDataSource()
        {
            Global.InputDataSource = (DataSource)GetValidatedUserChoice(new DataSource());

            ServiceHandler serviceHdlr;
            switch (Global.InputDataSource)
            {
                case DataSource.DefaultLocation:
                    Global.InputPath = @"..\..\Data\services.xml";
                    serviceHdlr = new ServiceHandler();
                    Global.Services.AddRange(serviceHdlr.DownloadServices());
                    break;
                case DataSource.ChooseManually:
                    GetInputPath();
                    serviceHdlr = new ServiceHandler();
                    Global.Services.AddRange(serviceHdlr.DownloadServices());
                    break;
                case DataSource.Database:
                    DBService dbService = new DBService();
                    Global.Services.AddRange(dbService.GetAllServices());
                    dbService.Dispose();
                    break;
            }
        }

        private void GetInputPath()
        {
            OutputService.Display(@"Please enter file location (example c:\myFile.txt):");
            while (true)
            {
                string path = ReadData();
                if (File.Exists(path))
                {
                    Global.InputPath = path;
                    break;
                }
                else
                    OutputService.Display(@"Your path is not correct");
            }
        }

        public void GetDataType()
        {
            Global.InputDataType = (DataType)GetValidatedUserChoice(new DataType());
        }

        public void GetSortType()
        {
            Global.SortType = (SortType)GetValidatedUserChoice(new SortType());
        }

        public void GetCommand()
        {
            Global.Command = (Commands)GetValidatedUserChoice(new Commands());
        }

        public static int GetValidatedUserChoice(Enum inputEnum)
        {
            OutputService.Display("Choose option: ");

            int i = 0;
            foreach (var item in Enum.GetValues(inputEnum.GetType()))
            {
                OutputService.Display("   " + i + " - " + item);
                i++;
            }

            int index = -1;
            bool parseResult = false;
            while (index < 0 || index > i - 1 || !parseResult)
            {
                string input = ReadData();
                parseResult = Int32.TryParse(input, out index);
                if (index < 0 || index >= i || !parseResult)

                    OutputService.Display("Error, please enter correct number");
            }

            return index;
        }

        public static string ReadData()
        {
            return Console.ReadLine();
        }

        public void Run()
        {
            GetDataSource();

            if (Global.InputDataSource != DataSource.Database)
                GetDataType();

            while (true)
            {
                Console.Clear();
                OutputService.Display("");
                OutputService.Display("Please enter command:");
                GetCommand();
                Actions[(int)Global.Command]();
                ReadData();
            }
        }

        #region Actions

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void Sort()
        {
            SortType sortType = (SortType)GetValidatedUserChoice(new SortType());
            ServiceHandler sH = new ServiceHandler();
            List<Service> list = sH.GetListSortedBy(sortType);
            OutputService.WriteConsole(list);
            OutputService.Display("");
        }

        private static void Show()
        {
            OutputService.WriteConsole(Global.Services);
        }

        private static void Export()
        {
            Global.OutputDataSource = (DataSource)GetValidatedUserChoice(new DataSource());

            if (Global.OutputDataSource != DataSource.Database)
                Global.OutputDataType = (DataType)GetValidatedUserChoice(new DataType());


            if (Global.OutputDataSource == DataSource.ChooseManually ||
                Global.OutputDataSource == DataSource.DefaultLocation)
            {

                OutputService.Display(@"Please enter file location (example c:\myFile.txt):");
                while (true)
                {
                    string path = ReadData();
                    Global.OutputPath = path;
                    break;
                }


                switch (Global.OutputDataType)
                {
                    case DataType.JSON:
                        JsonService jsonWriteService = new JsonService();
                        jsonWriteService.WriteServiceToJsonFile(Global.Services);
                        break;
                    case DataType.XML:
                        XmlService xmlWriteService = new XmlService();
                        xmlWriteService.WriteServicesToXmlFile(Global.Services);
                        break;
                }
            }
            if (Global.OutputDataSource == DataSource.Database)
            {
                DBService dbService = new DBService();
                dbService.Save(Global.Services);
                dbService.Dispose();
            }
        }

        private static void AddService()
        {
            ServiceHandler serviceHandler = new ServiceHandler();
            Service newService = serviceHandler.CreateService();
            serviceHandler.AddServiceToList(newService);
        }

        #endregion
    }
}
