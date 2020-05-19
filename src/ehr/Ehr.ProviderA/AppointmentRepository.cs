using DTO;
using System;
using System.Collections.Generic;

namespace Ehr.ProviderA
{
    public class AppointmentRepository : IReturnAppointments 
    {
        public IEnumerable<Appointment> Get()
        {
            return new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    Title = "Afspraak met verpleging"
                }
            };
        }
    }
}
