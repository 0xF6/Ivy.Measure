// ReSharper disable IdentifierTypo
namespace Ivy.Measure
{
    using System;
    using System.Linq;
    using System.Reflection;

    public enum MetricPrefix
    {
        [MetricMetadata('y', -24)]
        Yocto,
        [MetricMetadata('z', -21)]
        Zepto = -21,
        [MetricMetadata('a', -18)]
        Atto = -18,
        [MetricMetadata('f', -15)]
        Femto = -15,
        [MetricMetadata('p', -12)]
        Pico = -12,
        [MetricMetadata('n', -9)]
        Nano = -9,
        [MetricMetadata('µ', -6)]
        Micro = -6,
        [MetricMetadata('m', -3)]
        Milli = -3,
        [MetricMetadata('c', -2)]
        Centi = -2,
        [MetricMetadata('d', -1)]
        Deci = -1,
        [MetricMetadata('D', 1)]
        Deka = 1,
        [MetricMetadata('h', 2)]
        Hecto = 2,
        [MetricMetadata('k', 3)]
        Kilo = 3,
        [MetricMetadata('M', 6)]
        Mega = 6,
        [MetricMetadata('G', 9)]
        Giga = 9,
        [MetricMetadata('T', 12)]
        Tera = 12,
        [MetricMetadata('P', 15)]
        Peta = 15,
        [MetricMetadata('E', 18)]
        Exa = 18,
        [MetricMetadata('Z', 21)]
        Zetta = 21,
        [MetricMetadata('Y', 24)]
        Yotta = 24
    }

    public static class MetricPrefixExtensions
    {
        public static char GetSymbolOf(this MetricPrefix prefix) =>
            typeof(MetricPrefix)
                .GetMember($"{prefix}")
                .First()
                .GetCustomAttribute<MetricMetadataAttribute>()
                ._symbol;
        private static sbyte GetFactorValue(this MetricPrefix prefix) =>
            typeof(MetricPrefix)
                .GetMember($"{prefix}")
                .First()
                .GetCustomAttribute<MetricMetadataAttribute>()
                ._factor;

        private static float GetFactor(this MetricPrefix prefix) =>
            MathF.Pow(10f, prefix.GetFactorValue());
    }
    public class MetricMetadataAttribute : Attribute
    {
        public readonly char _symbol;
        public readonly sbyte _factor;

        public MetricMetadataAttribute(char symbol, sbyte factor)
        {
            _symbol = symbol;
            _factor = factor;
        }
    }
}
