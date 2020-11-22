namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Services.Redis.Contracts;

    public static class ProxyExtensions
    {
        public static Task<bool> KeyExists(this IProxy proxy, string keyName, bool useKeyNameSpace = true)
        {
            if (proxy == null)
            {
                throw new ArgumentNullException("proxy");
            }

            var fullKeyName = useKeyNameSpace ? 
                $"{proxy.KeyNameSpace}:{keyName}" : 
                keyName;
            return proxy.ProxyDatabase.KeyExistsAsync(fullKeyName);
        }

        public static Task<bool> DeleteKey(this IProxy proxy, string keyName, bool useKeyNameSpace = true)
        {
            if (proxy == null)
            {
                throw new ArgumentNullException("proxy");
            }
            var fullKeyName = useKeyNameSpace ? 
                $"{proxy.KeyNameSpace}:{keyName}" : 
                keyName;
            return proxy.ProxyDatabase.KeyDeleteAsync(fullKeyName);
        }
    }
}