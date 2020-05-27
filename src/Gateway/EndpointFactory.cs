using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway
{
    public static class EndpointFactory
    {
        public static IEnumerable<T> CreateEndpoints<T>(string entityType) where T : class
        {
            // Data providers are instatiated based on type name

            // In a production scenario the data providers would be dynamically 
            // registered in the DI container

            return Config.DataProviders
                .Where(x => x.UseForEntityTypes.Contains(entityType))
                .Select(x => x.Type)
                .Select(x => Activator.CreateInstance(Type.GetType(x)) as T)
                .Where(x => x != null);
        }
    }
}