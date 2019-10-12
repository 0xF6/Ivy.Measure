namespace Ivy.Measure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;

    [PublicAPI]
    public static class MeasureMath
    {
        #region Const

        public static readonly float Zero = 0.0f;
        public static readonly float One = 1.0f;
        public static readonly float Two = 2.0f;
        public static readonly float Half = 0.5f;

        internal static readonly float HardwareInaccuracy;

        #endregion

        static MeasureMath()
        {
            HardwareInaccuracy = One;
            do
            {
                HardwareInaccuracy *= Half;
            }
            while (One + Half * HardwareInaccuracy != One);
        }



        public static IEnumerable<int> PrimeInt32
        {
            get
            {
                static IEnumerable<int> odds()
                {
                    var start = 1;
                    while (start > 0)
                        yield return unchecked(start += 2);
                }

                yield return 2;

                foreach (var i in odds())
                {
                    var value = Math.Sqrt(i);
                    if (odds().TakeWhile(y => y <= value).All(y => i % y != 0))
                        yield return i;
                }
            }
        }

        #region Factors
        public static readonly float SecondsPerMinute = 60.0f;
        public static readonly float SecondsPerHour = SecondsPerMinute * 60.0f;
        public static readonly float SecondsPerDay = SecondsPerHour * 24.0f;
        public static readonly float SecondsPerWeek = SecondsPerDay * 7.0f;
        public static readonly float SecondsPerJulianYear = SecondsPerDay * 365.25f;
        public static readonly float KelvinCelsiusIntercept = 273.15f;
        public static readonly float KelvinFahrenheitIntercept = 459.67f;
        public static readonly float KelvinFahrenheitSlope = 5.0f / 9.0f;
        public static readonly float CoulombsPerElementaryCharge = 1.6021765314e-19f;
        public static readonly float JoulesPerElectronVolt = CoulombsPerElementaryCharge;
        public static readonly float MetersPerAngstrom = 1.0e-10f;
        public static readonly float MetersPerInch = 0.0254f;
        public static readonly float MetersPerFoot = MetersPerInch * 12.0f;
        public static readonly float MetersPerYard = MetersPerFoot * 3.0f;
        public static readonly float MetersPerMile = MetersPerYard * 1760.0f;
        public static readonly float MetersPerNauticalMile = 1852.0f;
        public static readonly float SquareMetersPerBarn = 1.0e-28f;
        public static readonly float CubicMetersPerUSLiquidGallon = 3.78541178e-3f;
        public static readonly float KiloGramsPerElectronMass = 9.109382616e-31f;
        public static readonly float KiloGramsPerAtomicMassUnit = 1.6605388628e-27f;
        public static readonly float BecquerelPerCurie = 3.7e10f;

        public static readonly float RPD = MathF.PI / 180.0f;
        public static readonly float RPM = RPD / 60.0f;
        public static readonly float RPS = RPM / 60.0f;

        public static float Square(float a) { return a * a; }
        public static float Cube(float a) { return a * a * a; }

        #endregion
    }
}