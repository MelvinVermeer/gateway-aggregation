using Aggregator;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway
{
    public static class GatewayEndpoint
    {
        public static IEnumerable<string> GetAvailableFeatures()
        {
            return Config.Features.Select(x => x.Name);
        }

        public static bool ImplementsFeature(string feature)
        {
            return Config.Features.Any(x => x.Name == feature);
        }

        public static IEnumerable<Appointment> GetAppointments()
        {
            if (!ImplementsFeature("appointments"))
            {
                throw new NotImplementedException();
            }

            IEnumerable<IReturnAppointments> appointmentEndpoints = Config.Features
                .Where(x => x.Name == "appointments")
                .SelectMany(x => x.Endpoints)
                .Select(x => x as IReturnAppointments);

            AppointmentAggregator aggregator = new AppointmentAggregator();

            return aggregator.GetAppointments(appointmentEndpoints);
        }
    }
}
