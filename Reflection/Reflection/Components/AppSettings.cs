using System;
using PluginBase;
using Reflection.CustomAttributes;
using Reflection.Interfaces;

namespace Reflection.Components
{
    public class AppSettings: ConfigurationComponentBase
    {
        public AppSettings(IProvidersFactory providersFactory) : base(providersFactory)
        {

        }

        [ConfigurationItem(ProviderType.AppSetings, "ConnectionString")]
        public override string ConnectionString
        {
            get => base.ConnectionString;
            set => base.ConnectionString = value;
        }

        [ConfigurationItem(ProviderType.AppSetings, "Timeout")]
        public override TimeSpan? Timeout
        {
            get => base.Timeout;
            set => base.Timeout = value;
        }

        [ConfigurationItem(ProviderType.AppSetings, "RetryCount")]
        public override int? RetryCount
        {
            get => base.RetryCount;
            set => base.RetryCount = value;
        }

        [ConfigurationItem(ProviderType.AppSetings, "RelativeError")]
        public override float? RelativeError 
        { 
            get => base.RelativeError;
            set => base.RelativeError = value;
        }
    }
}
