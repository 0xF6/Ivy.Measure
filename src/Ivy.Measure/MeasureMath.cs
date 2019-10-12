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

        public const float Zero = 0.0f;
        public const float One = 1.0f;
        public const float Two = 2.0f;
        public const float Half = 0.5f;

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
    }
}