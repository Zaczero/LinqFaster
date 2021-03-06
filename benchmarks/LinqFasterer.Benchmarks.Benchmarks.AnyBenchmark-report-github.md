``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|    Method |       N |      Mean |     Error |    StdDev | Ratio |
|---------- |-------- |----------:|----------:|----------:|------:|
|   **AnyLinq** |       **0** |  **8.296 ns** | **0.1117 ns** | **0.0665 ns** |  **1.00** |
| AnyFaster |       0 |  6.181 ns | 0.0565 ns | 0.0336 ns |  0.75 |
|           |         |           |           |           |       |
|   **AnyLinq** |       **1** | **17.213 ns** | **0.1824 ns** | **0.1086 ns** |  **1.00** |
| AnyFaster |       1 |  8.324 ns | 0.1340 ns | 0.0887 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |       **3** | **17.195 ns** | **0.1649 ns** | **0.0981 ns** |  **1.00** |
| AnyFaster |       3 |  8.270 ns | 0.1537 ns | 0.0915 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |       **5** | **17.355 ns** | **0.4742 ns** | **0.3136 ns** |  **1.00** |
| AnyFaster |       5 |  8.264 ns | 0.0656 ns | 0.0434 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |      **10** | **17.275 ns** | **0.2708 ns** | **0.1612 ns** |  **1.00** |
| AnyFaster |      10 |  8.262 ns | 0.1128 ns | 0.0671 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |      **50** | **17.205 ns** | **0.2431 ns** | **0.1608 ns** |  **1.00** |
| AnyFaster |      50 |  8.321 ns | 0.1507 ns | 0.0997 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |     **100** | **17.341 ns** | **0.3055 ns** | **0.2020 ns** |  **1.00** |
| AnyFaster |     100 |  8.270 ns | 0.1133 ns | 0.0674 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |     **250** | **17.316 ns** | **0.3653 ns** | **0.2417 ns** |  **1.00** |
| AnyFaster |     250 |  8.276 ns | 0.0747 ns | 0.0494 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |     **500** | **17.279 ns** | **0.2587 ns** | **0.1353 ns** |  **1.00** |
| AnyFaster |     500 |  8.216 ns | 0.1120 ns | 0.0667 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **1000** | **17.292 ns** | **0.3538 ns** | **0.2340 ns** |  **1.00** |
| AnyFaster |    1000 |  8.262 ns | 0.0519 ns | 0.0343 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **1500** | **16.533 ns** | **0.1563 ns** | **0.1034 ns** |  **1.00** |
| AnyFaster |    1500 |  8.020 ns | 0.0520 ns | 0.0344 ns |  0.49 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **2000** | **16.780 ns** | **0.1700 ns** | **0.1124 ns** |  **1.00** |
| AnyFaster |    2000 |  8.012 ns | 0.0432 ns | 0.0286 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **2500** | **16.793 ns** | **0.1988 ns** | **0.1315 ns** |  **1.00** |
| AnyFaster |    2500 |  7.971 ns | 0.1032 ns | 0.0683 ns |  0.47 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **3000** | **16.704 ns** | **0.1487 ns** | **0.0885 ns** |  **1.00** |
| AnyFaster |    3000 |  8.064 ns | 0.1363 ns | 0.0811 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |    **5000** | **16.772 ns** | **0.1452 ns** | **0.0960 ns** |  **1.00** |
| AnyFaster |    5000 |  8.039 ns | 0.0559 ns | 0.0370 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |   **10000** | **16.677 ns** | **0.2078 ns** | **0.1375 ns** |  **1.00** |
| AnyFaster |   10000 |  8.031 ns | 0.1025 ns | 0.0678 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |   **50000** | **16.485 ns** | **0.0961 ns** | **0.0572 ns** |  **1.00** |
| AnyFaster |   50000 |  8.024 ns | 0.0976 ns | 0.0645 ns |  0.49 |
|           |         |           |           |           |       |
|   **AnyLinq** |  **100000** | **16.518 ns** | **0.2637 ns** | **0.1745 ns** |  **1.00** |
| AnyFaster |  100000 |  7.981 ns | 0.0694 ns | 0.0413 ns |  0.48 |
|           |         |           |           |           |       |
|   **AnyLinq** |  **500000** | **16.546 ns** | **0.1860 ns** | **0.1230 ns** |  **1.00** |
| AnyFaster |  500000 |  8.025 ns | 0.0797 ns | 0.0527 ns |  0.49 |
|           |         |           |           |           |       |
|   **AnyLinq** | **1000000** | **16.445 ns** | **0.1155 ns** | **0.0764 ns** |  **1.00** |
| AnyFaster | 1000000 |  7.953 ns | 0.0396 ns | 0.0236 ns |  0.48 |
