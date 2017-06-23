using Services.IOServices;

namespace Services
{
    

    

    public class Program   
    {                      
       public static void Main(string[] args)
        {
            InputService consoleInputService = new InputService(); 
            consoleInputService.Run();  
        }                    
    }
}
