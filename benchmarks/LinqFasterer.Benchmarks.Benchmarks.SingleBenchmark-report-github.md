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
|   **SingleLinq** |       **0** |              **NA** |            **NA** |            **NA** |     **?** |       **?** |
| SingleFaster |       0 |              NA |            NA |            NA |     ? |       ? |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |       **1** |        **18.54 ns** |      **0.208 ns** |      **0.138 ns** |  **1.00** |    **0.00** |
| SingleFaster |       1 |        10.47 ns |      0.080 ns |      0.042 ns |  0.57 |    0.01 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |       **3** |        **28.65 ns** |      **0.448 ns** |      **0.296 ns** |  **1.00** |    **0.00** |
| SingleFaster |       3 |        14.10 ns |      0.133 ns |      0.079 ns |  0.49 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |       **5** |        **39.13 ns** |      **0.309 ns** |      **0.205 ns** |  **1.00** |    **0.00** |
| SingleFaster |       5 |        17.76 ns |      0.152 ns |      0.101 ns |  0.45 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |      **10** |        **71.32 ns** |      **0.282 ns** |      **0.168 ns** |  **1.00** |    **0.00** |
| SingleFaster |      10 |        27.35 ns |      0.182 ns |      0.121 ns |  0.38 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |      **50** |       **281.77 ns** |      **3.574 ns** |      **2.127 ns** |  **1.00** |    **0.00** |
| SingleFaster |      50 |       109.56 ns |      0.694 ns |      0.413 ns |  0.39 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |     **100** |       **538.87 ns** |      **4.405 ns** |      **2.913 ns** |  **1.00** |    **0.00** |
| SingleFaster |     100 |       193.49 ns |      1.630 ns |      0.852 ns |  0.36 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |     **250** |     **1,303.48 ns** |     **10.301 ns** |      **6.813 ns** |  **1.00** |    **0.00** |
| SingleFaster |     250 |       449.01 ns |      4.073 ns |      2.694 ns |  0.34 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |     **500** |     **2,579.45 ns** |     **19.347 ns** |     **11.513 ns** |  **1.00** |    **0.00** |
| SingleFaster |     500 |       872.45 ns |      5.816 ns |      3.461 ns |  0.34 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **1000** |     **5,114.61 ns** |     **14.693 ns** |      **9.719 ns** |  **1.00** |    **0.00** |
| SingleFaster |    1000 |     1,718.33 ns |     11.890 ns |      7.865 ns |  0.34 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **1500** |     **7,698.02 ns** |     **73.714 ns** |     **48.757 ns** |  **1.00** |    **0.00** |
| SingleFaster |    1500 |     2,575.61 ns |     13.932 ns |      9.215 ns |  0.33 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **2000** |    **10,683.62 ns** |    **102.056 ns** |     **67.504 ns** |  **1.00** |    **0.00** |
| SingleFaster |    2000 |     3,409.19 ns |     40.920 ns |     27.066 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **2500** |    **13,430.53 ns** |    **121.248 ns** |     **80.198 ns** |  **1.00** |    **0.00** |
| SingleFaster |    2500 |     4,287.07 ns |     61.355 ns |     40.583 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **3000** |    **16,018.07 ns** |    **199.301 ns** |    **131.825 ns** |  **1.00** |    **0.00** |
| SingleFaster |    3000 |     5,113.55 ns |     43.011 ns |     28.449 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |    **5000** |    **26,870.57 ns** |    **244.152 ns** |    **161.491 ns** |  **1.00** |    **0.00** |
| SingleFaster |    5000 |     8,520.55 ns |     70.543 ns |     41.979 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |   **10000** |    **53,438.26 ns** |    **548.235 ns** |    **362.624 ns** |  **1.00** |    **0.00** |
| SingleFaster |   10000 |    17,023.57 ns |    241.272 ns |    143.577 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |   **50000** |   **267,070.03 ns** |  **2,773.805 ns** |  **1,834.700 ns** |  **1.00** |    **0.00** |
| SingleFaster |   50000 |    85,304.45 ns |    653.559 ns |    432.289 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |  **100000** |   **536,663.50 ns** |  **3,616.510 ns** |  **2,152.127 ns** |  **1.00** |    **0.00** |
| SingleFaster |  100000 |   170,280.62 ns |  1,051.506 ns |    695.506 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** |  **500000** | **2,675,737.33 ns** | **12,164.380 ns** |  **7,238.827 ns** |  **1.00** |    **0.00** |
| SingleFaster |  500000 |   854,390.60 ns |  4,680.627 ns |  3,095.945 ns |  0.32 |    0.00 |
|              |         |                 |               |               |       |         |
|   **SingleLinq** | **1000000** | **5,340,673.91 ns** | **34,716.143 ns** | **22,962.579 ns** |  **1.00** |    **0.00** |
| SingleFaster | 1000000 | 1,715,180.71 ns | 15,441.423 ns |  9,188.943 ns |  0.32 |    0.00 |

Benchmarks with issues:
  SingleBenchmark.SingleLinq: Job-VDQUHN(IterationCount=10, LaunchCount=1, WarmupCount=2) [N=0]
  SingleBenchmark.SingleFaster: Job-VDQUHN(IterationCount=10, LaunchCount=1, WarmupCount=2) [N=0]
