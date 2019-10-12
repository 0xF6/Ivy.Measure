// ReSharper disable IdentifierTypo
namespace Ivy.Measure
{
    using System;
    using System.Linq;
    using System.Reflection;
    using JetBrains.Annotations;

    [PublicAPI]
    public enum MetricPrefix
    {
        [MetricMetadata('y', -24)]
        Yocto,
        [MetricMetadata('z', -21)]
        Zepto,
        [MetricMetadata('a', -18)]
        Atto,
        [MetricMetadata('f', -15)]
        Femto,
        [MetricMetadata('p', -12)]
        Pico,
        [MetricMetadata('n', -9)]
        Nano,
        [MetricMetadata('µ', -6)]
        Micro,
        [MetricMetadata('m', -3)]
        Milli,
        [MetricMetadata('c', -2)]
        Centi,
        [MetricMetadata('d', -1)]
        Deci,
        [MetricMetadata('D', 1)]
        Deka,
        [MetricMetadata('h', 2)]
        Hecto,
        [MetricMetadata('k', 3)]
        Kilo,
        [MetricMetadata('M', 6)]
        Mega,
        [MetricMetadata('G', 9)]
        Giga,
        [MetricMetadata('T', 12)]
        Tera,
        [MetricMetadata('P', 15)]
        Peta,
        [MetricMetadata('E', 18)]
        Exa,
        [MetricMetadata('Z', 21)]
        Zetta,
        [MetricMetadata('Y', 24)]
        Yotta
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

        public static float GetFactor(this MetricPrefix prefix) =>
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
