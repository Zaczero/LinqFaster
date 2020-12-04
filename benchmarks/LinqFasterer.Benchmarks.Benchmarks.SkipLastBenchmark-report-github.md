``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|         Method |       N |             Mean |           Error |          StdDev | Ratio | RatioSD |
|--------------- |-------- |-----------------:|----------------:|----------------:|------:|--------:|
|   **SkipLastLinq** |       **0** |        **20.308 ns** |       **0.1460 ns** |       **0.0869 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |       0 |         6.532 ns |       0.0546 ns |       0.0361 ns |  0.32 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |       **1** |        **21.685 ns** |       **0.1828 ns** |       **0.1209 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |       1 |         6.485 ns |       0.0925 ns |       0.0612 ns |  0.30 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |       **3** |        **20.449 ns** |       **0.0416 ns** |       **0.0217 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |       3 |         6.491 ns |       0.0916 ns |       0.0606 ns |  0.32 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |       **5** |        **22.169 ns** |       **0.1719 ns** |       **0.1137 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |       5 |         6.518 ns |       0.0445 ns |       0.0294 ns |  0.29 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |      **10** |        **65.166 ns** |       **2.9666 ns** |       **1.9623 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |      10 |        24.131 ns |       0.2158 ns |       0.1284 ns |  0.37 |    0.01 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |      **50** |       **165.111 ns** |       **0.8539 ns** |       **0.5082 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |      50 |        30.859 ns |       0.3984 ns |       0.2371 ns |  0.19 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |     **100** |       **283.035 ns** |       **0.8543 ns** |       **0.5084 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |     100 |        38.688 ns |       0.2724 ns |       0.1621 ns |  0.14 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |     **250** |       **633.500 ns** |       **3.5397 ns** |       **2.3413 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |     250 |        65.959 ns |       0.6104 ns |       0.4038 ns |  0.10 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |     **500** |     **1,215.800 ns** |      **10.2027 ns** |       **6.7484 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |     500 |       121.480 ns |       0.8862 ns |       0.5274 ns |  0.10 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **1000** |     **2,389.335 ns** |      **20.3976 ns** |      **13.4917 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    1000 |       225.327 ns |       0.8517 ns |       0.5068 ns |  0.09 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **1500** |     **3,547.712 ns** |      **23.8203 ns** |      **15.7556 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    1500 |       328.791 ns |       3.5865 ns |       2.1342 ns |  0.09 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **2000** |     **4,727.714 ns** |      **29.1634 ns** |      **19.2898 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    2000 |       424.585 ns |       4.7348 ns |       2.8176 ns |  0.09 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **2500** |     **5,872.766 ns** |      **24.6518 ns** |      **14.6699 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    2500 |       489.558 ns |       4.8234 ns |       2.5228 ns |  0.08 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **3000** |     **7,036.811 ns** |      **27.9764 ns** |      **18.5046 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    3000 |       589.555 ns |      37.4345 ns |      24.7606 ns |  0.08 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |    **5000** |    **11,636.130 ns** |      **69.2681 ns** |      **36.2285 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |    5000 |       913.970 ns |      10.5563 ns |       5.5211 ns |  0.08 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |   **10000** |    **23,362.396 ns** |     **201.6192 ns** |     **133.3586 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |   10000 |     2,040.393 ns |     151.4615 ns |     100.1824 ns |  0.09 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |   **50000** |   **117,744.677 ns** |     **874.1221 ns** |     **578.1776 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |   50000 |    12,284.629 ns |     209.0895 ns |     138.2998 ns |  0.10 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |  **100000** |   **254,557.988 ns** |   **2,297.4739 ns** |   **1,519.6367 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |  100000 |    44,480.200 ns |     719.0355 ns |     475.5975 ns |  0.17 |    0.00 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** |  **500000** | **1,526,304.570 ns** |  **68,328.1758 ns** |  **45,194.8577 ns** |  **1.00** |    **0.00** |
| SkipLastFaster |  500000 |   554,045.078 ns |   8,346.0995 ns |   5,520.4281 ns |  0.36 |    0.01 |
|                |         |                  |                 |                 |       |         |
|   **SkipLastLinq** | **1000000** | **3,065,291.758 ns** | **284,281.9059 ns** | **188,034.8791 ns** |  **1.00** |    **0.00** |
| SkipLastFaster | 1000000 | 1,512,713.516 ns |  46,878.7422 ns |  31,007.3854 ns |  0.50 |    0.04 |