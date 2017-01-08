﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class EnumerableExt
    {
        public static Type GetEnumeratedType<T>(this IEnumerable<T> e)
        {
            return typeof(T);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> rhs, Func<T, bool> filter)
        {
            foreach (T t in rhs)
            {
                if (filter(t))
                {
                    yield return t;
                }
            }
        }

        public static IEnumerable<T> Single<T>(this T item)
        {
            yield return item;
        }

        public static bool Any(this IEnumerable enumer)
        {
            foreach (var item in enumer)
            {
                return true;
            }
            return false;
        }

        public static bool CountGreaterThan(this IEnumerable enumer, int count)
        {
            foreach (var e in enumer)
            {
                if (count-- < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<T> And<T>(this IEnumerable<T> enumer, IEnumerable<T> enumer2)
        {
            foreach (var e in enumer)
            {
                yield return e;
            }
            foreach (var e in enumer2)
            {
                yield return e;
            }
        }

        public static IEnumerable<T> And<T>(this T item, IEnumerable<T> enumer2)
        {
            yield return item;
            foreach (var e in enumer2)
            {
                yield return e;
            }
        }

        public static IEnumerable<T> And<T>(this IEnumerable<T> enumer2, T item)
        {
            foreach (var e in enumer2)
            {
                yield return e;
            }
            yield return item;
        }

        public static IEnumerable<R> SelectWhere<T, R>(this IEnumerable<T> enumer, Func<T, TryGet<R>> conv)
        {
            foreach (var item in enumer)
            {
                var get = conv(item);
                if (get.Succeeded)
                {
                    yield return get.Value;
                }
            }
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> e, RandomSource rand)
        {
            return e.OrderBy<T, int>((item) => rand.Next());
        }
    }
}
