﻿using System.Numerics;
using static JM.LinqFaster.Utils.GenericOperators;

namespace JM.LinqFaster.SIMD
{

    public static partial class LinqFasterSIMD
    {

        /// <summary>
        /// Finds the minimum value in a sequence using SIMD.
        /// </summary>        
        /// <param name="source">A sequence of primitive values</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinS<T> (this T[] source)
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

            var min = source[0];
            var count = Vector<T>.Count;
            if (count <= source.Length)
            {
                var vMin = new Vector<T>(source, 0);
                for (var i = count; i <= source.Length-count; i+=count)
                {
                    var v = new Vector<T>(source, i);
                    vMin = Vector.Min(v, vMin);
                }

                min = vMin[0];
                for (var i = 1; i < count; i++)
                {
                    if (LessThan(vMin[i], min)) min = vMin[i];
                }
            }

            for (var i = source.Length-source.Length%count; i < source.Length;i++)
            {
                if (LessThan(source[i],min)) min = source[i];
            }
            return min;
        }
    }
}
