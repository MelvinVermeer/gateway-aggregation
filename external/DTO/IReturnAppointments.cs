using System.Collections.Generic;

namespace DTO
{
    // In our production this will not be an interface but a OpenApi Spec

    public interface IReturnAppointments : IEndpoint
    {
        IEnumerable<Appointment> Get();
    }
}
