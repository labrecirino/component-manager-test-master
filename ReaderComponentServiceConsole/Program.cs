using System;
using System.ServiceModel;
using ReaderComponentService;


namespace ReaderComponentServiceConsole
{
    class Program
    {
        /// <summary>
        /// Comments about the exercise: Create a self hosted WCF service.
        /// Use net tcp binding for the service. (See App.config configuration)
        /// </summary
        static void Main(string[] args)
        {       

            ServiceHost svc = null;
            try
            {

                svc = new ServiceHost(typeof(ComponentManagerServer));
                svc.Open();
                
            }
            catch (Exception exception)
            {
                svc = null;
                Console.WriteLine("An error ocurred while starting the service: \n\n Error Description [" + exception.Message + "]");
            }

            if (svc != null)
            {
                Console.WriteLine("\n\n ReaderComponentServiceConsole is up and Running at:\nnet.tcp://localhost:8733/ReaderComponentService");
                Console.WriteLine("\nPress any key to stop the service...");

                Console.ReadKey();
                svc.Close();
                svc = null;
            }

        }
    }
}
