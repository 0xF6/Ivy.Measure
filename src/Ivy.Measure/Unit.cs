namespace Ivy.Measure
{
    using System.Linq;
    using System.Reflection;

    public abstract class Unit<X> : IUnit<X> where X : class, IQuantity<X>, new()
    {
        private static readonly X quantity = new X();
        private string displayName;
        protected Unit(bool isStandardUnit, string symbol)
        {
            IsStandard = isStandardUnit;
            Symbol = symbol;
            displayName = null;
        }

        #region Implementation of IUnit

        public bool IsStandard { get; }
        public string DisplayFullName => displayName ??= CreateUnitDisplayName(this);
        public string Symbol { get; }

        public IQuantity<X> Quantity => quantity;
        public abstract float ToStandardUnit(float amount);
        public abstract float AmountToUnit(float amount);

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

        #region etc
        internal static string CreateUnitDisplayName(IUnit unit)
        {
            var fieldInfo =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => type.IsInstanceOfType(unit.Quantity) && !type.IsInterface)
                    .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
                    .SingleOrDefault(info => ReferenceEquals(info.GetValue(obj: null), unit));
            return fieldInfo == null
                ? $"{unit.Symbol}"
                : $"{fieldInfo.Name} | {(string.IsNullOrWhiteSpace($"{unit.Symbol}") ? "<none>" : $"{unit.Symbol}")}";
        }
        #endregion
    }
}