using Gateway;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var features = GatewayEndpoint.GetAvailableFeatures();

            Console.WriteLine("I Support the following features");
            foreach (var feature in features)
            {
                Console.WriteLine(feature);
            }

            if (GatewayEndpoint.ImplementsFeature("appointments")) 
            {
                var appointments = GatewayEndpoint.GetAppointments();
                Console.WriteLine("I know the following appointments");

                foreach (var appointment in appointments)
                {
                    Console.WriteLine(appointment.Title);
                }
            }

        }
    }
}
