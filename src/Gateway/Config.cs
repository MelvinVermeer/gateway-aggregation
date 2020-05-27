using System.Collections.Generic;

namespace Gateway
{
    public static class Config
    {
        public static readonly IEnumerable<DataProvider> DataProviders =
        new[]
        {
            new DataProvider
            {
                Type = "Ehr.ProviderA.ProviderARepository, Ehr.ProviderA",
                UseForEntityTypes = new[] {"appointment", "patient"}
            },
             new DataProvider
            {
                Type = "Ehr.ProviderB.AppointmentService, Ehr.ProviderB",
                UseForEntityTypes = new[] {"appointment"}
            }
        };

        public static readonly IEnumerable<string> UseStrategies = new[]
        { 
            "ConcatAppointmentsStrategy"
        };
    }
}
