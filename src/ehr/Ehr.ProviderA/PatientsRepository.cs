using DTO;
using System.Collections.Generic;

namespace Ehr.ProviderA
{
    public partial class ProviderARepository : IReturnEverything
    {
        IEnumerable<Patient> IReturnPatients.Get()
        {
            return new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "John Doe",
                }
            };
        }
    }
}
