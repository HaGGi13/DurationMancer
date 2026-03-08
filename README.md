[![Build and analyze][1]][10]
[![Quality Gate Status][2]][11]
[![NuGet Version][3]][12]

# DurationMancer

DurationMancer is a simple library that provides a flexible time parser that understands both technical and natural language inputs. You can use these formats wherever a (negative) time duration is required, and you don't want to deal with the hassle of parsing strings yourself.

## Supported Formats

### Standard Duration Format

This format is best for precise, structured input.  

It follows the pattern:  
`[-][days.]HH:mm:ss[.milliseconds]`

| Component        | Format | Range / Description                                    |
| :--------------- | :----- | :----------------------------------------------------- |
| _Negative sign_  | `-`    | Optional. Defines that the value provided is negative. |
| **Days**         | `d.`   | Optional. Any number of digits followed by a dot.      |
| **Hours**        | `HH`   | **Required.** 00 to 23.                                |
| **Minutes**      | `mm`   | **Required.** 00 to 59.                                |
| **Seconds**      | `ss`   | **Required.** 00 to 59.                                |
| **Milliseconds** | `.fff` | Optional. Up to 3 digits following a dot.              |

**Examples:**

- `12:30:00` → 12 hours, 30 minutes
- `1.05:00:00` → 1 day, 5 hours
- `00:00:45.500` → 45.5 seconds
- `-00:00:05` → -5 seconds

### Human-Readable Format

This format is ideal for quick CLI input. You can mix and match units using full names or shorthand.  

ℹ️ Please note that a negative value is defined by a `minus` sign (`-`) in the first position of the entire string to be parse.

#### Supported Units

| Unit             | Keywords (Case-Insensitive)         |
| :--------------- | :---------------------------------- |
| _Negative sign_  | `-`                                 |
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
- -1m → `-00:01:00`
- -1m 13s → `-00:01:13`

## Usage

The usage is straightforward, like shown in the examples below.

### Standard Duration Format

```csharp
// Example 1: TryParse Days, hours, minutes, and seconds
string input1 = "1.05:00:00";
bool isSuccessfulParsed = DurationTimeParser.TryParse(input1, out TimeSpan result1);
// result1 == new TimeSpan(days: 1, hours: 5, minutes: 0, seconds: 0)
// result1 -> 1.05:00:00

// Example 2: Parse Seconds with milliseconds
string input2 = "00:00:45.500";
TimeSpan result2 = DurationTimeParser.Parse(input2);
// result2 == new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 45, milliseconds: 500)
// result2 -> 00:00:45.500
```

### Human-readable Format

```csharp
// Example 1: Mix of full words and shorthand
string input1 = "2days 4h 15m 30s";
bool isSuccessfulParsed = DurationTimeParser.TryParse(input1, out TimeSpan result1);
// result1 == new TimeSpan(days: 2, hours: 4, minutes: 15, seconds: 30)
// result1 -> 2.04:15:30

// Example 2: Decimal values with flexible spacing
string input2 = "1.5 hours 100ms";
TimeSpan result2 = DurationTimeParser.Parse(input2);
// result2 == new TimeSpan(days: 0, hours: 1, minutes: 30, seconds: 0, milliseconds: 100)
// result2 -> 01:30:00.100
```

## Benchmarks

For detailed benchmark results, please check the [Benchmarks page](https://github.com/HaGGi13/DurationMancer/wiki/Benchmarks) in the Wiki.

<!--# badge image references -->

[1]: https://github.com/HaGGi13/DurationMancer/actions/workflows/build.yaml/badge.svg
[2]: https://sonarcloud.io/api/project_badges/measure?project=HaGGi13_DurationMancer&metric=alert_status
[3]: https://img.shields.io/nuget/v/DurationMancer?style=flat&logo=nuget

<!--# badge link references -->

[10]: https://github.com/HaGGi13/DurationMancer/actions/workflows/build.yaml "Build pipeline"
[11]: https://sonarcloud.io/summary/new_code?id=HaGGi13_DurationMancer "Latest new code analysis"
[12]: https://www.nuget.org/packages/DurationMancer "NuGet: DurationMancer"
