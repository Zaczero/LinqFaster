﻿using System;
using System.Collections.Generic;
using static JM.LinqFaster.Utils.CustomPartition;


namespace JM.LinqFaster.Parallel
{
    public static partial class LinqFasterParallel
    {

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static T MaxP<T>(this T[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            var comparer = Comparer<T>.Default;
            var Max = default(T);
            if (Max == null)
            {
                Max = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] != null && comparer.Compare(source[i], threadMax) > 0) threadMax = source[i];
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax != null && comparer.Compare(threadMax,Max) > 0)
                         {
                             Max = threadMax;
                         }
                     }
                 });
            }
            else
            {
                Max = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => Max,
               (range, state, threadMax) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       if (comparer.Compare(source[i], threadMax) > 0) threadMax = source[i];
                   }
                   return threadMax;
               },
                threadMax =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMax, Max) > 0)
                        {
                            Max = threadMax;
                        }
                    }
                });
            }
            return Max;            
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static TResult MaxP<T,TResult>(this T[] source,Func<T,TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            var comparer = Comparer<TResult>.Default;
            var Max = default(TResult);
            if (Max == null)
            {
                Max = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s != null && comparer.Compare(s, threadMax) > 0) threadMax = s;
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax != null && comparer.Compare(threadMax, Max) > 0)
                         {
                             Max = threadMax;
                         }
                     }
                 });
            }
            else
            {
                Max = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => Max,
               (range, state, threadMax) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       var s = selector(source[i]);
                       if (comparer.Compare(s, threadMax) > 0) threadMax = s;
                   }
                   return threadMax;
               },
                threadMax =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMax, Max) > 0)
                        {
                            Max = threadMax;
                        }
                    }
                });
            }
            return Max;


        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static int MaxP(this int[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static int MaxP<T>(this T[] source, Func<T,int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static long MaxP(this long[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static long MaxP<T>(this T[] source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static float MaxP(this float[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static float MaxP<T>(this T[] source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static double MaxP(this double[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static double MaxP<T>(this T[] source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static decimal MaxP(this decimal[] source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static decimal MaxP<T>(this T[] source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }


        // ------------------------------ Lists ------------------------------------------

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static T MaxP<T>(this List<T> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            var comparer = Comparer<T>.Default;
            var Max = default(T);
            if (Max == null)
            {
                Max = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] != null && comparer.Compare(source[i], threadMax) > 0) threadMax = source[i];
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax != null && comparer.Compare(threadMax, Max) > 0)
                         {
                             Max = threadMax;
                         }
                     }
                 });
            }
            else
            {
                Max = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => Max,
               (range, state, threadMax) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       if (comparer.Compare(source[i], threadMax) > 0) threadMax = source[i];
                   }
                   return threadMax;
               },
                threadMax =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMax, Max) > 0)
                        {
                            Max = threadMax;
                        }
                    }
                });
            }
            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static TResult MaxP<T, TResult>(this List<T> source, Func<T, TResult> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            var comparer = Comparer<TResult>.Default;
            var Max = default(TResult);
            if (Max == null)
            {
                Max = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s != null && comparer.Compare(s, threadMax) > 0) threadMax = s;
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax != null && comparer.Compare(threadMax, Max) > 0)
                         {
                             Max = threadMax;
                         }
                     }
                 });
            }
            else
            {
                Max = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => Max,
               (range, state, threadMax) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       var s = selector(source[i]);
                       if (comparer.Compare(s, threadMax) > 0) threadMax = s;
                   }
                   return threadMax;
               },
                threadMax =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMax, Max) > 0)
                        {
                            Max = threadMax;
                        }
                    }
                });
            }
            return Max;


        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static int MaxP(this List<int> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static int MaxP<T>(this List<T> source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static long MaxP(this List<long> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static long MaxP<T>(this List<T> source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static float MaxP(this List<float> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static float MaxP<T>(this List<T> source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static double MaxP(this List<double> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static double MaxP<T>(this List<T> source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static decimal MaxP(this List<decimal> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] > threadMax)
                        {
                            threadMax = source[i];
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }

        /// <summary>
        /// Returns the Maximum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the Maximum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The Maximum value in the sequence</returns>
        public static decimal MaxP<T>(this List<T> source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var Max = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => Max,
                (range, state, threadMax) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s > threadMax)
                        {
                            threadMax = s;
                        }
                    }
                    return threadMax;
                },
                 threadMax =>
                 {
                     lock (LOCK)
                     {
                         if (threadMax > Max)
                         {
                             Max = threadMax;
                         }
                     }
                 });

            return Max;
        }


    }
}
