using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager//MemCache veya RedisCache'de kullanılabilir ama projemiz tek     
    {                             //bir IIS Server'dan yayınlanacaksa MemoryCache bizim için yeterlidir.
        T Get<T>(string key);
        void Add(string key, object data, int cacheTime);
        bool isAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}
