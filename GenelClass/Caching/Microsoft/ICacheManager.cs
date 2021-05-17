using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.Caching.Microsoft
{
    public interface ICacheManager
    {
        //key anahtar, value değer, duration burada ne kadar duracak(Dakika olarak tutulabilir)
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        //Cache de var mı ?
        bool IsAdd(string key);
        //Cache den uçurma
        void Remove(string key);
        //RemoveByPattern içerisinde belirlediğimiz kelime geçen metotlara uygulamak için kullanılır
        void RemoveByPattern(string pattern);
    }
}
