``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|        Method |       N |              Mean |            Error |         StdDev | Ratio |
|-------------- |-------- |------------------:|-----------------:|---------------:|------:|
|   **OrderByLinq** |       **0** |          **42.10 ns** |         **0.682 ns** |       **0.451 ns** |  **1.00** |
| OrderByFaster |       0 |          13.64 ns |         0.199 ns |       0.119 ns |  0.32 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |       **1** |         **105.97 ns** |         **0.760 ns** |       **0.503 ns** |  **1.00** |
| OrderByFaster |       1 |          15.69 ns |         0.235 ns |       0.140 ns |  0.15 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |       **3** |         **145.47 ns** |         **1.245 ns** |       **0.741 ns** |  **1.00** |
| OrderByFaster |       3 |          36.31 ns |         0.240 ns |       0.159 ns |  0.25 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |       **5** |         **191.13 ns** |         **3.064 ns** |       **1.823 ns** |  **1.00** |
| OrderByFaster |       5 |          49.33 ns |         0.275 ns |       0.182 ns |  0.26 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |      **10** |         **397.44 ns** |         **4.928 ns** |       **3.260 ns** |  **1.00** |
| OrderByFaster |      10 |          68.75 ns |         0.464 ns |       0.276 ns |  0.17 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |      **50** |       **2,402.31 ns** |        **17.827 ns** |      **11.791 ns** |  **1.00** |
| OrderByFaster |      50 |         274.34 ns |         2.487 ns |       1.480 ns |  0.11 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |     **100** |       **5,578.83 ns** |        **35.013 ns** |      **23.159 ns** |  **1.00** |
| OrderByFaster |     100 |         771.18 ns |         6.669 ns |       4.411 ns |  0.14 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |     **250** |      **17,513.77 ns** |        **98.570 ns** |      **65.198 ns** |  **1.00** |
| OrderByFaster |     250 |       2,057.48 ns |        11.844 ns |       7.834 ns |  0.12 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |     **500** |      **39,568.21 ns** |       **236.124 ns** |     **140.514 ns** |  **1.00** |
| OrderByFaster |     500 |       4,254.78 ns |        20.144 ns |      13.324 ns |  0.11 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **1000** |      **91,037.91 ns** |       **546.676 ns** |     **361.592 ns** |  **1.00** |
| OrderByFaster |    1000 |       9,902.36 ns |        44.333 ns |      29.324 ns |  0.11 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **1500** |     **145,532.17 ns** |       **940.541 ns** |     **622.109 ns** |  **1.00** |
| OrderByFaster |    1500 |      18,284.92 ns |       160.185 ns |     105.952 ns |  0.13 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **2000** |     **203,779.04 ns** |       **641.943 ns** |     **335.749 ns** |  **1.00** |
| OrderByFaster |    2000 |      23,464.09 ns |       145.128 ns |      95.993 ns |  0.12 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **2500** |     **262,238.85 ns** |     **1,087.273 ns** |     **719.164 ns** |  **1.00** |
| OrderByFaster |    2500 |      33,827.52 ns |       167.935 ns |     111.078 ns |  0.13 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **3000** |     **331,391.69 ns** |     **2,374.855 ns** |   **1,570.819 ns** |  **1.00** |
| OrderByFaster |    3000 |      41,468.66 ns |       170.780 ns |     112.960 ns |  0.13 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |    **5000** |     **583,334.44 ns** |     **4,239.321 ns** |   **2,522.752 ns** |  **1.00** |
| OrderByFaster |    5000 |      70,660.20 ns |       366.190 ns |     242.212 ns |  0.12 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |   **10000** |   **1,279,662.98 ns** |     **5,462.557 ns** |   **3,250.680 ns** |  **1.00** |
| OrderByFaster |   10000 |     150,517.20 ns |       675.808 ns |     447.005 ns |  0.12 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |   **50000** |   **7,468,704.53 ns** |    **43,348.193 ns** |  **28,672.146 ns** |  **1.00** |
| OrderByFaster |   50000 |     760,998.68 ns |     4,260.337 ns |   2,817.949 ns |  0.10 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |  **100000** |  **15,976,703.91 ns** |    **96,298.455 ns** |  **50,365.954 ns** |  **1.00** |
| OrderByFaster |  100000 |   1,608,643.93 ns |     5,971.597 ns |   3,949.842 ns |  0.10 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** |  **500000** |  **94,553,826.67 ns** |   **817,315.725 ns** | **540,603.747 ns** |  **1.00** |
| OrderByFaster |  500000 |   7,354,061.72 ns |    58,806.635 ns |  38,896.948 ns |  0.08 |
|               |         |                   |                  |                |       |
|   **OrderByLinq** | **1000000** | **190,028,711.11 ns** | **1,312,394.830 ns** | **780,985.112 ns** |  **1.00** |
| OrderByFaster | 1000000 |  15,643,515.47 ns |    74,579.742 ns |  49,329.882 ns |  0.08 |