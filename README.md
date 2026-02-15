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

---

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
