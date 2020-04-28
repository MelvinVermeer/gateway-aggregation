using DTO;
using System.Collections.Generic;

namespace Gateway
{
    public class Feature
    {
        public string Name { get; set; }
        public IEnumerable<IEndpoint> Endpoints { get; set; }
    }
}
