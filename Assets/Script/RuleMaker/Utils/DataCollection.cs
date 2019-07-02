using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class DataCollection
    {
        [System.Serializable]
        private class kvp
        {
            public string key;
            public string value;
        }

        [SerializeField] kvp[] presetKeys;

        private Dictionary<string, object> dictionary = new Dictionary<string, object>();
        private bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                foreach (var a in presetKeys)
                {
                    dictionary[a.key] = a.value;
                }
                initialized = true;
            }
        }

        public object GetData(string key)
        {
            Initialize();
            return (dictionary.ContainsKey(key)) ? dictionary[key] : default;
        }

        public T GetData<T>(string key)
        {
            return (T)GetData(key);
        }

        public void SetData<T>(string key, T data)
        {
            Initialize();
            dictionary[key] = data;
        }
    }
}
