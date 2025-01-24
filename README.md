# entity-to-csv-serialization-benchmark
Some methods/nugets to write entities to csv (string or file)  benchmark in c#


### Benchmark Results

``` 
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2894)
12th Gen Intel Core i7-1255U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 9.0.200-preview.0.25057.12
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
```

| Method                                         | Mean     | Error    | StdDev   | Ratio | RatioSD |
|----------------------------------------------- |---------:|---------:|---------:|------:|--------:|
| EntityToCsvOption1                             | 263.7 ms |  4.85 ms |  4.54 ms |  1.00 |    0.02 |
| EntityToCsvOption2                             | 515.0 ms | 10.26 ms | 14.04 ms |  1.95 |    0.06 |
| EntityToCsvOption3                             | 295.8 ms |  5.72 ms |  7.24 ms |  1.12 |    0.03 |
| EntityToCsvOption4                             | 214.3 ms |  3.48 ms |  3.26 ms |  0.81 |    0.02 |
| 'EntityToCsvOption5 (nuget ServiceStack.Text)' | 210.5 ms |  4.19 ms |  4.66 ms |  0.80 |    0.02 |
| 'EntityToCsvOption6 (nuget CsvHelper)'         | 327.0 ms |  6.41 ms |  6.00 ms |  1.24 |    0.03 |
| 'EntityToCsvOption7 (nuget FileHelpers)'       | 262.2 ms |  5.07 ms |  5.84 ms |  0.99 |    0.03 |