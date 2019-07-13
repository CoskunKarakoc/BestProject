using Best.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.Aspects.Postsharp.CacheAspects
{
    //PostSharp'ın referansını ekledim
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _cachetype;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cachetype, int cacheByMinute=60)
        {
            _cachetype = cachetype;
            _cacheByMinute = cacheByMinute;
           
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cachetype)==false)//Cachetype'ta gelen nesne eğer bir ICacheManager değilse hata fırlat.
            {
                throw new Exception("Yanlış Önbellek Yöneticisi(Wrong Cache Manager)");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);
            base.RuntimeInitialize(method);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,//Namespace'in değerini aldım.
                args.Method.ReflectedType.Name,//Class'ın adını aldım.
                args.Method.Name);//Method'un adını aldım
            var arguments = args.Arguments.ToList();
            var key = string.Format("{0}({1})", methodName,//Method için key değeri oluşturdum.
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
            if (_cacheManager.isAdd(key))//Cache'de böyle bir obje varsa onu getir.
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);

            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);//Cache'de böyle bir obje yoksa cache'e at.
        }
    }
}
