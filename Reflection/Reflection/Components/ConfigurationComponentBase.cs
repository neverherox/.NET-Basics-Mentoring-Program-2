using System;
using Reflection.CustomAttributes;
using Reflection.Interfaces;

namespace Reflection.Components
{
    public abstract class ConfigurationComponentBase
    {
        private readonly IProvidersFactory _providersFactory;

        protected ConfigurationComponentBase(IProvidersFactory providersFactory)
        {
            _providersFactory = providersFactory;
        }

        public virtual string ConnectionString
        {
            get
            {
                var value = LoadSetting(nameof(ConnectionString));
                if (value != null)
                {
                    return value.ToString();
                }
                return null;
            }
            set => SaveSetting(nameof(ConnectionString), value);
        }

        public virtual TimeSpan? Timeout
        {
            get
            {
                var value = LoadSetting(nameof(Timeout));
                if (value != null)
                {
                    if (TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpan))
                    {
                        return timeSpan;
                    }
                }
                return null;
            }
            set => SaveSetting(nameof(Timeout), value);
        }

        public virtual int? RetryCount
        {
            get
            {
                var value = LoadSetting(nameof(RetryCount));
                if (value != null)
                {
                    if (int.TryParse(value.ToString(), out int retryCount))
                    {
                        return retryCount;
                    }
                }
                return null;
            }
            set => SaveSetting(nameof(RetryCount), value);
        }

        public virtual float? RelativeError
        {
            get
            {
                var value = LoadSetting(nameof(RelativeError));
                if (value != null)
                {
                    if (float.TryParse(value.ToString(), out float relativeError))
                    {
                        return relativeError;
                    }
                }
                return null;
            }
            set => SaveSetting(nameof(RelativeError), value);
        }

        protected virtual object LoadSetting(string propertyName)
        {
            var attribute = GetAttribute(propertyName);
            if (attribute != null)
            {
                var provider = _providersFactory.GetProvider(attribute.Type);
                if (provider != null)
                {
                    return provider.Read(attribute.Setting);
                }
            }
            return null;
        }

        protected virtual void SaveSetting(string propertyName, object value)
        {
            var attribute = GetAttribute(propertyName);
            if (attribute != null)
            {
                var provider = _providersFactory.GetProvider(attribute.Type);
                if (provider != null)
                {
                    provider.Write(attribute.Setting, value);
                }
            }
        }

        private ConfigurationItemAttribute GetAttribute(string propertyName)
        {
            var type = GetType();
            var property = type.GetProperty(propertyName);
            if (property != null)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute))
                    as ConfigurationItemAttribute;
                return attribute;
            }
            return null;
        }
    }
}
