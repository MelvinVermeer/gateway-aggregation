using System.Collections.Generic;
using System.Linq;
using DTO;

namespace Aggregator
{
    public class MergeAppointmentsStrategy : IAppointmentCombiningStrategy
    {
        public IEnumerable<Appointment> Combine(IEnumerable<Appointment> appointments)
        {
            // In a real life scenario this method would contain object merging logic
            return appointments.GroupBy(x => x.Id).Select(group => group.Last());
        }
    }
}
