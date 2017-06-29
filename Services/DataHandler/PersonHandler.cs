using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Entity;
using Services.IOServices;

namespace Services.DataHandler
{
    public class PersonHandler
    {
        public const int MAX_LENGTH_RESPONSIBLE = 20;
        public static int GetPersonId()
        {
            Person person = new Person();
            int id = -1;
            OutputService.DisplayConsole("Are you registered");
            NoYes input = (NoYes)InputService.GetValidatedUserChoice(new NoYes());
            DBService dbService = new DBService();
            switch (input)
            {
                case NoYes.No:

                    OutputService.DisplayConsole("Write your name");
                    person.PersonName = StringValidation.ValidateLength(MAX_LENGTH_RESPONSIBLE);
                    OutputService.DisplayConsole("Enter your phone number (ex. 0991231212, 099-123-12-12, +1-099-123-12-12)");
                    person.PhoneNumber = StringValidation.ValidatePhone();   
                    id = dbService.CreatePerson(person);
                    dbService.Dispose();
                    return id;

                case NoYes.Yes:     
                    while (dbService.PersonExist(person) == null)
                    {
                        OutputService.DisplayConsole("Write your name");
                        person.PersonName = StringValidation.ValidateLength(MAX_LENGTH_RESPONSIBLE);
                        OutputService.DisplayConsole("Enter your phone number (ex. 0991231212, 099-123-12-12, +1-099-123-12-12)");
                        person.PhoneNumber = StringValidation.ValidatePhone();
                        id = dbService.PersonExist(person).Id;
                    }
                    return id;
            }
            return -1;


        }
    }
}
