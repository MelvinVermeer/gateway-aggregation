using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Aggregator
{
    public class AppointmentAggregator
    {
        public IEnumerable<Appointment> GetAppointments(IEnumerable<IReturnAppointments> appointmentEndpoints)
        {
            // Simply concat the results of all the endpoints
            return appointmentEndpoints.SelectMany(x => x.Get());
        }

        // todo : how would we implement if we need to merge information of appointments.
    }
}
