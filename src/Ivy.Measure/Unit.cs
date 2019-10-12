namespace Ivy.Measure
{
    public abstract class Unit<X> : IUnit<X> where X : class, IQuantity<X>, new()
    {
        private static readonly X quantity = new X();

        protected Unit(bool isStandardUnit, char symbol)
        {
            this.IsStandard = isStandardUnit;
            this.Symbol = symbol;
            this.DisplayFullName = null;
        }

        #region Implementation of IUnit

        public bool IsStandard { get; }
        public string DisplayFullName { get; }
        public char Symbol { get; }

        public IQuantity<X> Quantity => throw new System.NotImplementedException();

        IQuantity IUnit.Quantity => quantity;

        #endregion

        #region Implementation of IEquatable

        public bool Equals(IUnit<X> other)
        {
            throw new System.NotImplementedException();
        }
        public bool Equals(IUnit other)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Operatos

        public static implicit operator X(Unit<X> unit) 
            => quantity.Factory.New(amount: 1.0f, unit: unit);
        public static X operator *(float amount, Unit<X> unit) 
            => quantity.Factory.New(amount, unit);
        public static IMeasure<X> operator |(float amount, Unit<X> unit) 
            => quantity.Factory.NewPreserveUnit(amount, unit);

        #endregion


        #region Overrides of Object

        public override string ToString() => DisplayFullName;

        #endregion
    }
}