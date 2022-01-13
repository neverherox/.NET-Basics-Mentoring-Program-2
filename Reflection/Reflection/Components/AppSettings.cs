using System;
using Reflection.CustomAttributes;

namespace Reflection.Components
{
    public class AppSettings: ConfigurationComponentBase
    {
        [ConfigurationItem(ProviderType.Appsetings, "ConnectionString")]
        public string ConnectionString
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

        [ConfigurationItem(ProviderType.Appsetings, "Timeout")]
        public TimeSpan? Timeout
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

        [ConfigurationItem(ProviderType.Appsetings, "RetryCount")]
        public int? RetryCount
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
    }
}
