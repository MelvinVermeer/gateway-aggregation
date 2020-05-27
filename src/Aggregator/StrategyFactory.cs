using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aggregator
{
    public static class StrategyFactory
    {
        /// <summary>
        /// Returns null if not found, throws exception if more than 1 strategy is listed.
        /// </summary>
        public static T CreateStrategy<T>(IEnumerable<string> useStrategies) where T : class
        {
            var type = typeof(T);
            var assembly = Assembly.GetAssembly(type);

            var strategies = assembly.GetTypes()
                .Where(x => type.IsAssignableFrom(x))
                .Where(x => !x.IsInterface) // exclude the interface itself
                .Where(x => useStrategies.ToList().Contains(x.Name))
                .Select(x => Activator.CreateInstance(x) as T);

            if (strategies.Count() > 1)
            {
                throw new Exception($"Please provide not more than one {type.Name} in the config");
            }

            return strategies.FirstOrDefault();
        }
    }
}