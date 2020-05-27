using System.Collections.Generic;

namespace Gateway
{
    public class DataProvider
    {
        public string Type { get; set; }
        public IEnumerable<string> UseForEntityTypes { get; set; }

        // other properties might contain information on how to connect to a data provider
    }
}
