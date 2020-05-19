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

        // lists the supported appointment 'combining' strategies
        // the strategy can be selected in the config
        private static Dictionary<string, IAppointmentCombiningStrategy> _appointmentCombiningStrategies =
            new Dictionary<string, IAppointmentCombiningStrategy>()
            {
                { "concat", new ConcatAppointmentsStrategy() },
                { "merge", new MergeAppointmentsStrategy() },
            };

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

            var strategy = _appointmentCombiningStrategies[Config.AppointmentCombingStrategy];
            var aggregator = new AppointmentAggregator(strategy);

            return aggregator.GetAppointments(appointmentEndpoints);
        }
    }
}
