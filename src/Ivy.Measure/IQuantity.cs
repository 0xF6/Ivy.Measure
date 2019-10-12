namespace Ivy.Measure
{
    using System;
    using JetBrains.Annotations;
    [PublicAPI]
    public interface IQuantity : IEquatable<IQuantity>
    {
        /// <summary>
        /// Standard unit associated with the quantity
        /// </summary>
        IUnit StandardUnit { get; }
        /// <summary>
        /// Display name of the quantity
        /// </summary>
        string DisplayFullName { get; }
        /// <summary>
        /// Physical dimension of the quantity in terms of SI units
        /// </summary>
        QuantityDimension Dimension { get; }
    }
    [PublicAPI]
    public interface IQuantity<R> : IQuantity where R : class, IQuantity<R>
    {
        /// <summary>
        /// Standard unit associated with the quantity
        /// </summary>
        new IUnit<R> StandardUnit { get; }
        /// <summary>
        /// Measure factory associated with the quantity.
        /// </summary>
        IMeasureFactory<R> Factory { get; }
    }
}