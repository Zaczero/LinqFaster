``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|    Method |       N |             Mean |          Error |         StdDev | Ratio | RatioSD |
|---------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
|   **ZipLinq** |       **0** |         **69.47 ns** |       **0.756 ns** |       **0.500 ns** |  **1.00** |    **0.00** |
| ZipFaster |       0 |         14.82 ns |       0.669 ns |       0.443 ns |  0.21 |    0.01 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |       **1** |        **135.17 ns** |       **0.885 ns** |       **0.586 ns** |  **1.00** |    **0.00** |
| ZipFaster |       1 |         15.04 ns |       0.950 ns |       0.628 ns |  0.11 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |       **3** |        **162.01 ns** |       **2.145 ns** |       **1.419 ns** |  **1.00** |    **0.00** |
| ZipFaster |       3 |         16.30 ns |       0.185 ns |       0.123 ns |  0.10 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |       **5** |        **209.62 ns** |       **2.318 ns** |       **1.533 ns** |  **1.00** |    **0.00** |
| ZipFaster |       5 |         17.60 ns |       0.150 ns |       0.099 ns |  0.08 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |      **10** |        **329.36 ns** |       **1.635 ns** |       **0.973 ns** |  **1.00** |    **0.00** |
| ZipFaster |      10 |         21.46 ns |       0.154 ns |       0.092 ns |  0.07 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |      **50** |        **995.01 ns** |       **5.641 ns** |       **3.731 ns** |  **1.00** |    **0.00** |
| ZipFaster |      50 |         67.31 ns |       0.935 ns |       0.618 ns |  0.07 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |     **100** |      **1,691.31 ns** |       **9.507 ns** |       **5.657 ns** |  **1.00** |    **0.00** |
| ZipFaster |     100 |        110.97 ns |       1.220 ns |       0.726 ns |  0.07 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |     **250** |      **3,769.40 ns** |      **18.854 ns** |      **12.471 ns** |  **1.00** |    **0.00** |
| ZipFaster |     250 |        242.71 ns |       4.309 ns |       2.850 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |     **500** |      **7,226.31 ns** |      **84.410 ns** |      **55.832 ns** |  **1.00** |    **0.00** |
| ZipFaster |     500 |        464.66 ns |       2.739 ns |       1.630 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **1000** |     **14,084.78 ns** |      **99.905 ns** |      **59.452 ns** |  **1.00** |    **0.00** |
| ZipFaster |    1000 |        891.80 ns |       8.817 ns |       4.611 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **1500** |     **21,044.16 ns** |     **232.300 ns** |     **138.238 ns** |  **1.00** |    **0.00** |
| ZipFaster |    1500 |      1,311.10 ns |      13.083 ns |       7.785 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **2000** |     **27,717.49 ns** |     **201.739 ns** |     **133.438 ns** |  **1.00** |    **0.00** |
| ZipFaster |    2000 |      1,715.36 ns |      10.459 ns |       6.224 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **2500** |     **34,831.32 ns** |     **371.074 ns** |     **245.442 ns** |  **1.00** |    **0.00** |
| ZipFaster |    2500 |      2,117.10 ns |      25.494 ns |      15.171 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **3000** |     **41,551.53 ns** |     **386.447 ns** |     **255.611 ns** |  **1.00** |    **0.00** |
| ZipFaster |    3000 |      2,533.27 ns |      23.135 ns |      13.767 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |    **5000** |     **69,002.33 ns** |     **873.882 ns** |     **520.033 ns** |  **1.00** |    **0.00** |
| ZipFaster |    5000 |      4,171.61 ns |      61.161 ns |      36.396 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |   **10000** |    **139,103.49 ns** |   **1,852.929 ns** |   **1,225.598 ns** |  **1.00** |    **0.00** |
| ZipFaster |   10000 |      8,273.04 ns |     139.591 ns |      83.068 ns |  0.06 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |   **50000** |    **704,320.52 ns** |   **2,898.764 ns** |   **1,516.110 ns** |  **1.00** |    **0.00** |
| ZipFaster |   50000 |     46,149.08 ns |     418.755 ns |     276.980 ns |  0.07 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |  **100000** |  **1,481,582.01 ns** |   **9,068.369 ns** |   **5,998.164 ns** |  **1.00** |    **0.00** |
| ZipFaster |  100000 |    149,757.25 ns |   6,491.124 ns |   4,293.476 ns |  0.10 |    0.00 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** |  **500000** |  **7,706,427.34 ns** |  **91,865.439 ns** |  **60,763.300 ns** |  **1.00** |    **0.00** |
| ZipFaster |  500000 |  2,120,184.06 ns | 288,162.851 ns | 190,601.884 ns |  0.28 |    0.03 |
|           |         |                  |                |                |       |         |
|   **ZipLinq** | **1000000** | **17,585,188.89 ns** | **295,103.767 ns** | **175,611.518 ns** |  **1.00** |    **0.00** |
| ZipFaster | 1000000 |  3,291,839.34 ns | 147,152.961 ns |  97,332.573 ns |  0.19 |    0.01 |