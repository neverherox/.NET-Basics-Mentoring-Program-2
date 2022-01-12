using System;
using System.Collections.Generic;
using System.Text;
using Reflection.CustomAttributes;

namespace Reflection.Components
{
    public class ConfigurationComponent: ConfigurationComponentBase
    {
        [ConfigurationItem(ProviderType.File, "Id")]
        public int Id
        {
            get
            {
               var value = (int) LoadSetting();
               return value;
            }
            set => SaveSetting(value);
        }
    }
}
