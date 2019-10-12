namespace Ivy.Measure
{
    using System;

    public interface IUnit : IEquatable<IUnit>
    {
        #region meta

        bool IsStandard { get; }
        string DisplayFullName { get; }
        char Symbol { get; }

        #endregion

        IQuantity Quantity { get; }
        float ToStandardUnit(float amount);
        float AmountToUnit(float amount);
    }

    public interface IUnit<Z> : IUnit where Z : class, IQuantity<Z>
    {
        new IQuantity<Z> Quantity { get; }
    }
}