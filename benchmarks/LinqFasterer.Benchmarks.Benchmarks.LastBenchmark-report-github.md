``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-VDQUHN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=2  

```
|     Method |       N |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------- |-------- |----------:|----------:|----------:|------:|--------:|
|   **LastLinq** |       **0** |        **NA** |        **NA** |        **NA** |     **?** |       **?** |
| LastFaster |       0 |        NA |        NA |        NA |     ? |       ? |
|            |         |           |           |           |       |         |
|   **LastLinq** |       **1** | **24.812 ns** | **0.5329 ns** | **0.3171 ns** |  **1.00** |    **0.00** |
| LastFaster |       1 |  4.230 ns | 0.0586 ns | 0.0306 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |       **3** | **24.978 ns** | **0.2455 ns** | **0.1624 ns** |  **1.00** |    **0.00** |
| LastFaster |       3 |  4.250 ns | 0.0596 ns | 0.0394 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |       **5** | **26.508 ns** | **0.5111 ns** | **0.3381 ns** |  **1.00** |    **0.00** |
| LastFaster |       5 |  4.317 ns | 0.0535 ns | 0.0354 ns |  0.16 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |      **10** | **24.979 ns** | **0.5996 ns** | **0.3966 ns** |  **1.00** |    **0.00** |
| LastFaster |      10 |  4.208 ns | 0.0499 ns | 0.0330 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |      **50** | **24.164 ns** | **0.2698 ns** | **0.1784 ns** |  **1.00** |    **0.00** |
| LastFaster |      50 |  4.228 ns | 0.0598 ns | 0.0395 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |     **100** | **25.429 ns** | **0.2746 ns** | **0.1634 ns** |  **1.00** |    **0.00** |
| LastFaster |     100 |  4.224 ns | 0.0572 ns | 0.0378 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |     **250** | **26.652 ns** | **0.3222 ns** | **0.2131 ns** |  **1.00** |    **0.00** |
| LastFaster |     250 |  4.274 ns | 0.0239 ns | 0.0158 ns |  0.16 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |     **500** | **26.450 ns** | **0.2627 ns** | **0.1563 ns** |  **1.00** |    **0.00** |
| LastFaster |     500 |  4.210 ns | 0.0786 ns | 0.0520 ns |  0.16 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **1000** | **23.227 ns** | **0.2467 ns** | **0.1632 ns** |  **1.00** |    **0.00** |
| LastFaster |    1000 |  4.208 ns | 0.0226 ns | 0.0135 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **1500** | **23.136 ns** | **0.3016 ns** | **0.1995 ns** |  **1.00** |    **0.00** |
| LastFaster |    1500 |  4.185 ns | 0.0731 ns | 0.0484 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **2000** | **26.201 ns** | **0.4228 ns** | **0.2212 ns** |  **1.00** |    **0.00** |
| LastFaster |    2000 |  4.218 ns | 0.0547 ns | 0.0362 ns |  0.16 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **2500** | **23.289 ns** | **0.2926 ns** | **0.1935 ns** |  **1.00** |    **0.00** |
| LastFaster |    2500 |  4.256 ns | 0.0557 ns | 0.0368 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **3000** | **23.304 ns** | **0.2333 ns** | **0.1543 ns** |  **1.00** |    **0.00** |
| LastFaster |    3000 |  4.275 ns | 0.0390 ns | 0.0258 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |    **5000** | **23.281 ns** | **0.3752 ns** | **0.2482 ns** |  **1.00** |    **0.00** |
| LastFaster |    5000 |  4.245 ns | 0.0308 ns | 0.0203 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |   **10000** | **23.883 ns** | **0.2173 ns** | **0.1137 ns** |  **1.00** |    **0.00** |
| LastFaster |   10000 |  4.255 ns | 0.0451 ns | 0.0299 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |   **50000** | **24.968 ns** | **0.2248 ns** | **0.1487 ns** |  **1.00** |    **0.00** |
| LastFaster |   50000 |  4.226 ns | 0.0497 ns | 0.0329 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |  **100000** | **25.461 ns** | **0.4556 ns** | **0.3013 ns** |  **1.00** |    **0.00** |
| LastFaster |  100000 |  4.239 ns | 0.0230 ns | 0.0152 ns |  0.17 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** |  **500000** | **24.123 ns** | **0.2199 ns** | **0.1454 ns** |  **1.00** |    **0.00** |
| LastFaster |  500000 |  4.388 ns | 0.1116 ns | 0.0738 ns |  0.18 |    0.00 |
|            |         |           |           |           |       |         |
|   **LastLinq** | **1000000** | **23.980 ns** | **0.2231 ns** | **0.1476 ns** |  **1.00** |    **0.00** |
| LastFaster | 1000000 |  4.337 ns | 0.0439 ns | 0.0261 ns |  0.18 |    0.00 |

Benchmarks with issues:
  LastBenchmark.LastLinq: Job-VDQUHN(IterationCount=10, LaunchCount=1, WarmupCount=2) [N=0]
  LastBenchmark.LastFaster: Job-VDQUHN(IterationCount=10, LaunchCount=1, WarmupCount=2) [N=0]
