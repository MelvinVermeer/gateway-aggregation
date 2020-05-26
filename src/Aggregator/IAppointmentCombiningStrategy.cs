using System.Collections.Generic;
using DTO;

namespace Aggregator
{
    public interface IAppointmentCombiningStrategy
    {
        /// <summary>
        /// the keys of the dictionary represent the type/providername
        /// </summary>
        IEnumerable<Appointment> Combine(Dictionary<string, IEnumerable<Appointment>> appointments);
    }
}