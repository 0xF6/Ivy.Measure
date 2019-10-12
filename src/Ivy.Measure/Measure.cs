namespace Ivy.Measure
{
    using System;
    using System.Globalization;

    public class Measure<Q> : IMeasure<Q> where Q : class, IQuantity<Q>, new()
    {
        private static readonly IMeasureFactory<Q> Factory = new Q().Factory;

        public float Amount { get; }
        public float StandardAmount =>  Unit.ToStandardUnit(this.Amount);
        public IUnit<Q> Unit { get; }

        public Measure(IMeasure<Q> measure)
        {
            if (measure == null)
                throw new ArgumentNullException(nameof(measure));

            Amount = measure.Amount;
            Unit = measure.Unit;
        }
        public Measure(float amount, IUnit<Q> unit)
        {
            Amount = amount;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        #region Implementation of IMeasure

        public float GetAmount(IUnit<Q> unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));
            if (!unit.Quantity.Equals(default(Q)))
                throw new ArgumentException("Unit is not the same quantity as measure");
            return unit.ConvertStandardAmountToUnit(StandardAmount);
        }

        IMeasure IMeasure.this[IUnit unit] => this[unit as IUnit<Q>];
        IMeasure<Q> IMeasure<Q>.this[IUnit<Q> unit] => this[unit];
        IUnit IMeasure.Unit => Unit;

        public Measure<Q> this[IUnit<Q> unit]
        {
            get
            {
                if (unit == null)
                    throw new ArgumentNullException(nameof(unit));
                return new Measure<Q>(GetAmount(unit), unit);
            }
        }
        #endregion

        #region Implementation of IComparable and etc

        public int CompareTo(IMeasure other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (!other.Unit.Quantity.Equals(default(Q)))
                throw new ArgumentException("Measures are of different quantities");
            return Amount.Equals(other.GetAmount(Unit));
        }
        public bool Equals(IMeasure other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (!other.Unit.Quantity.Equals(default(Q)))
                throw new ArgumentException("Measures are of different quantities");

            return Amount.CompareTo(other.GetAmount(Unit));
        }
        public int CompareTo(IMeasure<Q> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            return Amount.CompareTo(other.GetAmount(Unit));
        }

        public bool Equals(IMeasure<Q> other)
        {
            if (ReferenceEquals(objA: null, objB: other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Amount.Equals(other.GetAmount(Unit));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(objA: null, objB: obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Measure<Q>))
                return false;
            return Equals((Measure<Q>)obj);
        }
        public override int GetHashCode() 
            => StandardAmount.GetHashCode();
        public override string ToString() 
            => ToString("G", CultureInfo.CurrentCulture);
        public string ToString(string format) 
            => ToString(format, CultureInfo.CurrentCulture);
        public string ToString(IFormatProvider provider) 
            => ToString("G", provider);
        public string ToString(string format, IFormatProvider provider) 
            => $"{Amount.ToString(format, provider)} {Unit.Symbol}".TrimEnd();

        #endregion

        #region Operators

        public static explicit operator Q(Measure<Q> measure) 
            => Factory.New(measure.StandardAmount);
        public static Measure<Q> operator +(Measure<Q> first,  Measure<Q> second) 
            => new Measure<Q>(first.Amount + second.GetAmount(first.Unit), first.Unit);
        public static Measure<Q> operator +(Measure<Q> first, IMeasure<Q> second) 
            => new Measure<Q>(first.Amount + second.GetAmount(first.Unit), first.Unit);
        public static Measure<Q> operator -(Measure<Q> first, Measure<Q> second) 
            => new Measure<Q>(first.Amount - second.GetAmount(first.Unit), first.Unit);
        public static Measure<Q> operator -(Measure<Q> first, IMeasure<Q> second) 
            => new Measure<Q>(first.Amount - second.GetAmount(first.Unit), first.Unit);
        public static Measure<Q> operator *(float scalar, Measure<Q> measure)
            => new Measure<Q>(scalar * measure.Amount, measure.Unit);
        public static Measure<Q> operator *(Measure<Q> measure, float scalar) 
            => new Measure<Q>(measure.Amount * scalar, measure.Unit);
        public static Measure<Q> operator /(Measure<Q> measure, float scalar) 
            => new Measure<Q>(measure.Amount / scalar, measure.Unit);
        public static bool operator <(Measure<Q> first, Measure<Q> second) 
            => first.Amount < second.GetAmount(first.Unit);
        public static bool operator >(Measure<Q> first, Measure<Q> second) 
            => first.Amount > second.GetAmount(first.Unit);
        public static bool operator <=(Measure<Q> first, Measure<Q> second) 
            => first.Amount <= second.GetAmount(first.Unit);
        public static bool operator >=(Measure<Q> first, Measure<Q> second) 
            => first.Amount >= second.GetAmount(first.Unit);
        public static bool operator ==(Measure<Q> first, Measure<Q> second) 
            => first != null && (second != null && first.Amount == second.GetAmount(first.Unit));
        public static bool operator !=(Measure<Q> first, Measure<Q> second) 
            => first != null && (second != null && first.Amount != second.GetAmount(first.Unit));

        #endregion
    }
}