namespace Ivy.Measure
{
    using System;
    using System.Collections.Generic;

    public class QuantityDimension
    {
        #region base

        public static readonly QuantityDimension Length = new QuantityDimension(iLengthExponent: 1, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension Mass = new QuantityDimension(iLengthExponent: 0, iMassExponent: 1, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension Time = new QuantityDimension(iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 1, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension ElectricCurrent = new QuantityDimension(iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 1, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension Temperature = new QuantityDimension(iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 1, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension LuminousIntensity = new QuantityDimension(iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 1, iAmountOfSubstanceExponent: 0);
        public static readonly QuantityDimension AmountOfSubstance = new QuantityDimension(iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 1);

        public static readonly QuantityDimension Number = new QuantityDimension(iDimensionlessDifferentiator: 1);

        public static readonly QuantityDimension Radian = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension Steradian = Radian * Radian;
        public static readonly QuantityDimension Pi = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension RelativeDensity = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension RefractiveIndex = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension RelativePermeability = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension RelativeBiologicalEffectiveness = new QuantityDimension(GetNextPrime());
        public static readonly QuantityDimension Meterset = new QuantityDimension(GetNextPrime());


        #endregion

        #region Contructors

        private QuantityDimension(int iDimensionlessDifferentiator) :
            this(iDimensionlessDifferentiator, iLengthExponent: 0, iMassExponent: 0, iTimeExponent: 0, iElectricCurrentExponent: 0, iTemperatureExponent: 0, iLuminousIntensityExponent: 0, iAmountOfSubstanceExponent: 0)
        {
        }
        internal QuantityDimension(int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
            int iLuminousIntensityExponent, int iAmountOfSubstanceExponent) :
            this(iDimensionlessDifferentiator: 1.0f, iLengthExponent: iLengthExponent, iMassExponent: iMassExponent, iTimeExponent: iTimeExponent, iElectricCurrentExponent: iElectricCurrentExponent,
            iTemperatureExponent: iTemperatureExponent, iLuminousIntensityExponent: iLuminousIntensityExponent, iAmountOfSubstanceExponent: iAmountOfSubstanceExponent)
        {
        }

        private QuantityDimension(float iDimensionlessDifferentiator, int iLengthExponent, int iMassExponent, int iTimeExponent, int iElectricCurrentExponent, int iTemperatureExponent,
            int iLuminousIntensityExponent, int iAmountOfSubstanceExponent)
        {
            DimensionlessDifferentiator = iDimensionlessDifferentiator;
            LengthExponent = iLengthExponent;
            MassExponent = iMassExponent;
            TimeExponent = iTimeExponent;
            ElectricCurrentExponent = iElectricCurrentExponent;
            TemperatureExponent = iTemperatureExponent;
            LuminousIntensityExponent = iLuminousIntensityExponent;
            AmountOfSubstanceExponent = iAmountOfSubstanceExponent;
        }

        #endregion

        #region fields

        /// <summary>
        /// Gets the scalar used to differentiate between relevant dimensionless quantities
        /// </summary>
        internal float DimensionlessDifferentiator { get; private set; }

        /// <summary>
        /// Gets the length (m) exponent
        /// </summary>
        internal int LengthExponent { get; private set; }

        /// <summary>
        /// Gets the mass (kg) exponent
        /// </summary>
        internal int MassExponent { get; private set; }

        /// <summary>
        /// Gets the time (s) exponent
        /// </summary>
        internal int TimeExponent { get; private set; }

        /// <summary>
        /// Gets the electric current (A) exponent
        /// </summary>
        internal int ElectricCurrentExponent { get; private set; }

        /// <summary>
        /// Gets the temperature (K) exponent
        /// </summary>
        internal int TemperatureExponent { get; private set; }

        /// <summary>
        /// Gets the luminous intensity (Cd) exponent
        /// </summary>
        internal int LuminousIntensityExponent { get; private set; }

        /// <summary>
        /// Gets the substance amount (mol) exponent
        /// </summary>
        internal int AmountOfSubstanceExponent { get; private set; }

        #endregion

        #region Methods

        internal bool ExponentsEqual(QuantityDimension other)
        {
            if (ReferenceEquals(objA: null, objB: other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AreExponentsEqualTo(other);
        }

        internal bool Equals(QuantityDimension other)
        {
            if (ReferenceEquals(objA: null, objB: other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Math.Abs(other.DimensionlessDifferentiator - DimensionlessDifferentiator) < float.Epsilon &&
                   AreExponentsEqualTo(other);
        }

        public override bool Equals(object obj) 
            => Equals(obj as QuantityDimension);

        public override int GetHashCode()
        {
            unchecked
            {
                var result = DimensionlessDifferentiator.GetHashCode();
                result = (result * 397) ^ LengthExponent;
                result = (result * 397) ^ MassExponent;
                result = (result * 397) ^ TimeExponent;
                result = (result * 397) ^ ElectricCurrentExponent;
                result = (result * 397) ^ TemperatureExponent;
                result = (result * 397) ^ LuminousIntensityExponent;
                result = (result * 397) ^ AmountOfSubstanceExponent;
                return result;
            }
        }

        public override string ToString() =>
            string.Format("{0}{1}{2}{3}{4}{5}{6}",
                ConditionalOutput("m", LengthExponent), ConditionalOutput("kg", MassExponent),
                ConditionalOutput("s", TimeExponent), ConditionalOutput("A", ElectricCurrentExponent),
                ConditionalOutput("K", TemperatureExponent), ConditionalOutput("Cd", LuminousIntensityExponent),
                ConditionalOutput("mol", AmountOfSubstanceExponent)).Trim();

        private bool AreExponentsEqualTo(QuantityDimension other) =>
            other.LengthExponent == LengthExponent && other.MassExponent == MassExponent &&
            other.TimeExponent == TimeExponent &&
            other.ElectricCurrentExponent == ElectricCurrentExponent &&
            other.TemperatureExponent == TemperatureExponent &&
            other.LuminousIntensityExponent == LuminousIntensityExponent &&
            other.AmountOfSubstanceExponent == AmountOfSubstanceExponent;

        private static string ConditionalOutput(string iSiUnit, int iExponent) =>
            iExponent == 0
                ? string.Empty
                : iExponent == 1 ? $" {iSiUnit}"
                    : $" {iSiUnit}^{iExponent}";

        private static int GetNextPrime()
        {
            if (primes.MoveNext()) 
                return primes.Current;
            throw new InvalidOperationException("Reached the end of the Int32 prime number collection");
        }

        private static readonly IEnumerator<int> primes 
            = MeasureMath.PrimeInt32.GetEnumerator();
        #endregion

        #region Operators

        public static QuantityDimension operator *(QuantityDimension iLhs, QuantityDimension iRhs) =>
            new QuantityDimension(iLhs.DimensionlessDifferentiator * iRhs.DimensionlessDifferentiator,
                iLhs.LengthExponent + iRhs.LengthExponent, iLhs.MassExponent + iRhs.MassExponent,
                iLhs.TimeExponent + iRhs.TimeExponent, iLhs.ElectricCurrentExponent + iRhs.ElectricCurrentExponent,
                iLhs.TemperatureExponent + iRhs.TemperatureExponent, iLhs.LuminousIntensityExponent + iRhs.LuminousIntensityExponent,
                iLhs.AmountOfSubstanceExponent + iRhs.AmountOfSubstanceExponent);

        public static QuantityDimension operator /(QuantityDimension iLhs, QuantityDimension iRhs) =>
            new QuantityDimension(iLhs.DimensionlessDifferentiator / iRhs.DimensionlessDifferentiator,
                iLhs.LengthExponent - iRhs.LengthExponent, iLhs.MassExponent - iRhs.MassExponent,
                iLhs.TimeExponent - iRhs.TimeExponent, iLhs.ElectricCurrentExponent - iRhs.ElectricCurrentExponent,
                iLhs.TemperatureExponent - iRhs.TemperatureExponent, iLhs.LuminousIntensityExponent - iRhs.LuminousIntensityExponent,
                iLhs.AmountOfSubstanceExponent - iRhs.AmountOfSubstanceExponent);

        public static QuantityDimension operator ^(QuantityDimension iDimension, int iExponent) =>
            new QuantityDimension(MathF.Pow(iDimension.DimensionlessDifferentiator, iExponent),
                iExponent * iDimension.LengthExponent, iExponent * iDimension.MassExponent,
                iExponent * iDimension.TimeExponent, iExponent * iDimension.ElectricCurrentExponent,
                iExponent * iDimension.TemperatureExponent, iExponent * iDimension.LuminousIntensityExponent,
                iExponent * iDimension.AmountOfSubstanceExponent);

        #endregion
    }
}