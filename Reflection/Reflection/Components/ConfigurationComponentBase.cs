using System;
using Reflection.CustomAttributes;
using Reflection.Providers;

namespace Reflection.Components
{
    public abstract class ConfigurationComponentBase
    {
        public object LoadSetting(string propertyName)
        {
            var attribute = GetAttribute(propertyName);
            if (attribute != null)
            {
                if (attribute.Type == ProviderType.Appsetings)
                {
                    var provider = new AppsetingsConfigurationProvider();
                    var value = provider.Read(attribute.Setting);
                    return value;
                }
            }
            return null;
        }

        public void SaveSetting(string propertyName, object value)
        {
            var attribute = GetAttribute(propertyName);
            if (attribute != null)
            {
                if (attribute.Type == ProviderType.Appsetings)
                {
                    var provider = new AppsetingsConfigurationProvider();
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
