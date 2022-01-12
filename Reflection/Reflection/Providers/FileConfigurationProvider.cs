using Reflection.CustomAttributes;

namespace Reflection.Providers
{
    public class FileConfigurationProvider<T> where T : struct
    {
        public T Read(string settingName)
        {
            return default(T);
        }

        public void Write(string settingName, T value)
        {
            
        }
    }
}
