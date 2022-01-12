using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reflection.CustomAttributes;
using Reflection.Providers;

namespace Reflection
{
    public class ConfigurationComponentBase<T> where T : struct
    {
        [ConfigurationItem(ProviderType.File, "123")]
        public T Setting
        {
            get
            {
                var type = typeof(ConfigurationComponentBase<T>);
                var attr = type.GetProperty("Setting")
                    ?.GetCustomAttributes(typeof(ConfigurationItemAttribute), false)
                    .First() as ConfigurationItemAttribute;
                if (attr.Type == ProviderType.File)
                {
                    var provider = new FileConfigurationProvider<T>();
                    return provider.Read(attr.Setting);
                }
                return default(T);
            }
            set
            {
                var type = typeof(ConfigurationComponentBase<T>);
                var attr = type.GetProperty("Setting")
                    ?.GetCustomAttributes(typeof(ConfigurationItemAttribute), false)
                    .First() as ConfigurationItemAttribute;
                if (attr.Type == ProviderType.File)
                {
                    var provider = new FileConfigurationProvider<T>();
                    provider.Write(attr.Setting, value);
                }
            }
        }
    }
}
