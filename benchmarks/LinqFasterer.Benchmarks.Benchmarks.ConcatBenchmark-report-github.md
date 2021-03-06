``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|       Method |       N |            Mean |         Error |        StdDev | Ratio | RatioSD |
|------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
|   **ConcatLinq** |       **0** |        **61.90 ns** |      **1.397 ns** |      **0.924 ns** |  **1.00** |    **0.00** |
| ConcatFaster |       0 |        31.07 ns |      0.535 ns |      0.354 ns |  0.50 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |       **1** |       **121.70 ns** |      **0.656 ns** |      **0.390 ns** |  **1.00** |    **0.00** |
| ConcatFaster |       1 |        31.29 ns |      0.174 ns |      0.115 ns |  0.26 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |       **3** |       **120.05 ns** |      **0.297 ns** |      **0.197 ns** |  **1.00** |    **0.00** |
| ConcatFaster |       3 |        30.41 ns |      0.446 ns |      0.295 ns |  0.25 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |       **5** |       **120.84 ns** |      **0.650 ns** |      **0.430 ns** |  **1.00** |    **0.00** |
| ConcatFaster |       5 |        31.35 ns |      0.837 ns |      0.554 ns |  0.26 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |      **10** |       **122.04 ns** |      **1.053 ns** |      **0.696 ns** |  **1.00** |    **0.00** |
| ConcatFaster |      10 |        32.40 ns |      0.445 ns |      0.294 ns |  0.27 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |      **50** |       **142.84 ns** |      **0.983 ns** |      **0.585 ns** |  **1.00** |    **0.00** |
| ConcatFaster |      50 |        46.49 ns |      0.252 ns |      0.150 ns |  0.33 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |     **100** |       **160.05 ns** |      **0.951 ns** |      **0.629 ns** |  **1.00** |    **0.00** |
| ConcatFaster |     100 |        62.45 ns |      0.435 ns |      0.259 ns |  0.39 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |     **250** |       **216.22 ns** |      **1.635 ns** |      **0.973 ns** |  **1.00** |    **0.00** |
| ConcatFaster |     250 |       125.70 ns |      0.636 ns |      0.379 ns |  0.58 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |     **500** |       **334.18 ns** |      **4.589 ns** |      **3.035 ns** |  **1.00** |    **0.00** |
| ConcatFaster |     500 |       239.23 ns |      2.137 ns |      1.118 ns |  0.72 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **1000** |       **525.88 ns** |      **3.732 ns** |      **2.221 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    1000 |       436.54 ns |      6.853 ns |      4.533 ns |  0.83 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **1500** |       **744.71 ns** |      **8.838 ns** |      **5.259 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    1500 |       610.33 ns |      7.565 ns |      4.502 ns |  0.82 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **2000** |       **940.02 ns** |      **6.893 ns** |      **4.102 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    2000 |       800.15 ns |     11.340 ns |      6.748 ns |  0.85 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **2500** |     **1,129.66 ns** |     **13.123 ns** |      **7.809 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    2500 |       983.55 ns |      4.139 ns |      2.463 ns |  0.87 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **3000** |     **1,335.50 ns** |     **18.387 ns** |     **10.942 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    3000 |     1,194.08 ns |     11.002 ns |      6.547 ns |  0.89 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |    **5000** |     **2,083.80 ns** |     **27.321 ns** |     **16.258 ns** |  **1.00** |    **0.00** |
| ConcatFaster |    5000 |     1,982.68 ns |     25.971 ns |     15.455 ns |  0.95 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |   **10000** |     **3,995.45 ns** |     **52.018 ns** |     **34.407 ns** |  **1.00** |    **0.00** |
| ConcatFaster |   10000 |     3,847.47 ns |     29.448 ns |     15.402 ns |  0.96 |    0.00 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |   **50000** |    **24,016.15 ns** |    **298.120 ns** |    **197.188 ns** |  **1.00** |    **0.00** |
| ConcatFaster |   50000 |    24,877.99 ns |    317.467 ns |    209.985 ns |  1.04 |    0.01 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |  **100000** |    **98,176.87 ns** | **14,371.541 ns** |  **9,505.885 ns** |  **1.00** |    **0.00** |
| ConcatFaster |  100000 |    86,076.49 ns |  1,668.585 ns |    872.702 ns |  0.89 |    0.10 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** |  **500000** |   **767,324.24 ns** | **50,730.227 ns** | **33,554.904 ns** |  **1.00** |    **0.00** |
| ConcatFaster |  500000 |   761,794.36 ns | 46,487.344 ns | 30,748.500 ns |  1.00 |    0.08 |
|              |         |                 |               |               |       |         |
|   **ConcatLinq** | **1000000** | **1,629,260.53 ns** | **45,494.123 ns** | **30,091.546 ns** |  **1.00** |    **0.00** |
| ConcatFaster | 1000000 | 1,627,544.80 ns | 31,190.748 ns | 20,630.749 ns |  1.00 |    0.01 |
