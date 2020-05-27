using Gateway;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var entityTypes = GatewayEndpoint.GetAvailableEntityTypes();

            Console.WriteLine("I Support the following entity types");
            foreach (var entityType in entityTypes)
            {
                Console.WriteLine(entityType);
            }

            if (GatewayEndpoint.CanReturnEntityOfType("appointment")) 
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
