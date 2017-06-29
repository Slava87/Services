using System;
using System.Collections.Generic;
using System.IO;
using Services.Entity;
using Services.DataHandler;

namespace Services.IOServices
{
    public class InputService
    {
        //public Action[] Actions = { Show, Sort, AddService, Load, Export, Exit };



        public static void GetDataSource()
        {
            Global.InputDataSource = (DataSource)GetValidatedUserChoice(new DataSource());

            ServiceHandler serviceHdlr;
            switch (Global.InputDataSource)
            {
                case DataSource.DefaultLocation:
                    Global.InputPath = @"..\..\Data\services.xml";
                    break;
                case DataSource.ChooseManually:
                    GetInputPath();
                    break;
            }
        }

        private static void GetInputPath()
        {
            OutputService.DisplayConsole(@"Please enter file location (example c:\myFile.txt):");
            while (true)
            {
                string path = ReadDataFromConsole();
                if (File.Exists(path))
                {
                    Global.InputPath = path;
                    break;
                }
                else
                    OutputService.DisplayConsole(@"Your path is not correct");
            }
        }

        public static void GetDataType()
        {
            Global.InputDataType = (DataType)GetValidatedUserChoice(new DataType());
        }

        public static void GetSortType()
        {
            Global.SortType = (SortType)GetValidatedUserChoice(new SortType());
        }

        public static Commands GetCommand()
        {
            return (Commands)GetValidatedUserChoice(new Commands());
        }

        public static int GetValidatedUserChoice(Enum inputEnum)
        {
            OutputService.DisplayConsole("Choose option: ");

            int i = 0;
            foreach (var item in Enum.GetValues(inputEnum.GetType()))
            {
                OutputService.DisplayConsole("   " + i + " - " + item);
                i++;
            }

            int index = -1;
            bool parseResult = false;
            while (index < 0 || index > i - 1 || !parseResult)
            {
                string input = ReadDataFromConsole();
                parseResult = Int32.TryParse(input, out index);
                if (index < 0 || index >= i || !parseResult)

                    OutputService.DisplayConsole("Error, please enter correct number");
            }

            return index;
        }

        public static string ReadDataFromConsole()
        {
            return Console.ReadLine();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                OutputService.DisplayConsole("");
                OutputService.DisplayConsole("Please enter command:");
                Commands command = GetCommand();
                //Actions[(int)Global.Command]();
                switch (command)
                {
                    case Commands.Show:
                        Show();
                        break;
                    case Commands.Sort:
                        Sort();
                        break;
                    case Commands.Add:
                        AddService();
                        break;
                    case Commands.Load:
                        Load();
                        break;
                    case Commands.Export:
                        Export();
                        break;
                    case Commands.Exit:
                        Exit();
                        break;
                    case Commands.Edit:
                        Edit();
                        break;
                    case Commands.Delete:
                        Delete();
                        break;
                }
                ReadDataFromConsole();
            }
        }



        #region Actions

        private void Delete()
        {
            OutputService.DisplayConsole("Enter Id of Service:");
            string choice = ReadDataFromConsole();
            int i = StringValidation.ValidatePositiveInt(choice);
            DBService dbService = new DBService();
            if (i > 0 && dbService.ServiceExist(i))
            {
               
                dbService.RemoveService(i);
            }
            else
            {
                OutputService.DisplayConsole("Id is not valid");
            }
            dbService.Dispose();
        }

        private void Edit()
        {
            OutputService.DisplayConsole("Enter Id of Service:");
            string choice = ReadDataFromConsole();
            int i = StringValidation.ValidatePositiveInt(choice);
            DBService dbService = new DBService();
            if (i > 0 && dbService.ServiceExist(i))
            {
                OutputService.DisplayConsole("Your service to edit:");
                OutputService.DisplayConsole(dbService.GetService(i));
                ServiceHandler serviceHandler = new ServiceHandler();
                Service newService = serviceHandler.CreateServiceFromConsole();
                newService.Id = i;

                dbService.Update(newService);
            }
            else
            {
                OutputService.DisplayConsole("Id is not valid");
            }
            dbService.Dispose();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void Load()
        {
            GetDataSource();
            GetDataType();
            List<Service> tempServices = new List<Service>();

            ServiceHandler sh = new ServiceHandler();
            tempServices = sh.DownloadServices();

            DBService dbService = new DBService();
            dbService.Create(tempServices);
            dbService.Dispose();
        }

        private void Sort()
        {
            SortType sortType = (SortType)GetValidatedUserChoice(new SortType());
            ServiceHandler sH = new ServiceHandler();
            List<Service> list = sH.GetListSortedBy(sortType);
            OutputService.DisplayConsole(list);
            OutputService.DisplayConsole("");
        }

        private void Show()
        {
            DBService dbService = new DBService();
            OutputService.DisplayConsole(dbService.GetAllServices());
            dbService.Dispose();
        }

        private void Export()
        {
            Global.OutputDataSource = (DataSource)GetValidatedUserChoice(new DataSource());

            if (Global.OutputDataSource != DataSource.DefaultLocation)
            {
                Global.OutputDataType = (DataType)GetValidatedUserChoice(new DataType());

                OutputService.DisplayConsole(@"Please enter file location (example c:\myFile.txt):");
                while (true)
                {
                    Global.OutputPath = ReadDataFromConsole();
                    break;
                }
            }
            else
            {
                Global.OutputPath = @"..\..\Data\services.xml";
            }


            DBService dbService = new DBService();
            List<Service> services = dbService.GetAllServices();
            dbService.Dispose();

            switch (Global.OutputDataType)
            {
                case DataType.JSON:
                    JsonService jsonWriteService = new JsonService();
                    jsonWriteService.WriteServiceToJsonFile(services);
                    break;
                case DataType.XML:
                    XmlService xmlWriteService = new XmlService();
                    xmlWriteService.WriteServicesToXmlFile();
                    break;
            }
        }

        private void AddService()
        {
            ServiceHandler serviceHandler = new ServiceHandler();
            Service newService = serviceHandler.CreateServiceFromConsole();
            serviceHandler.AddServiceToList(newService);
        }

        #endregion
    }
}
