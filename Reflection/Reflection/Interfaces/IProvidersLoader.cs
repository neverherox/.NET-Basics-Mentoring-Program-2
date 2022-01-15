using System.Collections.Generic;
using PluginBase;

namespace Reflection.Interfaces
{
    public interface IProvidersLoader 
    {
        IEnumerable<IConfigurationProvider> LoadProviders(string pluginPath);
    }
}
