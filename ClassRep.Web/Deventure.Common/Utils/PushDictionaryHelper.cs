using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.Common.Utils
{
    public class PushDictionaryHelper
    {
        public static string GetByKey(IDictionary<string, string> dictionary, string key)
        {
            if (dictionary == null || dictionary.Count == 0 || string.IsNullOrWhiteSpace(key))
            {
                return string.Empty;
            }

            string value;
            dictionary.TryGetValue(key, out value);

            return value;
        }
    }
}
