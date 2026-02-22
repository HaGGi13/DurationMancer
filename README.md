# DurationMancer

DurationMancer is a simple library that provides a flexible time parser that understands both technical and natural language inputs. You can use these formats wherever a time duration is required, and you don't want to deal with the hassle of parsing strings yourself.

ℹ️ Negative values are not supported (yet)!

## Supported Formats

### Standard Duration Format

This format is best for precise, structured input. It follows the pattern: `[days.]HH:mm:ss[.milliseconds]`

| Component        | Format | Range / Description                               |
|:-----------------|:-------|:--------------------------------------------------|
| **Days**         | `d.`   | Optional. Any number of digits followed by a dot. |
| **Hours**        | `HH`   | **Required.** 00 to 23.                           |
| **Minutes**      | `mm`   | **Required.** 00 to 59.                           |
| **Seconds**      | `ss`   | **Required.** 00 to 59.                           |
| **Milliseconds** | `.fff` | Optional. Up to 3 digits following a dot.         |

**Examples:**

- `12:30:00` → 12 hours, 30 minutes
- `1.05:00:00` → 1 day, 5 hours
- `00:00:45.500` → 45.5 seconds

### Human-Readable Format

This format is ideal for quick CLI input. You can mix and match units using full names or shorthand.

#### Supported Units

| Unit             | Keywords (Case-Insensitive)         |
|:-----------------|:------------------------------------|
| **Days**         | `d`, `day`, `days`                  |
| **Hours**        | `h`, `hour`, `hours`                |
| **Minutes**      | `m`, `min`, `minute`, `minutes`     |
| **Seconds**      | `s`, `sec`, `second`, `seconds`     |
| **Milliseconds** | `ms`, `millisecond`, `milliseconds` |

#### Key Features

- **Decimal Support:** You can use decimals for larger units (e.g., `1.5h` for 1 hour and 30 minutes).
- **Flexible Spacing:** `1h30m` and `1 h 30 m` are both valid.
- **Automatic Rounding:** All inputs are rounded to the nearest millisecond.

**Examples:**

- 1d 12h → `1.12:00:00`
- 5m 30s → `00:05:30`
- 1.5 hours → `01:30:00`
- 100 ms → `00:00:00.100`
- 2 days 4 h 15 m 30 s → `2.04:15:30`

## Usage

The usage is straightforward, like shown in the examples below.

### Standard Duration Format
```csharp
// Example 1: Days, hours, minutes, and seconds
string input1 = "1.05:00:00";
TimeSpan result1 = DurationTimeParser.TryParse(input1);
// result1 == new TimeSpan(days: 1, hours: 5, minutes: 0, seconds: 0)
// result1 -> 1.05:00:00

// Example 2: Seconds with milliseconds
string input2 = "00:00:45.500";
TimeSpan result2 = DurationTimeParser.TryParse(input2);
// result2 == TimeSpan.FromSeconds(45) + TimeSpan.FromMilliseconds(500)
// result2 -> 00:00:45.500
```

### Human-readable Format
```csharp
// Example 1: Mix of full words and shorthand
string input1 = "2days 4h 15m 30s";
TimeSpan result1 = DurationTimeParser.TryParse(input1);
// result1 == TimeSpan.FromDays(2) + TimeSpan.FromHours(4) + TimeSpan.FromMinutes(15) + TimeSpan.FromSeconds(30)
// result1 -> 2.04:15:30

// Example 2: Decimal values with flexible spacing
string input2 = "1.5 hours 100ms";
TimeSpan result2 = DurationTimeParser.TryParse(input2);
// result2 == TimeSpan.FromHours(1.5) + TimeSpan.FromMilliseconds(100)
// result2 -> 01:30:00.100
```

## Benchmarks

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 7950X3D 4.20GHz, 1 CPU, 32 logical and 16 physical cores
.NET SDK 10.0.103
  [Host]  : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
  .NET 10 : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
  .NET 9  : .NET 9.0.13 (9.0.13, 9.0.1326.6317), X64 RyuJIT x86-64-v4
  .NET 8  : .NET 8.0.24 (8.0.24, 8.0.2426.7010), X64 RyuJIT x86-64-v4
```

| Method                         | Runtime   |        Mean |      Error |     StdDev |         P95 | Ratio | RatioSD | Rank |   Gen0 | Allocated |
|--------------------------------|-----------|------------:|-----------:|-----------:|------------:|------:|--------:|-----:|-------:|----------:|
| 'Standard: HH:mm:ss'           | .NET 10.0 | 300.9489 ns |  5.9727 ns | 11.2181 ns | 319.4432 ns |  6.79 |    0.26 |    3 | 0.0329 |    1656 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 10.0 | 307.9156 ns |  3.4664 ns |  2.7063 ns | 310.8405 ns |  6.94 |    0.10 |    3 | 0.0334 |    1688 B |
| 'Human: single unit (5m)'      | .NET 10.0 | 397.4792 ns |  2.1752 ns |  2.0347 ns | 400.2274 ns |  8.96 |    0.11 |    4 | 0.0334 |    1688 B |
| 'Human: two units (1h 30m)'    | .NET 10.0 | 418.4242 ns |  4.4143 ns |  3.9132 ns | 425.3554 ns |  9.44 |    0.14 |    5 | 0.0339 |    1720 B |
| 'Human: full combo' \*         | .NET 10.0 | 650.1754 ns |  4.3376 ns |  3.8452 ns | 656.4196 ns | 14.66 |    0.18 |    7 | 0.0372 |    1880 B |
| 'Human: decimals (1.5h 100ms)' | .NET 10.0 | 533.1936 ns |  3.1562 ns |  2.9523 ns | 537.8815 ns | 12.02 |    0.15 |    6 | 0.0353 |    1816 B |
| 'Invalid input'                | .NET 10.0 |  44.3513 ns |  0.5849 ns |  0.5185 ns |  45.2777 ns |  1.00 |    0.02 |    2 |      - |         - |
| 'Null input'                   | .NET 10.0 |   0.9634 ns |  0.0264 ns |  0.0221 ns |   0.9963 ns |  0.02 |    0.00 |    1 |      - |         - |
|                                |           |             |            |            |             |       |         |      |        |           |
| 'Standard: HH:mm:ss'           | .NET 9.0  | 340.3667 ns |  4.1653 ns |  3.4782 ns | 344.6905 ns |  5.26 |    0.09 |    3 | 0.0329 |    1656 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 9.0  | 363.9161 ns |  4.1630 ns |  3.6904 ns | 368.8706 ns |  5.62 |    0.09 |    4 | 0.0334 |    1688 B |
| 'Human: single unit (5m)'      | .NET 9.0  | 478.1021 ns |  4.4622 ns |  3.9556 ns | 484.8228 ns |  7.39 |    0.12 |    5 | 0.0334 |    1688 B |
| 'Human: two units (1h 30m)'    | .NET 9.0  | 512.0947 ns |  6.9916 ns |  6.1979 ns | 521.3898 ns |  7.91 |    0.14 |    6 | 0.0339 |    1720 B |
| 'Human: full combo' \*         | .NET 9.0  | 848.9257 ns | 13.7756 ns | 12.2117 ns | 869.7854 ns | 13.12 |    0.26 |    8 | 0.0372 |    1880 B |
| 'Human: decimals (1.5h 100ms)' | .NET 9.0  | 737.0302 ns |  8.3758 ns |  7.8347 ns | 748.2742 ns | 11.39 |    0.19 |    7 | 0.0353 |    1816 B |
| 'Invalid input'                | .NET 9.0  |  64.7167 ns |  0.9763 ns |  0.9133 ns |  66.1356 ns |  1.00 |    0.02 |    2 |      - |         - |
| 'Null input'                   | .NET 9.0  |   0.9930 ns |  0.0224 ns |  0.0210 ns |   1.0187 ns |  0.02 |    0.00 |    1 |      - |         - |
|                                |           |             |            |            |             |       |         |      |        |           |
| 'Standard: HH:mm:ss'           | .NET 8.0  | 353.3871 ns |  3.5373 ns |  2.7617 ns | 357.3055 ns |  5.52 |    0.09 |    3 | 0.0329 |    1656 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 8.0  | 384.0297 ns |  6.0336 ns |  5.3486 ns | 391.8443 ns |  6.00 |    0.12 |    4 | 0.0334 |    1688 B |
| 'Human: single unit (5m)'      | .NET 8.0  | 503.3029 ns |  9.9447 ns | 10.6408 ns | 518.5876 ns |  7.86 |    0.20 |    5 | 0.0334 |    1688 B |
| 'Human: two units (1h 30m)'    | .NET 8.0  | 525.4900 ns |  4.2636 ns |  3.5603 ns | 529.8040 ns |  8.20 |    0.14 |    5 | 0.0339 |    1720 B |
| 'Human: full combo' \*         | .NET 8.0  | 872.3254 ns |  9.7794 ns |  9.1477 ns | 886.8218 ns | 13.62 |    0.25 |    7 | 0.0372 |    1880 B |
| 'Human: decimals (1.5h 100ms)' | .NET 8.0  | 772.2243 ns | 11.7644 ns | 11.0045 ns | 785.5411 ns | 12.06 |    0.25 |    6 | 0.0353 |    1816 B |
| 'Invalid input'                | .NET 8.0  |  64.0676 ns |  1.0798 ns |  1.0101 ns |  65.4616 ns |  1.00 |    0.02 |    2 |      - |         - |
| 'Null input'                   | .NET 8.0  |   0.9657 ns |  0.0224 ns |  0.0198 ns |   0.9943 ns |  0.02 |    0.00 |    1 |      - |         - |

\* full combo = "2 days 4 hours 15 minutes 30 seconds 500 milliseconds"
