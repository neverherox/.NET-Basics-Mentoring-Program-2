using PluginBase;

namespace Reflection.Interfaces
{
    public interface IProvidersFactory
    {
        IConfigurationProvider GetProvider(ProviderType providerType);
    }
}
