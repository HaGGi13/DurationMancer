# DurationMancer

DurationMancer is a simle library that provides a flexible time parser that understands both technical and natural language inputs. You can use these formats wherever a time duration is required and you don't want to deal with the hassle of parsing strings yourself.

ℹ️ Negative values are not supported (yet)!

## Usage

The usage very simple, like shown in the examples below.

### Humand-readable Format
```csharp
// Example 1: Mix of full words and shorthand
string input1 = "2days 4h 15m 30s";
TimeSpan result1 = DurationParser.Parse(input1);
// result1 == TimeSpan.FromDays(2) + TimeSpan.FromHours(4) + TimeSpan.FromMinutes(15) + TimeSpan.FromSeconds(30)

// Example 2: Decimal values with flexible spacing
string input2 = "1.5 hours 100ms";
TimeSpan result2 = DurationParser.Parse(input2);
// result2 == TimeSpan.FromHours(1.5) + TimeSpan.FromMilliseconds(100)
```

### Standard Duration Format
```csharp
// Example 1: Days, hours, minutes, and seconds
string input1 = "1.05:00:00";
TimeSpan result1 = DurationParser.Parse(input1);
// result1 == new TimeSpan(days: 1, hours: 5, minutes: 0, seconds: 0)

// Example 2: Seconds with milliseconds
string input2 = "00:00:45.500";
TimeSpan result2 = DurationParser.Parse(input2);
// result2 == TimeSpan.FromSeconds(45.5)
```

## Supported Formats

### Standard Duration Format

This format is best for precise, structured input. It follows the pattern: `[days.]HH:mm:ss[.milliseconds]`

| Component        | Format | Range / Description                               |
| :--------------- | :----- | :------------------------------------------------ |
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
| :--------------- | :---------------------------------- |
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

- `1d 12h`
- `5m 30s`
- `1.5 hours`
- `100ms`
- `2days 4h 15m 30s`

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

| Method                         | Runtime   |        Mean |      Error |    StdDev |         P95 | Ratio | RatioSD | Rank |   Gen0 | Allocated |
| ------------------------------ | --------- | ----------: | ---------: | --------: | ----------: | ----: | ------: | ---: | -----: | --------: |
| 'Standard: HH:mm:ss'           | .NET 10.0 | 298.1505 ns |  2.4080 ns | 2.2524 ns | 301.3607 ns |  8.02 |    0.06 |    3 | 0.0348 |    1752 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 10.0 | 337.5800 ns |  6.5587 ns | 6.1350 ns | 346.8909 ns |  9.08 |    0.16 |    4 | 0.0362 |    1840 B |
| 'Human: single unit (5m)'      | .NET 10.0 | 392.8773 ns |  3.5938 ns | 3.3616 ns | 397.7572 ns | 10.56 |    0.09 |    5 | 0.0339 |    1712 B |
| 'Human: two units (1h 30m)'    | .NET 10.0 | 452.5045 ns |  2.3685 ns | 1.9778 ns | 454.8526 ns | 12.17 |    0.06 |    6 | 0.0353 |    1776 B |
| 'Human: full combo' \*         | .NET 10.0 | 759.7605 ns |  6.1496 ns | 5.7524 ns | 768.1694 ns | 20.43 |    0.16 |    8 | 0.0401 |    2024 B |
| 'Human: decimals (1.5h 100ms)' | .NET 10.0 | 560.4385 ns |  2.5589 ns | 2.2684 ns | 563.9663 ns | 15.07 |    0.07 |    7 | 0.0372 |    1880 B |
| 'Invalid input'                | .NET 10.0 |  37.1920 ns |  0.0890 ns | 0.0789 ns |  37.3029 ns |  1.00 |    0.00 |    2 |      - |         - |
| 'Null input'                   | .NET 10.0 |   0.8341 ns |  0.0046 ns | 0.0038 ns |   0.8401 ns |  0.02 |    0.00 |    1 |      - |         - |
|                                |           |             |            |           |             |       |         |      |        |           |
| 'Standard: HH:mm:ss'           | .NET 9.0  | 354.0586 ns |  7.0855 ns | 8.1597 ns | 363.1163 ns |  6.11 |    0.14 |    3 | 0.0348 |    1752 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 9.0  | 397.6152 ns |  6.9474 ns | 6.4986 ns | 406.1554 ns |  6.86 |    0.12 |    4 | 0.0362 |    1840 B |
| 'Human: single unit (5m)'      | .NET 9.0  | 471.8717 ns |  9.2507 ns | 9.4998 ns | 485.1973 ns |  8.15 |    0.17 |    5 | 0.0339 |    1712 B |
| 'Human: two units (1h 30m)'    | .NET 9.0  | 536.7581 ns | 10.7092 ns | 8.9427 ns | 546.0439 ns |  9.27 |    0.16 |    6 | 0.0353 |    1776 B |
| 'Human: full combo' \*         | .NET 9.0  | 873.6216 ns |  8.8310 ns | 7.8284 ns | 886.2697 ns | 15.08 |    0.17 |    8 | 0.0401 |    2024 B |
| 'Human: decimals (1.5h 100ms)' | .NET 9.0  | 690.4374 ns |  4.3499 ns | 3.8561 ns | 696.4002 ns | 11.92 |    0.10 |    7 | 0.0372 |    1880 B |
| 'Invalid input'                | .NET 9.0  |  57.9295 ns |  0.2371 ns | 0.4027 ns |  58.8710 ns |  1.00 |    0.01 |    2 |      - |         - |
| 'Null input'                   | .NET 9.0  |   0.8429 ns |  0.0099 ns | 0.0087 ns |   0.8568 ns |  0.01 |    0.00 |    1 |      - |         - |
|                                |           |             |            |           |             |       |         |      |        |           |
| 'Standard: HH:mm:ss'           | .NET 8.0  | 315.1999 ns |  2.1455 ns | 1.9019 ns | 318.1252 ns |  5.29 |    0.04 |    3 | 0.0348 |    1752 B |
| 'Standard: d.HH:mm:ss.fff'     | .NET 8.0  | 368.5408 ns |  1.7708 ns | 1.4787 ns | 370.8185 ns |  6.18 |    0.03 |    4 | 0.0362 |    1840 B |
| 'Human: single unit (5m)'      | .NET 8.0  | 440.2367 ns |  1.8504 ns | 1.6403 ns | 442.6820 ns |  7.38 |    0.04 |    5 | 0.0339 |    1712 B |
| 'Human: two units (1h 30m)'    | .NET 8.0  | 492.3350 ns |  5.4852 ns | 5.1308 ns | 499.0772 ns |  8.26 |    0.09 |    6 | 0.0353 |    1776 B |
| 'Human: full combo' \*         | .NET 8.0  | 853.8517 ns |  8.0323 ns | 7.5134 ns | 865.4025 ns | 14.32 |    0.13 |    8 | 0.0401 |    2024 B |
| 'Human: decimals (1.5h 100ms)' | .NET 8.0  | 707.8297 ns |  5.2995 ns | 4.9572 ns | 715.4481 ns | 11.87 |    0.09 |    7 | 0.0372 |    1880 B |
| 'Invalid input'                | .NET 8.0  |  59.6169 ns |  0.2654 ns | 0.2352 ns |  59.9797 ns |  1.00 |    0.01 |    2 |      - |         - |
| 'Null input'                   | .NET 8.0  |   0.9443 ns |  0.0370 ns | 0.0803 ns |   1.0528 ns |  0.02 |    0.00 |    1 |      - |         - |

\* full combo = "2 days 4 hours 15 minutes 30 seconds 500 milliseconds"
