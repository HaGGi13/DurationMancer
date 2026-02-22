namespace DurationMancer.Tests.TestData;

public sealed class DurationTimeParserRollingOverTestData
{
    /// <summary>
    /// Represents a collection of human-readable valid input strings that describe durations adding up to one second
    /// through the use of milliseconds or combinations of time units, intended for testing duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property includes test data with various formats where durations expressed in milliseconds may
    /// roll over into a full second. Examples include standalone millisecond declarations such as "1000ms" and
    /// combinations of time units like "0s 1000ms" or "0 hours 0 minutes 0 seconds 1000 milliseconds."
    /// It ensures the parsing method correctly recognizes such scenarios and converts them into a consistent
    /// one-second time span representation.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver1000MillisecondsInputs =>
    [
        "1000ms",
        "1000millisecond",
        "1000milliseconds",
        "1000 ms",
        "1000 millisecond",
        "1000 milliseconds",
        "0s 1000ms",
        "0sec 1000ms",
        "0second 1000millisecond",
        "0seconds 1000milliseconds",
        "0 s 1000 ms",
        "0 sec 1000 ms",
        "0 second 1000 millisecond",
        "0 seconds 1000 milliseconds",
        "0m 0s 1000ms",
        "0min 0sec 1000ms",
        "0minute 0second 1000millisecond",
        "0minutes 0seconds 1000milliseconds",
        "0 m 0 s 1000 ms",
        "0 min 0 sec 1000 ms",
        "0 minute 0 second 1000 millisecond",
        "0 minutes 0 seconds 1000 milliseconds",
        "0h 0m 0s 1000ms",
        "0hour 0min 0sec 1000ms",
        "0hour 0minute 0second 1000millisecond",
        "0hours 0minutes 0seconds 1000milliseconds",
        "0 h 0 m 0 s 1000 ms",
        "0 hour 0 min 0 sec 1000 ms",
        "0 hour 0 minute 0 second 1000 millisecond",
        "0 hours 0 minutes 0 seconds 1000 milliseconds",
        "0d 0h 0m 0s 1000ms",
        "0day 0hour 0min 0sec 1000ms",
        "0day 0hour 0minute 0second 1000millisecond",
        "0days 0hours 0minutes 0seconds 1000milliseconds",
        "0 d 0 h 0 m 0 s 1000 ms",
        "0 day 0 hour 0 min 0 sec 1000 ms",
        "0 day 0 hour 0 minute 0 second 1000 millisecond",
        "0 days 0 hours 0 minutes 0 seconds 1000 milliseconds"
    ];

    /// <summary>
    /// Represents a collection of human-readable valid inputs that span over one second and include an
    /// additional one millisecond, formatted in various valid representations.
    /// </summary>
    /// <remarks>
    /// This property provides data to test the parsing of duration values that translate
    /// to one second and one millisecond combined. The inputs include multiple formats
    /// with different units (e.g., milliseconds, seconds, minutes, hours, days) and their
    /// abbreviations. It ensures that the parsing functionality correctly interprets
    /// diverse duration strings containing exact values of 1001 milliseconds.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver1001MillisecondsInputs =>
    [
        "1001ms",
        "1001millisecond",
        "1001milliseconds",
        "1001 ms",
        "1001 millisecond",
        "1001 milliseconds",
        "0s 1001ms",
        "0sec 1001ms",
        "0second 1001millisecond",
        "0seconds 1001milliseconds",
        "0 s 1001 ms",
        "0 sec 1001 ms",
        "0 second 1001 millisecond",
        "0 seconds 1001 milliseconds",
        "0m 0s 1001ms",
        "0min 0sec 1001ms",
        "0minute 0second 1001millisecond",
        "0minutes 0seconds 1001milliseconds",
        "0 m 0 s 1001 ms",
        "0 min 0 sec 1001 ms",
        "0 minute 0 second 1001 millisecond",
        "0 minutes 0 seconds 1001 milliseconds",
        "0h 0m 0s 1001ms",
        "0hour 0min 0sec 1001ms",
        "0hour 0minute 0second 1001millisecond",
        "0hours 0minutes 0seconds 1001milliseconds",
        "0 h 0 m 0 s 1001 ms",
        "0 hour 0 min 0 sec 1001 ms",
        "0 hour 0 minute 0 second 1001 millisecond",
        "0 hours 0 minutes 0 seconds 1001 milliseconds",
        "0d 0h 0m 0s 1001ms",
        "0day 0hour 0min 0sec 1001ms",
        "0day 0hour 0minute 0second 1001millisecond",
        "0days 0hours 0minutes 0seconds 1001milliseconds",
        "0 d 0 h 0 m 0 s 1001 ms",
        "0 day 0 hour 0 min 0 sec 1001 ms",
        "0 day 0 hour 0 minute 0 second 1001 millisecond",
        "0 days 0 hours 0 minutes 0 seconds 1001 milliseconds"
    ];

    /// <summary>
    /// Contains valid human-readable input strings that represent durations rolling over 60 seconds
    /// to test if the duration parser accurately normalizes such inputs to one minute.
    /// </summary>
    /// <remarks>
    /// This property includes diverse formats of input strings representing 60 seconds or equivalent,
    /// such as "60s", "0m 60s", "0h 0m 60s", and their variations with different spacings and unit formats.
    /// It ensures the parsing functionality handles these cases correctly and interprets them as one minute.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver60SecondsInputs =>
    [
        "60s",
        "60sec",
        "60second",
        "60seconds",
        "60 s",
        "60 sec",
        "60 second",
        "60 seconds",
        "0m 60s",
        "0min 60sec",
        "0minute 60second",
        "0minutes 60seconds",
        "0 m 60 s",
        "0 min 60 sec",
        "0 minute 60 second",
        "0 minutes 60 seconds",
        "0h 0m 60s",
        "0hour 0min 60sec",
        "0hour 0minute 60second",
        "0hours 0minutes 60seconds",
        "0 h 0 m 60 s",
        "0 hour 0 min 60 sec",
        "0 hour 0 minute 60 second",
        "0 hours 0minutes 60seconds",
        "0d 0h 0m 60s",
        "0day 0hour 0min 60sec",
        "0day 0hour 0minute 60second",
        "0days 0hours 0minutes 60seconds",
        "0 d 0 h 0 m 60 s",
        "0 day 0 hour 0 min 60 sec",
        "0 day 0 hour 0 minute 60 second",
        "0 days 0 hours 0minutes 60 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 0m 60 s 0ms",
        "0day 0hour 0min 60 sec 0ms",
        "0day 0 hour 0 minute 60second 0millisecond",
        "0days  0hours 0minutes 60 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of valid human-readable input strings that specify durations
    /// rolling over 65 seconds, used for testing duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test data containing various formats for expressing durations
    /// that consolidate or exceed 65 seconds. It includes representations with
    /// seconds alone or combined with other units such as minutes, hours, and days.
    /// The data ensures that the parsing method correctly interprets diverse input formats
    /// while respecting unit specifications and spacing variations.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver65SecondsInputs =>
    [
        "65s",
        "65sec",
        "65second",
        "65seconds",
        "65 s",
        "65 sec",
        "65 second",
        "65 seconds",
        "0m 65s",
        "0min 65sec",
        "0minute 65second",
        "0minutes 65seconds",
        "0 m 65 s",
        "0 min 65 sec",
        "0 minute 65 second",
        "0 minutes 65 seconds",
        "0h 0m 65s",
        "0hour 0min 65sec",
        "0hour 0minute 65second",
        "0hours 0minutes 65seconds",
        "0 h 0 m 65 s",
        "0 hour 0 min 65 sec",
        "0 hour 0 minute 65 second",
        "0 hours 0minutes 65seconds",
        "0d 0h 0m 65s",
        "0day 0hour 0min 65sec",
        "0day 0hour 0minute 65second",
        "0days 0hours 0minutes 65seconds",
        "0 d 0 h 0 m 65 s",
        "0 day 0 hour 0 min 65 sec",
        "0 day 0 hour 0 minute 65 second",
        "0 days 0 hours 0minutes 65 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 0m 65 s 0ms",
        "0day 0hour 0min 65 sec 0ms",
        "0day 0 hour 0 minute 65second 0millisecond",
        "0days  0hours 0minutes 65 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a set of valid human-readable input strings that specify durations rolling over 60 minutes,
    /// used for testing duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property contains various input formats for durations equal to or exceeding 60 minutes
    /// but represented within a minute-based syntax. Examples include "60m", "60 minutes", or complex
    /// combinations such as "0h 60m 0s". It validates that the parsing logic properly normalizes these
    /// cases and interprets them as equivalent to one hour.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver60MinutesInputs =>
    [
        "60m",
        "60min",
        "60minute",
        "60minutes",
        "60 m",
        "60 min",
        "60 minute",
        "60 minutes",
        "60m 0s",
        "60min 0sec",
        "60minute 0second",
        "60minutes 0seconds",
        "60 m 0 s",
        "60 min 0 sec",
        "60 minute 0 second",
        "60 minutes 0 seconds",
        "0h 60m 0s",
        "0hour 60min 0sec",
        "0hour 60minute 0second",
        "0hours 60minutes 0seconds",
        "0 h 60 m 0 s",
        "0 hour 60 min 0 sec",
        "0 hour 60 minute 0 second",
        "0 hours 60 minutes 0 seconds",
        "0d 0h 60m 0s",
        "0day 0hour 60min 0sec",
        "0day 0hour 60minute 0second",
        "0days 0hours 60minutes 0seconds",
        "0 d 0 h 60 m 0 s",
        "0 day 0 hour 60 min 0 sec",
        "0 day 0 hour 60 minute 0 second",
        "0 days 0 hours 60 minutes 0 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 60m 0 s 0ms",
        "0day 0hour 60min 0 sec 0ms",
        "0day 0 hour 60 minute 0second 0millisecond",
        "0days  0hours 60minutes 0 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of valid human-readable input strings that encapsulate
    /// durations rolling over 65 minutes. These inputs are used to verify
    /// time parsing functionality that normalizes such cases into valid
    /// hour-and-minute formats.
    /// </summary>
    /// <remarks>
    /// This property includes varied string representations of durations
    /// that specify 65 minutes, often accompanied by additional time segments
    /// like hours, seconds, and milliseconds. The test cases ensure the parsing
    /// method correctly converts these inputs into the appropriate TimeSpan
    /// representation, typically equivalent to 1 hour and 5 minutes.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver65MinutesInputs =>
    [
        "65m",
        "65min",
        "65minute",
        "65minutes",
        "65 m",
        "65 min",
        "65 minute",
        "65 minutes",
        "65m 0s",
        "65min 0sec",
        "65minute 0second",
        "65minutes 0seconds",
        "65 m 0 s",
        "65 min 0 sec",
        "65 minute 0 second",
        "65 minutes 0 seconds",
        "0h 65m 0s",
        "0hour 65min 0sec",
        "0hour 65minute 0second",
        "0hours 65minutes 0seconds",
        "0 h 65 m 0 s",
        "0 hour 65 min 0 sec",
        "0 hour 65 minute 0 second",
        "0 hours 65 minutes 0 seconds",
        "0d 0h 65m 0s",
        "0day 0hour 65min 0sec",
        "0day 0hour 65minute 0second",
        "0days 0hours 65minutes 0seconds",
        "0 d 0 h 65 m 0 s",
        "0 day 0 hour 65 min 0 sec",
        "0 day 0 hour 65 minute 0 second",
        "0 days 0 hours 65 minutes 0 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 65m 0 s 0ms",
        "0day 0hour 65min 0 sec 0ms",
        "0day 0 hour 65 minute 0second 0millisecond",
        "0days  0hours 65minutes 0 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of human-readable input strings that signify a time duration
    /// rolling over 24 hours, formatted in various valid notations.
    /// </summary>
    /// <remarks>
    /// This property is used to test parsing functionality for duration strings
    /// that normalize to a single day (24 hours). It includes variations with
    /// different formats, units, and separators to validate flexible input handling.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver24HoursInputs =>
    [
        "24h 0m 0s",
        "24hour 0min 0sec",
        "24hour 0minute 0second",
        "24hours 0minutes 0seconds",
        "24 h 0 m 0 s",
        "24 hour 0 min 0 sec",
        "24 hour 0 minute 0 second",
        "24 hours 0 minutes 0 seconds",
        "0d 24h 0m 0s",
        "0day 24hour 0min 0sec",
        "0day 24hour 0minute 0second",
        "0days 24hours 0minutes 0seconds",
        "0 d 24 h 0 m 0 s",
        "0 day 24 hour 0 min 0 sec",
        "0 day 24 hour 0 minute 0 second",
        "0 days 24 hours 0 minutes 0 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 24 h 0m 0 s 0ms",
        "0day 24hour 0min 0 sec 0ms",
        "0day 24 hour 0 minute 0second 0millisecond",
        "0days  24hours 0minutes 0 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of human-readable input strings that signify a time duration
    /// rolling over 25 hours, formatted in various valid notations.
    /// </summary>
    /// <remarks>
    /// This property provides test data with various syntactical representations of durations
    /// exceeding 24 hours, formatted in different combinations of hours, minutes, seconds,
    /// days, and optional milliseconds. It ensures the parsing method correctly identifies
    /// and processes these extended time inputs without errors or inaccuracies.
    /// </remarks>
    public static TheoryData<string> ValidRollingOver25HoursInputs =>
    [
        "25h 0m 0s",
        "25hour 0min 0sec",
        "25hour 0minute 0second",
        "25hours 0minutes 0seconds",
        "25 h 0 m 0 s",
        "25 hour 0 min 0 sec",
        "25 hour 0 minute 0 second",
        "25 hours 0 minutes 0 seconds",
        "0d 25h 0m 0s",
        "0day 25hour 0min 0sec",
        "0day 25hour 0minute 0second",
        "0days 25hours 0minutes 0seconds",
        "0 d 25 h 0 m 0 s",
        "0 day 25 hour 0 min 0 sec",
        "0 day 25 hour 0 minute 0 second",
        "0 days 25 hours 0 minutes 0 seconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 25 h 0m 0 s 0ms",
        "0day 25hour 0min 0 sec 0ms",
        "0day 25 hour 0 minute 0second 0millisecond",
        "0days  25hours 0minutes 0 seconds 0milliseconds"
    ];
}
