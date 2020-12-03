﻿using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {
        /// <summary>
        /// Finds the maximum value the sequence using SIMD
        /// </summary>        
        /// <param name="source">A sequence of primitive values</param>
        /// <returns>The maximum value in the sequence</returns>
        public static T MaxS<T> (this T[] source)
            where T : struct
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var max = source[0];
            var count = Vector<T>.Count;
            if (count <= source.Length)
            {
                var vMax = new Vector<T>(source, 0);
                for (var i = count; i <= source.Length-count; i+=count)
                {
                    var v = new Vector<T>(source, i);
                    vMax = Vector.Max(v, vMax);                         
                }

                max = vMax[0];
                for (var i = 1; i < count; i++)
                {
                    if (GreaterThan(vMax[i], max)) max = vMax[i];
                }
            }

            for (var i = source.Length-source.Length%count; i < source.Length;i++)
            {
                if (GreaterThan(source[i],max)) max = source[i];
            }
            return max;
        }
    }
}
