﻿using System.Collections.Generic;

namespace MathExtended.Fractions
{
    internal static class Constants
    {
        public static readonly string ContinuedFractionGroupingPattern = @"^\[(?<leading>\d+)\;(\s?(\d+)\,?)+\]$";
        public static readonly string ContinuedFractionMatchingPattern = @"^\[\d+\;(\s?(\d+)\,?)+\]$";

        public static readonly string FractionGroupingPattern = @"^(?<numerator>\d+)\/(?<denominator>\d+)$";
        public static readonly string FractionMatchingPattern = @"^\d+\/\d+$";

        public static readonly int ContinuedMaxElements = 50;

        internal static class Characters
        {
            public static readonly string Slash = "\u2044";

            internal static class Superscript
            {
                public static readonly string Zero = "\u2070";
                public static readonly string One = "\u00B9";
                public static readonly string Two = "\u00B2";
                public static readonly string Three = "\u00B3";
                public static readonly string Four = "\u2074";
                public static readonly string Five = "\u2075";
                public static readonly string Six = "\u2076";
                public static readonly string Seven = "\u2077";
                public static readonly string Eight = "\u2078";
                public static readonly string Nine = "\u2079";

                public static readonly Dictionary<int, string> Mapping = new Dictionary<int, string>()
                {
                    { 0, "\u2070"},
                    { 1, "\u00B9"},
                    { 2, "\u00B2"},
                    { 3, "\u00B3"},
                    { 4, "\u2074"},
                    { 5, "\u2075"},
                    { 6, "\u2076"},
                    { 7, "\u2077"},
                    { 8, "\u2078"},
                    { 9, "\u2079"}
                };
            }

            internal static class Subscript
            {
                public static readonly string Zero = "\u2080";
                public static readonly string One = "\u2081";
                public static readonly string Two = "\u2082";
                public static readonly string Three = "\u2083";
                public static readonly string Four = "\u2084";
                public static readonly string Five = "\u2085";
                public static readonly string Six = "\u2086";
                public static readonly string Seven = "\u2087";
                public static readonly string Eight = "\u2088";
                public static readonly string Nine = "\u2089";

                public static readonly Dictionary<int, string> Mapping = new Dictionary<int, string>()
                {
                    { 0, "\u2080"},
                    { 1, "\u2081"},
                    { 2, "\u2082"},
                    { 3, "\u2083"},
                    { 4, "\u2084"},
                    { 5, "\u2085"},
                    { 6, "\u2086"},
                    { 7, "\u2087"},
                    { 8, "\u2088"},
                    { 9, "\u2089"}
                };
            }
        }
    }

    public static class ContinuedFractions
    {
        public static readonly string e = "[2;1,2,1,1,4,1,1,6,1,1,8,1,1,10,1,1,12,1,1,14,1,1,16,1,1,18,1,1,20,1,1,22,1,1,24,1,1,26,1,1,28,1,1,30,1,1,32,1,1,34,1,1,36,1,1,38,1,1,40,1,1,42,1,1,44,1,1,46,1,1,48,1,1,50,1,1,52,1,1,54,1,1,56,1,1,58,1,1,60,1,1,62,1,1,64,1,1,66]";
        public static readonly string Pi = "[3;7,15,1,292,1,1,1,2,1,3,1,14,2,1,1,2,2,2,2,1,84,2,1,1,15,3,13,1,4,2,6,6,99,1,2,2,6,3,5,1,1,6,8,1,7,1,2,3,7,1,2,1,1,12,1,1,1,3,1,1,8,1,1,2,1,6,1,1,5,2,2,3,1,2,4,4,16,1,161,45,1,22,1,2,2,1,4,1,2,24,1,2,1,3,1,2,1]";
        public static readonly string Phi = "[1;1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]";
        public static readonly string Sqrt2 = "[1;2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2]";
        public static readonly string Sqrt3 = "[1;1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2]";
    }
}