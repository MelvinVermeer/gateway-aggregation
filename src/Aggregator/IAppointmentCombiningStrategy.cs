using System.Collections.Generic;
using DTO;

namespace Aggregator
{
    public interface IAppointmentCombiningStrategy
    {
        IEnumerable<Appointment> Combine(IEnumerable<Appointment> appointments);
    }
}