using Aggregator;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway
{
    public static class GatewayEndpoint
    {
        public static IEnumerable<string> GetAvailableEntityTypes()
        {
            return Config.DataProviders.SelectMany(x => x.UseForEntityTypes).Distinct();
        }

        public static bool CanReturnEntityOfType(string entityType)
        {
            return Config.DataProviders.Any(x => x.UseForEntityTypes.Contains(entityType));
        }

        public static IEnumerable<Appointment> GetAppointments() // http endpoint
        {
            if (!CanReturnEntityOfType("appointment"))
            {
                throw new NotImplementedException();
            }

            var appointmentEndpoints = EndpointFactory.CreateEndpoints<IReturnAppointments>("appointment");
            var strategy = StrategyFactory.CreateStrategy<IAppointmentCombiningStrategy>(Config.UseStrategies);

            var aggregator = new AppointmentAggregator(strategy);
            return aggregator.GetAppointments(appointmentEndpoints);
        }
    }
}
