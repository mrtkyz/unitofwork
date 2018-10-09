using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Configuration;

namespace WebSessionTest3.Cache
{
    public class RedisManager : ICacheManager
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;
        private static IDatabase _cachedb;

        public RedisManager()
        {
            if(_lazyConnection == null)
            {
                _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
                {
                    string cacheConnection = ConfigurationManager.AppSettings.Get("CacheConnectionString");
                    return ConnectionMultiplexer.Connect(cacheConnection);
                });

                _cachedb = _lazyConnection.Value.GetDatabase(2);
            }
        }

        public bool AddOrUpdate<T>(string key, T value)
        {
            if (value == null)
                return false;

            string jsonValue = JsonConvert.SerializeObject(value);
            bool res = _cachedb.StringSet(key, jsonValue);

            return res;
        }

        public T Get<T>(string key)
        {
            RedisValue res = _cachedb.StringGet(key);

            if (!res.HasValue)
                return default(T);

            var deserializedObject = JsonConvert.DeserializeObject<T>(res);

            return deserializedObject;
        }
    }

    public interface ICacheManager
    {
        bool AddOrUpdate<T>(string key, T value);

        T Get<T>(string key);
    }
}