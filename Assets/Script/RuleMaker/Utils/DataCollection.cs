using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    /// <summary>
    /// This is used as a way of saving data to dictionary
    /// </summary>
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

        private void Initialize()
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

        /// <summary>
        /// Gets the indexed data based on the key
        /// </summary>
        /// <returns>The data</returns>
        /// <param name="key">The key that the data is indexed by</param>
        public object GetData(string key)
        {
            Initialize();
            return (dictionary.ContainsKey(key)) ? dictionary[key] : default;
        }

        /// <summary>
        /// Gets the indexed data based on the key
        /// </summary>
        /// <returns>The data</returns>
        /// <param name="key">The key that the data is indexed by</param>
        public T GetData<T>(string key)
        {
            Initialize();
            return (dictionary.ContainsKey(key)) ? (T)dictionary[key] : default;
        }

        /// <summary>
        /// Sets the keyed data
        /// </summary>
        /// <param name="key">The key of the data</param>
        /// <param name="data">The data being saved. It is best to keep this simple types such int, floats, or strings</param>
        public void SetData<T>(string key, T data)
        {
            Initialize();
            dictionary[key] = data;
        }
    }
}
