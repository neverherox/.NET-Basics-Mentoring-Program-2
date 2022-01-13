using System;

namespace Reflection.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        private readonly ProviderType _type;
        private readonly string _settingName;

        public ConfigurationItemAttribute(ProviderType type, string settingName)
        {
            _type = type;
            _settingName = settingName;
        }

        public virtual ProviderType Type => _type;

        public virtual string Setting => _settingName;
    }

    public enum ProviderType
    {
        File,
        Appsetings
    }
}
