namespace Ivy.Measure
{
    public sealed class ConstantConverterUnit<Q> : Unit<Q> where Q : class, IQuantity<Q>, new()
    {
        private readonly float amountToStandardUnitFactor;
        private readonly float standardAmountToUnitFactor;


        /// <summary>
        /// Initialize a physical unit object that is the standard unit of the specific quantity
        /// </summary>
        /// <param name="symbol">Unit display symbol</param>
        public ConstantConverterUnit(string symbol) : base(isStandardUnit: true, symbol: symbol)
        {
            this.amountToStandardUnitFactor = MeasureMath.One;
            this.standardAmountToUnitFactor = MeasureMath.One;
        }

        /// <summary>
        /// Convenience constructor for initializing prefixed non-standard unit
        /// </summary>
        /// <param name="prefix">Prefix to use in unit naming and scaling vis-a-vis standard unit</param>
        public ConstantConverterUnit(MetricPrefix prefix)
            : this($"{prefix.GetSymbol()}{new Q().StandardUnit.Symbol}", prefix.GetFactor())
        {
        }

        /// <summary>
        /// Initialize a physical unit object
        /// </summary>
        /// <param name="symbol">Unit display symbol</param>
        /// <param name="toStandardUnitFactor">Amount converter factor from this unit to quantity's standard unit</param>
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        public ConstantConverterUnit(string symbol, float toStandardUnitFactor)
            : base(toStandardUnitFactor == MeasureMath.One, symbol)
        {
            this.amountToStandardUnitFactor = toStandardUnitFactor;
            this.standardAmountToUnitFactor = MeasureMath.One / toStandardUnitFactor;
        }


        /// <summary>
        /// Convert the amount from the current unit to the standard unit of the specified quantity
        /// </summary>
        /// <param name="amount">Amount in this unit</param>
        /// <returns>Amount converted to standard unit</returns>
        public override float ToStandardUnit(float amount) 
            => this.amountToStandardUnitFactor * amount;
        /// <summary>
        /// Convert a standard amount to this unit of the specified quantity
        /// to the current unit
        /// </summary>
        /// <param name="standardAmount">Standard amount of the current <see cref="IUnit.Quantity"/>.</param>
        /// <returns>Amount in this unit.</returns>
        public override float AmountToUnit(float standardAmount) 
            => this.standardAmountToUnitFactor * standardAmount;
    }
}