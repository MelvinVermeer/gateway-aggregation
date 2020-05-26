using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Aggregator
{
    public class AppointmentAggregator
    {
        private IAppointmentCombiningStrategy _strategy;

        public AppointmentAggregator(IAppointmentCombiningStrategy strategy)
        {
            _strategy = strategy;
        }

        public AppointmentAggregator()
        {
            // default simple concat strategy
            _strategy = new ConcatAppointmentsStrategy();
        }

        public IEnumerable<Appointment> GetAppointments(IEnumerable<IReturnAppointments> endpoints)
        {
            var appointments = endpoints.ToDictionary(x => x.GetType().ToString(), x => x.Get());

            return _strategy.Combine(appointments);
        }
    }
}
