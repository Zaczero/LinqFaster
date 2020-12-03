﻿using System;
using System.Collections.Generic;
using static JM.LinqFaster.Utils.CustomPartition;


namespace JM.LinqFaster.Parallel
{
    /// <summary>
    /// Provides Linq-style extension methods that for arrays and lists
    /// that use multiple Tasks / Threads.
    /// </summary>
    public static partial class LinqFasterParallel
    {

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinP<T>(this T[] source, int? batchSize = null)
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
            var min = default(T);
            if (min == null)
            {
                min = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] != null && comparer.Compare(source[i], threadMin) < 0) threadMin = source[i];
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin != null && comparer.Compare(threadMin,min) < 0)
                         {
                             min = threadMin;
                         }
                     }
                 });
            }
            else
            {
                min = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => min,
               (range, state, threadMin) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       if (comparer.Compare(source[i], threadMin) < 0) threadMin = source[i];
                   }
                   return threadMin;
               },
                threadMin =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMin, min) < 0)
                        {
                            min = threadMin;
                        }
                    }
                });
            }
            return min;            
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static TResult MinP<T,TResult>(this T[] source,Func<T,TResult> selector, int? batchSize = null)
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
            var min = default(TResult);
            if (min == null)
            {
                min = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s != null && comparer.Compare(s, threadMin) < 0) threadMin = s;
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin != null && comparer.Compare(threadMin, min) < 0)
                         {
                             min = threadMin;
                         }
                     }
                 });
            }
            else
            {
                min = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => min,
               (range, state, threadMin) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       var s = selector(source[i]);
                       if (comparer.Compare(s, threadMin) < 0) threadMin = s;
                   }
                   return threadMin;
               },
                threadMin =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMin, min) < 0)
                        {
                            min = threadMin;
                        }
                    }
                });
            }
            return min;


        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinP(this int[] source, int? batchSize = null)
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
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinP<T>(this T[] source, Func<T,int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinP(this long[] source, int? batchSize = null)
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
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinP<T>(this T[] source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinP(this float[] source, int? batchSize = null)
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
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinP<T>(this T[] source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinP(this double[] source, int? batchSize = null)
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
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinP<T>(this T[] source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinP(this decimal[] source, int? batchSize = null)
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
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinP<T>(this T[] source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Length, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }


        // ------------------------------ Lists ------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinP<T>(this List<T> source, int? batchSize = null)
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
            var min = default(T);
            if (min == null)
            {
                min = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] != null && comparer.Compare(source[i], threadMin) < 0) threadMin = source[i];
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin != null && comparer.Compare(threadMin, min) < 0)
                         {
                             min = threadMin;
                         }
                     }
                 });
            }
            else
            {
                min = source[0];
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => min,
               (range, state, threadMin) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       if (comparer.Compare(source[i], threadMin) < 0) threadMin = source[i];
                   }
                   return threadMin;
               },
                threadMin =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMin, min) < 0)
                        {
                            min = threadMin;
                        }
                    }
                });
            }
            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static TResult MinP<T, TResult>(this List<T> source, Func<T, TResult> selector, int? batchSize = null)
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
            var min = default(TResult);
            if (min == null)
            {
                min = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s != null && comparer.Compare(s, threadMin) < 0) threadMin = s;
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin != null && comparer.Compare(threadMin, min) < 0)
                         {
                             min = threadMin;
                         }
                     }
                 });
            }
            else
            {
                min = selector(source[0]);
                System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
               () => min,
               (range, state, threadMin) =>
               {
                   for (var i = range.Item1; i < range.Item2; i++)
                   {
                       var s = selector(source[i]);
                       if (comparer.Compare(s, threadMin) < 0) threadMin = s;
                   }
                   return threadMin;
               },
                threadMin =>
                {
                    lock (LOCK)
                    {
                        if (comparer.Compare(threadMin, min) < 0)
                        {
                            min = threadMin;
                        }
                    }
                });
            }
            return min;


        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinP(this List<int> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinP<T>(this List<T> source, Func<T, int> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinP(this List<long> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinP<T>(this List<T> source, Func<T, long> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinP(this List<float> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinP<T>(this List<T> source, Func<T, float> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinP(this List<double> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinP<T>(this List<T> source, Func<T, double> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinP(this List<decimal> source, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = source[0];
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        if (source[i] < threadMin)
                        {
                            threadMin = source[i];
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }

        /// <summary>
        /// Returns the minimum value via the selector in a sequence of values using multiple Tasks / Threads.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <param name="selector">A function to transform elements into a value that will be compared.</param>
        /// <param name="batchSize">Optional. Specify a batch size for Tasks to operate over. </param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinP<T>(this List<T> source, Func<T, decimal> selector, int? batchSize = null)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }

            var min = selector(source[0]);
            var LOCK = new object();
            var rangePartitioner = MakePartition(source.Count, batchSize);
            System.Threading.Tasks.Parallel.ForEach(rangePartitioner,
                () => min,
                (range, state, threadMin) =>
                {
                    for (var i = range.Item1; i < range.Item2; i++)
                    {
                        var s = selector(source[i]);
                        if (s < threadMin)
                        {
                            threadMin = s;
                        }
                    }
                    return threadMin;
                },
                 threadMin =>
                 {
                     lock (LOCK)
                     {
                         if (threadMin < min)
                         {
                             min = threadMin;
                         }
                     }
                 });

            return min;
        }


    }
}
