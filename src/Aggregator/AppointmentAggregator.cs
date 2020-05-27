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
            _strategy = strategy ?? new ConcatAppointmentsStrategy(); // if null, use default strategy
        }

        public AppointmentAggregator() : this(null) { }

        public IEnumerable<Appointment> GetAppointments(IEnumerable<IReturnAppointments> endpoints)
        {
            var appointments = endpoints.ToDictionary(x => x.GetType().ToString(), x => x.Get());

            return _strategy.Combine(appointments);
        }
    }
}
