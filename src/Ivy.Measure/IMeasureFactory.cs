namespace Ivy.Measure
{
    using System;
    using JetBrains.Annotations;
    [PublicAPI]
    public interface IMeasureFactory<Q> where Q : class, IQuantity<Q>
    {
        Q New(float amount);
        Q New(float amount, IUnit<Q> unit);
        IMeasure<Q> NewPreserveUnit(float amount, IUnit<Q> unit);
    }
    [PublicAPI]
    public interface IMeasure<Q> : IMeasure, IComparable<IMeasure<Q>>, IEquatable<IMeasure<Q>>
        where Q : class, IQuantity<Q>
    {
        new IUnit<Q> Unit { get; }
        float GetAmount(IUnit<Q> unit);
        IMeasure<Q> this[IUnit<Q> iUnit] { get; }
    }

    public interface IMeasure : IComparable<IMeasure>, IEquatable<IMeasure>
    {
        float Amount { get; }
        float StandardAmount { get; }
        IUnit Unit { get; }
        float GetAmount(IUnit unit);
        IMeasure this[IUnit iUnit] { get; }
    }
}