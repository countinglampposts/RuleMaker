using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class DataCollection
    {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public object GetData(string key)
        {
            return (dictionary.ContainsKey(key)) ? dictionary[key] : default;
        }

        public T GetData<T>(string key)
        {
            return (dictionary.ContainsKey(key)) ? (T)dictionary[key] : default;
        }

        public void SetData<T>(string key, T data)
        {
            dictionary[key] = data;
        }
    }
}
