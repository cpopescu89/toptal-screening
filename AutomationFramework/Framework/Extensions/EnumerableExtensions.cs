using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationFramework.Framework.Extensions
{
    public static class EnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> source) => source.PickRandom(1).Single();

        private static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) =>
            source.Shuffle().Take(count);

        private static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid());
    }
}
