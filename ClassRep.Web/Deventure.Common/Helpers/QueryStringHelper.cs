using System;
using System.Collections.Generic;

namespace Deventure.Common.Helpers
{
    public static class QueryStringHelper
    {
        public static Dictionary<string, string> ParseQueryString(string query, string separator = "&")
        {
            var parameters = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(separator))
            {
                return parameters;
            }

            var items = query.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (items == null || items.Length == 0)
            {
                return parameters;
            }

            foreach (var item in items)
            {
                var entry = item.Split(new[] { "=" }, StringSplitOptions.None);
                if (entry.Length != 2)
                {
                    continue;
                }
                parameters.Add(entry[0], entry[1]);
            }
            return parameters;
        }

    }
}
