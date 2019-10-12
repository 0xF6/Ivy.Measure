namespace Ivy.Measure
{
    using System;

    public interface IQuantity : IEquatable<IQuantity>
    {
        IUnit StandardUnit { get; }
        string DisplayFullName { get; }
    }
    public interface IQuantity<R> : IQuantity where R : class, IQuantity<R>
    {
        new IUnit<R> StandardUnit { get; }
        IMeasureFactory<R> Factory { get; }
    }
}