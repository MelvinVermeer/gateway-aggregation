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
            // empty constructor to express the fact that combining strategy is optional
        }

        public IEnumerable<Appointment> GetAppointments(IEnumerable<IReturnAppointments> endpoints)
        {
            var appointments = endpoints.SelectMany(x => x.Get());

            if (_strategy == null)
            {
                return appointments;
            }

            return _strategy.Combine(appointments);
        }
    }
}
