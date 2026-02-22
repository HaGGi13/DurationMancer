namespace DurationMancer.Tests.TestData;

public sealed class DurationTimeParserUnrollingTestData
{
    /// <summary>
    /// Represents a collection of valid human-readable input strings describing a duration of 3.5 seconds
    /// for testing parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test data comprising multiple valid representations of a fractional duration of 3.5 seconds.
    /// The test data includes variations with optional spaces, unit abbreviations, and extended unit names, as well as
    /// combinations with zero values for other time units (e.g., milliseconds, minutes, hours, days). It ensures that the
    /// parsing method accurately recognizes and processes valid inputs describing the specified duration.
    /// </remarks>
    public static TheoryData<string> ValidUnrolling3Dot5SecondsInputs =>
    [
        "3.5s",
        "3.5sec",
        "3.5second",
        "3.5seconds",
        "3.5 s",
        "3.5 sec",
        "3.5 second",
        "3.5 seconds",
        "3.5s 0ms",
        "3.5sec 0ms",
        "3.5second 0millisecond",
        "3.5seconds 0milliseconds",
        "3.5 s 0 ms",
        "3.5 sec 0 ms",
        "3.5 second 0 millisecond",
        "3.5 seconds 0 milliseconds",
        "0m 3.5s",
        "0min 3.5sec",
        "0minute 3.5second",
        "0minutes 3.5seconds",
        "0 m 3.5 s",
        "0 min 3.5 sec",
        "0 minute 3.5 second",
        "0 minutes 3.5 seconds",
        "0m 3.5s 0ms",
        "0min 3.5sec 0ms",
        "0minute 3.5second 0millisecond",
        "0minutes 3.5seconds 0milliseconds",
        "0 m 3.5 s 0 ms",
        "0 min 3.5 sec 0 ms",
        "0 minute 3.5 second 0 millisecond",
        "0 minutes 3.5 seconds 0 milliseconds",
        "0h 0m 3.5s",
        "0hour 0min 3.5sec",
        "0hour 0minute 3.5second",
        "0hours 0minutes 3.5seconds",
        "0 h 0 m 3.5 s",
        "0 hour 0 min 3.5 sec",
        "0 hour 0 minute 3.5 second",
        "0 hours 0 minutes 3.5 seconds",
        "0h 0m 3.5s 0ms",
        "0hour 0min 3.5sec 0ms",
        "0hour 0minute 3.5second 0millisecond",
        "0hours 0minutes 3.5seconds 0milliseconds",
        "0 h 0 m 3.5 s 0 ms",
        "0 hour 0 min 3.5 sec 0 ms",
        "0 hour 0 minute 3.5 second 0 millisecond",
        "0 hours 0 minutes 3.5 seconds 0 milliseconds",
        "0d 0h 0m 3.5s",
        "0day 0hour 0min 3.5sec",
        "0day 0hour 0minute 3.5second",
        "0days 0hours 0minutes 3.5seconds",
        "0 d 0 h 0 m 3.5 s",
        "0 day 0 hour 0 min 3.5 sec",
        "0 day 0 hour 0 minute 3.5 second",
        "0 days 0 hours 0 minutes 3.5 seconds",
        "0d 0h 0m 3.5s 0ms",
        "0day 0hour 0min 3.5sec 0ms",
        "0day 0hour 0minute 3.5second 0millisecond",
        "0days 0hours 0minutes 3.5seconds 0milliseconds",
        "0 d 0 h 0 m 3.5 s 0 ms",
        "0 day 0 hour 0 min 3.5 sec 0 ms",
        "0 day 0 hour 0 minute 3.5 second 0 millisecond",
        "0 days 0 hours 0 minutes 3.5 seconds 0 milliseconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 0m 3.5 s 0ms",
        "0day 0hour 0min 3.5 sec 0ms",
        "0day 0 hour 0 minute 3.5second 0millisecond",
        "0days  0hours 0minutes 3.5 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of human-readable valid duration strings that include unrolled fractional components
    /// for testing the parsing functionality of duration strings.
    /// </summary>
    /// <remarks>
    /// This property provides test data that contains duration strings with fractional values
    /// applied to days, hours, minutes, seconds, or milliseconds. It ensures the parser can accurately
    /// interpret fractional components and combine them with other valid time representations.
    /// </remarks>
    public static TheoryData<string, string> ValidUnrollingFractionInputs => new()
    {
        { "1.25d 1.5h 1.5m 1.5s 7ms", "1.07:31:31.507" },
        { "1.25d 1.5h 1.5m 1.5s 7ms", "1.07:31:31.507" },
        { "1.25d 1.5m 7ms", "1.06:01:30.007" },
        { "1.5m 13ms", "00:01:30.013" }
    };
}
