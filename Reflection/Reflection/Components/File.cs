using System;
using PluginBase;
using Reflection.CustomAttributes;
using Reflection.Interfaces;

namespace Reflection.Components
{
    public class File : ConfigurationComponentBase
    {
        public File(IProvidersFactory providersFactory) : base(providersFactory)
        {

        }

        [ConfigurationItem(ProviderType.File, "ConnectionString")]
        public override string ConnectionString
        {
            get => base.ConnectionString;
            set => base.ConnectionString = value;
        }

        [ConfigurationItem(ProviderType.File, "Timeout")]
        public override TimeSpan? Timeout
        {
            get => base.Timeout;
            set => base.Timeout = value;
        }

        [ConfigurationItem(ProviderType.File, "RetryCount")]
        public override int? RetryCount
        {
            get => base.RetryCount;
            set => base.RetryCount = value;
        }

        [ConfigurationItem(ProviderType.File, "RelativeError")]
        public override float? RelativeError
        {
            get => base.RelativeError;
            set => base.RelativeError = value;
        }
    }
}
