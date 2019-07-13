using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Deventure.Common.Helpers
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IOrderedEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
            where T : class
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}