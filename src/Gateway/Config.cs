using DTO;
using Ehr.ProviderA;
using Ehr.ProviderB;
using System.Collections.Generic;

namespace Gateway
{
    public static class Config
    {
        public static readonly IEnumerable<Feature> Features =
            new[]
            {
                new Feature
                {
                    Name = "appointments",
                    Endpoints = new List<IEndpoint>
                    {
                        new AppointmentRepository(),
                        new AppointmentService()
                    }
                }
            };
    }
}
