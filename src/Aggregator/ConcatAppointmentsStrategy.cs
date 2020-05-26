using System.Collections.Generic;
using System.Linq;
using DTO;

namespace Aggregator
{
    public class ConcatAppointmentsStrategy : IAppointmentCombiningStrategy
    {
        public IEnumerable<Appointment> Combine(Dictionary<string, IEnumerable<Appointment>> appointments)
        {
            // In a real life situation throw an exception if the Id is not unique
            return appointments.SelectMany(x => x.Value);
        }
    }
}
