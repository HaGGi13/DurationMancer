namespace DurationMancer.Tests.TestData;

public sealed class DurationTimeParserInvalidTestData
{
    /// <summary>
    /// All invalid inputs combined (mixed formats, malformed, out-of-range, and negative).
    /// </summary>
    public static TheoryData<string> AllInvalidInputs =>
    [
        .. InvalidMixedFormatInputs,
        .. InvalidMalformedInputs,
        .. InvalidOutOfRangeInputs,
        .. InvalidNegativeFormatInputs
    ];

    /// <summary>
    /// Inputs that mix human-readable units with standard time format (e.g. "1d 00:00:00").
    /// </summary>
    private static TheoryData<string> InvalidMixedFormatInputs =>
    [
        // Human-readable days + standard time
        "1d 00:00:00",
        "1 d 00:00:00",
        "1day 00:00:00",
        "1 day 00:00:00",
        "1days 00:00:00",
        "1 days 00:00:00",
        "2d 12:30:45",
        "2 days 12:30:45",
        "1d 1.12:30:45",
        "1 day 1.12:30:45",
        "1d 00:00:00.500",
        "1 day 00:00:00.500",
        "2 days 1.23:45:56.789",

        // Human-readable hours + standard time
        "1h 00:00:00",
        "1 h 00:00:00",
        "1hour 00:00:00",
        "1 hour 00:00:00",
        "1hours 00:00:00",
        "1 hours 00:00:00",
        "2h 01:30:00",
        "2 hours 01:30:00",
        "1h 0.01:30:00",
        "3 hours 00:00:00.100",

        // Human-readable minutes + standard time
        "1m 00:00:00",
        "1 m 00:00:00",
        "1min 00:00:00",
        "1 min 00:00:00",
        "1minute 00:00:00",
        "1 minute 00:00:00",
        "1minutes 00:00:00",
        "1 minutes 00:00:00",
        "5m 01:00:30",
        "5 minutes 01:00:30",
        "10 min 0.12:00:00",
        "15 minutes 00:00:00.250",

        // Human-readable seconds + standard time
        "1s 00:00:00",
        "1 s 00:00:00",
        "1sec 00:00:00",
        "1 sec 00:00:00",
        "1second 00:00:00",
        "1 second 00:00:00",
        "1seconds 00:00:00",
        "1 seconds 00:00:00",
        "30s 00:01:00",
        "30 seconds 00:01:00",
        "10 sec 1.00:00:00",
        "5 seconds 00:00:00.500",

        // Human-readable milliseconds + standard time
        "100ms 00:00:00",
        "100 ms 00:00:00",
        "100millisecond 00:00:00",
        "100 millisecond 00:00:00",
        "100milliseconds 00:00:00",
        "100 milliseconds 00:00:00",
        "500ms 00:00:01",
        "500 milliseconds 00:00:01",
        "250 ms 1.12:30:00",
        "100 milliseconds 00:00:00.100",

        // Standard time + trailing human-readable units
        "00:00:00 1d",
        "00:00:00 1 day",
        "00:00:00 1h",
        "00:00:00 1 hour",
        "00:00:00 1m",
        "00:00:00 1 minute",
        "00:00:00 1s",
        "00:00:00 1 second",
        "00:00:00 100ms",
        "00:00:00 100 milliseconds",
        "01:30:00 5s",
        "1.12:30:00 500ms",
        "00:00:00.500 1s",

        // Standard time sandwiched between human-readable units
        "1d 00:00:00 1s",
        "1 day 01:00:00 100ms",
        "2h 00:30:00 5s",
        "1d 1h 00:00:00",
        "1 day 2 hours 00:30:00",

        // Multiple human-readable units + standard time
        "1d 2h 00:00:00",
        "1 day 2 hours 00:00:00",
        "1d 2h 3m 00:00:00",
        "1 day 2 hours 3 minutes 00:00:00",
        "1d 2h 3m 4s 00:00:00",
        "1 day 2 hours 3 minutes 4 seconds 00:00:00",
        "1d 2h 3m 4s 500ms 00:00:00",
        "1 day 2 hours 3 minutes 4 seconds 500 milliseconds 00:00:00",

        // Standard time + multiple trailing human-readable units
        "00:00:00 1d 2h",
        "00:00:00 1 day 2 hours",
        "00:00:00 1d 2h 3m",
        "00:00:00 1d 2h 3m 4s",
        "00:00:00 1d 2h 3m 4s 500ms",

        // Standard format with days prefix + human-readable suffix
        "1.12:30:45 1d",
        "1.12:30:45 1 day",
        "1.12:30:45 100ms",
        "0.00:00:00 1s",

        // Standard format with milliseconds + human-readable suffix
        "00:00:00.500 1d",
        "00:00:00.500 1 hour",
        "00:00:00.500 1m",
        "00:00:00.100 100ms",

        // Full standard format + full human-readable format
        "1.23:45:56.789 1d 2h 3m 4s 500ms",
        "00:00:01 1 second",
        "1d 1.23:45:56.789 500ms",

        // Negative mixed formats (still invalid — mixing human-readable + standard)
        "-1d 00:00:00",
        "-1 day 00:00:00",
        "-00:00:00 1s",
        "-00:00:00 1 day",
        "-1d 00:00:00 1s",
        "-1.23:45:56.789 1d 2h 3m 4s 500ms"
    ];

    /// <summary>
    /// Malformed inputs: non-parseable text, unrecognized units, wrong order, missing spaces,
    /// comma decimals, incomplete standard formats, plus signs, and bad numeric formats.
    /// </summary>
    private static TheoryData<string> InvalidMalformedInputs =>
    [
        // Non-parseable or completely invalid text
        "invalid",
        "Foo",
        " Bar",

        // Valid value with invalid surrounding text
        "Foo 3s",
        "3s Bar",
        "Foo 00:00:03",
        "00:00:03 Bar",
        "Foo 00:00:03 Bar",

        // Number followed by unrecognized unit
        "3house",
        "3 house",
        "3houses",
        "3 houses",
        "1y",
        "1d 2x",

        // Missing spaces between human-readable components
        "2s1ms",
        "3m2s",
        "4h3m",
        "5d3h",
        "3m2s1ms",
        "4h3m2s",
        "5d4h3m2s1ms",

        // Human-readable components in the wrong order or duplicated
        "0m 3s 1m",
        "3s 1h",

        // Comma decimal separator (not supported; use dot)
        "3,5s",
        "3,005s",
        "3,005.0s",
        "3,5 s",

        // Incomplete or malformed standard time format
        "00:00",
        "00:00.0",
        "0.00:00",

        // Human-readable values that cause numeric parsing errors
        "1.2.3 days", // The double.Parse will throw FormatException due to multiple decimal points
        "1 day 2.5ms", // int.Parse will throw FormatException due to an invalid integer format

        // Input with plus sign (not supported; only minus is allowed)
        "+00:00:03",
        "+3s",
        "+3h",
        "+00:00:03",
        "+1d 2h"
    ];

    /// <summary>
    /// Out-of-range values: components exceeding valid bounds (e.g. "00:00:60", overflow).
    /// </summary>
    private static TheoryData<string> InvalidOutOfRangeInputs =>
    [
        // Standard time format with out-of-range components (without days prefix)
        "00:00:60",
        "00:00:61",
        "00:60:00",
        "00:61:00",
        "24:00:00",
        "25:00:00",

        // Standard time format with out-of-range components (with fractional seconds)
        "00:00:00.0001",
        "00:00:60.0",
        "00:00:61.0",
        "00:60:00.0",
        "00:61:00.0",
        "24:00:00.0",
        "25:00:00.0",

        // Standard time format with out-of-range components (with days prefix)
        "0.00:00:60",
        "0.00:00:61",
        "0.00:60:00",
        "0.00:61:00",
        "0.24:00:00",
        "0.25:00:00",

        // Human-readable values that cause numeric parsing errors
        "1E+999999999 days", // The value is too large for double.Parse and will throw OverflowException
        "999999999 days 23 hours 59 minutes 59 seconds", // This will cause TimeSpan overflow when components are added together

        // --- Negative values ---

        // Standard time format with out-of-range components (without days prefix)
        "-00:00:60",
        "-00:00:61",
        "-00:60:00",
        "-00:61:00",
        "-24:00:00",
        "-25:00:00",

        // Standard time format with out-of-range components (with fractional seconds)
        "-00:00:00.0001",
        "-00:00:60.0",
        "-00:00:61.0",
        "-00:60:00.0",
        "-00:61:00.0",
        "-24:00:00.0",
        "-25:00:00.0",

        // Standard time format with out-of-range components (with days prefix)
        "-0.00:00:60",
        "-0.00:00:61",
        "-0.00:60:00",
        "-0.00:61:00",
        "-0.24:00:00",
        "-0.25:00:00",

        // Human-readable values that cause numeric parsing errors
        "-1E+999999999 days", // This value is too small for double.Parse and will throw OverflowException
        "-999999999 days 23 hours 59 minutes 59 seconds" // This will cause TimeSpan overflow when components are added together
    ];

    /// <summary>
    /// Invalid negative inputs: bare minus, doubled/misplaced/trailing minus signs,
    /// and negative values combined with other malformed elements (bad units, commas, bad numerics).
    /// </summary>
    private static TheoryData<string> InvalidNegativeFormatInputs =>
    [
        // Input with minus sign only
        "-",
        "   -",
        "-   ",

        // Double minus sign
        "--00:00:03",
        "--   00:00:05",
        "--3s",
        "--   7s",

        // Pre-component minus sign
        "3h -30m",
        "3h - 30m",
        "-3h -30m",
        "-  3h -  30m",
        "--5m --3s",
        "--  5m --  3s",
        "-3h -30m -5s",

        // Trailing minus sign
        "3s-",
        "3s -",
        "3s--",
        "3s  --",
        "00:00:03-",
        "00:00:03  -",

        // Mid-position minus sign
        "3h-30m",
        "3h- 30m",
        "3h-30m-7s",
        "3h-30m- 7s",
        "3h- 30m- 7s",

        // Negative with invalid unit
        "-1y",
        "-3 house",

        // Comma decimal
        "-3,5s",

        // Negative invalid double
        "-1.2.3 days", // The double.Parse will throw FormatException due to multiple decimal points

        // Negative invalid double
        "-1 day 2.5ms" // int.Parse will throw FormatException due to an invalid integer format
    ];
}
