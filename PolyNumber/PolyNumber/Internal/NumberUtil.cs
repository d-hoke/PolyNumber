﻿using System;
using System.Collections.Generic;
using System.Linq;
using Frac = Numerics.BigRational;
using Int = System.Numerics.BigInteger;

namespace Strilanc.PolyNumber.Internal {
    internal static class NumberUtil {
        public static T Max<T>(this T value1, T value2) where T : IComparable<T> {
            return value1.CompareTo(value2) >= 0 ? value1 : value2;
        }
        public static T Min<T>(this T value1, T value2) where T : IComparable<T> {
            return value1.CompareTo(value2) <= 0 ? value1 : value2;
        }
        public static Int Lcm(this Int value1, Int value2) {
            return value1*value2/Int.GreatestCommonDivisor(value1, value2);
        }
        public static Int Lcm(this IEnumerable<Int> values) {
            return values.Aggregate(Int.One, Lcm);
        }
        public static Int LeastCommonDenominator(this IEnumerable<Frac> values) {
            return values.Where(e => e != 0).Select(e => e.Denominator).Lcm();
        }
    }
}
