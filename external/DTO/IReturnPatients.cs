using System.Collections.Generic;

namespace DTO
{
    public interface IReturnPatients : IEndpoint
    {
        IEnumerable<Patient> Get();
    }
}
