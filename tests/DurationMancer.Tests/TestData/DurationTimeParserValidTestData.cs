namespace DurationMancer.Tests.TestData;

public sealed class DurationTimeParserValidTestData
{
    /// <summary>
    /// Represents a collection of empty or whitespace-only input strings used for
    /// testing the duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test data that includes various empty string representations,
    /// such as blank strings, whitespace, tab, and newline characters. It ensures the parsing
    /// method correctly identifies and handles invalid, non-substantive inputs.
    /// </remarks>
    public static TheoryData<string> ValidEmptyInputs =>
    [
        "",
        " ",
        "   ",
        "\t",
        "\n",
        " \n "
    ];

    /// <summary>
    /// Represents a collection of valid human-readable and standard format zero-duration input strings used for
    /// testing the duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test data that includes a wide variety of zero-duration representations
    /// across different formats such as time spans, units, and mixed notations. It ensures that the
    /// parsing method can correctly identify and process inputs that denote a zero duration,
    /// regardless of the specific format or unit syntax used.
    /// </remarks>
    public static TheoryData<string> ValidZeroInputs =>
    [
        "00:00:00.0",
        "00:00:00.00",
        "00:00:00",
        "0.00:00:00",
        "00.00:00:00",
        "0ms",
        "0millisecond",
        "0milliseconds",
        "0 ms",
        "0 millisecond",
        "0 milliseconds",
        "0s",
        "0sec",
        "0second",
        "0seconds",
        "0 s",
        "0 sec",
        "0 second",
        "0 seconds",
        "0m",
        "0min",
        "0minute",
        "0minutes",
        "0 m",
        "0 min",
        "0 minute",
        "0 minutes",
        "0h",
        "0hour",
        "0hours",
        "0 h",
        "0 hour",
        "0 hours",
        "0d",
        "0day",
        "0days",
        "0 d",
        "0 day",
        "0 days",
        "0d 0h 0m 0s 0ms",
        "0day 0hour 0min 0sec 0ms",
        "0day 0hour 0minute 0second 0millisecond",
        "0days 0hours 0minutes 0seconds 0milliseconds",
        "0 d 0 h 0 m 0 s 0 ms",
        "0 day 0 hour 0 min 0 sec 0 ms",
        "0 day 0 hour 0 minute 0 second 0 millisecond",
        "0 days 0 hours 0 minutes 0 seconds 0 milliseconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 0m 0 s 0ms",
        "0day 0 hour 0min 0 sec 0ms",
        "0day 0 hour 0minute 0 second 0millisecond",
        "0days  0hours 0minutes 0 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of valid human-readable and standard format input strings
    /// that correctly parse to a duration of 3 seconds.
    /// </summary>
    /// <remarks>
    /// This property includes various formats and representations of a 3-second duration, such as
    /// time-formatted strings (e.g., "00:00:03"), shorthand notations (e.g., "3s"), and
    /// combinations of seconds with other time components like milliseconds, minutes, hours, or days.
    /// The provided inputs are used to verify the correctness and flexibility of the duration parsing logic.
    /// </remarks>
    public static TheoryData<string> Valid3SecondsInputs =>
    [
        "00:00:03",
        "00:00:03.0",
        "00:00:03.00",
        "0.00:00:03",
        "00.00:00:03",
        "3s",
        "3sec",
        "3second",
        "3seconds",
        "3 s",
        "3 sec",
        "3 second",
        "3 seconds",
        "3s 0ms",
        "3sec 0ms",
        "3second 0millisecond",
        "3seconds 0milliseconds",
        "3 s 0 ms",
        "3 sec 0 ms",
        "3 second 0 millisecond",
        "3 seconds 0 milliseconds",
        "0m 3s",
        "0min 3sec",
        "0minute 3second",
        "0minutes 3seconds",
        "0 m 3 s",
        "0 min 3 sec",
        "0 minute 3 second",
        "0 minutes 3 seconds",
        "0m 3s 0ms",
        "0min 3sec 0ms",
        "0minute 3second 0millisecond",
        "0minutes 3seconds 0milliseconds",
        "0 m 3 s 0 ms",
        "0 min 3 sec 0 ms",
        "0 minute 3 second 0 millisecond",
        "0 minutes 3 seconds 0 milliseconds",
        "0h 0m 3s",
        "0hour 0min 3sec",
        "0hour 0minute 3second",
        "0hours 0minutes 3seconds",
        "0 h 0 m 3 s",
        "0 hour 0 min 3 sec",
        "0 hour 0 minute 3 second",
        "0 hours 0 minutes 3 seconds",
        "0h 0m 3s 0ms",
        "0hour 0min 3sec 0ms",
        "0hour 0minute 3second 0millisecond",
        "0hours 0minutes 3seconds 0milliseconds",
        "0 h 0 m 3 s 0 ms",
        "0 hour 0 min 3 sec 0 ms",
        "0 hour 0 minute 3 second 0 millisecond",
        "0 hours 0 minutes 3 seconds 0 milliseconds",
        "0d 0h 0m 3s",
        "0day 0hour 0min 3sec",
        "0day 0hour 0minute 3second",
        "0days 0hours 0minutes 3seconds",
        "0 d 0 h 0 m 3 s",
        "0 day 0 hour 0 min 3 sec",
        "0 day 0 hour 0 minute 3 second",
        "0 days 0 hours 0 minutes 3 seconds",
        "0d 0h 0m 3s 0ms",
        "0day 0hour 0min 3sec 0ms",
        "0day 0hour 0minute 3second 0millisecond",
        "0days 0hours 0minutes 3seconds 0milliseconds",
        "0 d 0 h 0 m 3 s 0 ms",
        "0 day 0 hour 0 min 3 sec 0 ms",
        "0 day 0 hour 0 minute 3 second 0 millisecond",
        "0 days 0 hours 0 minutes 3 seconds 0 milliseconds",

        // Mixed w/ spaces and w/o spaces between units
        "0d 0 h 0m 3 s 0ms",
        "0day 0hour 0min 3 sec 0ms",
        "0day 0 hour 0 minute 3second 0millisecond",
        "0days  0hours 0minutes 3 seconds 0milliseconds"
    ];

    /// <summary>
    /// Represents a collection of test data consisting of valid standard duration format strings
    /// and their corresponding components for duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test cases that include well-formed duration strings
    /// following standard formatting conventions, such as "hh:mm:ss" or
    /// "d.hh:mm:ss.fff". The property also includes expected breakdowns of these
    /// strings into days, hours, minutes, seconds, and milliseconds to validate
    /// the parsing behavior of the duration parser.
    /// </remarks>
    public static TheoryData<string, int, int, int, int, int> ValidStandardDurationFormatInputs => new()
    {
        { "00:00:00", 0, 0, 0, 0, 0 }, // Zero time
        { "01:00:00", 0, 1, 0, 0, 0 }, // Hours only
        { "00:30:00", 0, 0, 30, 0, 0 }, // Minutes only
        { "00:00:45", 0, 0, 0, 45, 0 }, // Seconds only
        { "1.00:00:00", 1, 0, 0, 0, 0 }, // Days only
        { "00:00:00.500", 0, 0, 0, 0, 500 }, // With millisecond
        { "1.23:45:56.789", 1, 23, 45, 56, 789 } // Complex case
    };

    /// <summary>
    /// Valid negative inputs in standard duration format that should parse to the corresponding negative TimeSpan.
    /// </summary>
    public static TheoryData<string, int, int, int, int, int> ValidNegativeStandardDurationFormatInputs => new()
    {
        { "-00:00:00", 0, 0, 0, 0, 0 },
        { "-00:00:03", 0, 0, 0, -3, 0 },
        { "-01:00:00", 0, -1, 0, 0, 0 },
        { "-00:30:00", 0, 0, -30, 0, 0 },
        { "-1.00:00:00", -1, 0, 0, 0, 0 },
        { "-00:00:00.500", 0, 0, 0, 0, -500 },
        { "-1.23:45:56.789", -1, -23, -45, -56, -789 }
    };

    /// <summary>
    /// Represents a collection of valid human-readable duration format input strings
    /// mapped to their equivalent standardized time span representations.
    /// </summary>
    /// <remarks>
    /// This property provides test data for verifying the ability of the duration parsing
    /// functionality to correctly interpret and convert various human-readable duration
    /// formats, such as days, hours, minutes, seconds, and milliseconds, into their corresponding
    /// TimeSpan representations. The data includes diverse combinations of units with different
    /// syntaxes, ensuring robustness and accuracy in parsing.
    /// </remarks>
    public static TheoryData<string, string> ValidHumanReadableFormatInputs => new()
    {
        { "1d", "1.00:00:00" },
        { "2 days", "2.00:00:00" },
        { "3h", "03:00:00" },
        { "4 hours", "04:00:00" },
        { "5m", "00:05:00" },
        { "6 minutes", "00:06:00" },
        { "7s", "00:00:07" },
        { "8 seconds", "00:00:08" },
        { "100ms", "00:00:00.100" },
        { "1d 2h 3m 4s 500ms", "1.02:03:04.500" }
    };

    /// <summary>
    /// Valid negative inputs in human-readable format that should parse to the corresponding negative TimeSpan.
    /// </summary>
    public static TheoryData<string, string> ValidNegativeHumanReadableFormatInputs => new()
    {
        { "-1d", "-1.00:00:00" },
        { "-2 days", "-2.00:00:00" },
        { "-3h", "-03:00:00" },
        { "-4 hours", "-04:00:00" },
        { "-5m", "-00:05:00" },
        { "-6 minutes", "-00:06:00" },
        { "-7s", "-00:00:07" },
        { "-8 seconds", "-00:00:08" },
        { "-100ms", "-00:00:00.100" },
        { "-1d 2h 3m 4s 500ms", "-1.02:03:04.500" },
        { "- 3s", "-00:00:03" },
        { "-  1 day 2 hours 3 minutes 4 seconds 500 milliseconds", "-1.02:03:04.500" }
    };

    /// <summary>
    /// Represents a collection of valid human-readable input strings that include combinations of partial
    /// rolling-over and unrolling duration formats for testing duration parsing functionality.
    /// </summary>
    /// <remarks>
    /// This property provides test data where inputs combine mixed unrolling and rolling-over
    /// representations of time spans, such as mixtures of minutes, seconds, and fractional components.
    /// It ensures the parsing method correctly interprets and handles such inputs by normalizing
    /// and converting them into coherent TimeSpan values.
    /// </remarks>
    public static TheoryData<string, string> ValidMixedUnrollingAndRollingOverInputs => new()
    {
        { "69.5m 0.5s", "01:09:30.500" },
        { "0.3m 100.07s", "00:01:58.070" },
        { "0.01h 100.007s", "00:02:16.007" },
        { "0.0003d", "00:00:25.920" }
    };


    /// <summary>
    /// Valid inputs with case-insensitive unit abbreviations (uppercase, mixed case).
    /// The regex uses <see cref="System.Text.RegularExpressions.RegexOptions.IgnoreCase"/>,
    /// so these should all parse correctly.
    /// </summary>
    public static TheoryData<string, string> ValidCaseInsensitiveInputs => new()
    {
        // Uppercase abbreviations
        { "3S", "00:00:03" },
        { "5M", "00:05:00" },
        { "2H", "02:00:00" },
        { "1D", "1.00:00:00" },
        { "100MS", "00:00:00.100" },

        // Mixed case abbreviations
        { "3Sec", "00:00:03" },
        { "5Min", "00:05:00" },
        { "2Hour", "02:00:00" },
        { "1Day", "1.00:00:00" },
        { "100Milliseconds", "00:00:00.100" },

        // Full uppercase
        { "3SEC", "00:00:03" },
        { "5MINUTES", "00:05:00" },
        { "2HOURS", "02:00:00" },
        { "1DAY", "1.00:00:00" },
        { "100MILLISECONDS", "00:00:00.100" },

        // Mixed case with spaces
        { "1D 2H 3M 4S 500MS", "1.02:03:04.500" },
        { "1 Day 2 Hours 3 Minutes 4 Seconds 500 Milliseconds", "1.02:03:04.500" }
    };

    /// <summary>
    /// Valid inputs with leading/trailing whitespace that should be trimmed before parsing.
    /// </summary>
    public static TheoryData<string, string> ValidWhitespacePaddedInputs => new()
    {
        // Leading whitespace
        { "  3s", "00:00:03" },
        { "  00:00:03", "00:00:03" },

        // Trailing whitespace
        { "3s  ", "00:00:03" },
        { "00:00:03  ", "00:00:03" },

        // Both leading and trailing whitespace
        { "  3s  ", "00:00:03" },
        { "  00:00:03  ", "00:00:03" },
        { "  1d 2h 3m 4s 500ms  ", "1.02:03:04.500" },
        { "  1.23:45:56.789  ", "1.23:45:56.789" }
    };

    /// <summary>
    /// Valid standalone fractional unit inputs (e.g. "0.5d" → 12h, "0.5h" → 30m).
    /// </summary>
    public static TheoryData<string, string> ValidStandaloneFractionalUnitInputs => new()
    {
        // Fractional days
        { "0.5d", "12:00:00" },
        { "0.5 days", "12:00:00" },
        { "1.5d", "1.12:00:00" },

        // Fractional hours
        { "0.5h", "00:30:00" },
        { "0.5 hours", "00:30:00" },
        { "1.5h", "01:30:00" },

        // Fractional minutes
        { "0.5m", "00:00:30" },
        { "0.5 minutes", "00:00:30" },
        { "1.5m", "00:01:30" },

        // Fractional seconds
        { "0.5s", "00:00:00.500" },
        { "0.5 seconds", "00:00:00.500" },
        { "1.5s", "00:00:01.500" }
    };

    /// <summary>
    /// Valid negative inputs with fractional/unrolling values combined with the minus prefix.
    /// </summary>
    public static TheoryData<string, string> ValidNegativeUnrollingInputs => new()
    {
        // Negative fractional seconds
        { "-3.5s", "-00:00:03.500" },
        { "-3.5 seconds", "-00:00:03.500" },
        { "-0.5s", "-00:00:00.500" },

        // Negative fractional minutes
        { "-1.5m", "-00:01:30" },
        { "-1.5 minutes", "-00:01:30" },
        { "-0.5m", "-00:00:30" },

        // Negative fractional hours
        { "-1.5h", "-01:30:00" },
        { "-1.5 hours", "-01:30:00" },
        { "-0.5h", "-00:30:00" },

        // Negative fractional days
        { "-0.5d", "-12:00:00" },
        { "-0.5 days", "-12:00:00" },
        { "-1.5d", "-1.12:00:00" },

        // Negative combined fractional
        { "-1.25d 1.5h 1.5m 1.5s 7ms", "-1.07:31:31.507" },
        { "-1.5m 13ms", "-00:01:30.013" }
    };

    /// <summary>
    /// Valid negative inputs with mixed unrolling and rolling over values.
    /// </summary>
    public static TheoryData<string, string> ValidNegativeMixedUnrollingAndRollingOverInputs => new()
    {
        { "-69.5m 0.5s", "-01:09:30.500" },
        { "-0.3m 100.07s", "-00:01:58.070" },
        { "-0.01h 100.007s", "-00:02:16.007" },
        { "-0.0003d", "-00:00:25.920" }
    };

    /// <summary>
    /// Valid inputs near the <see cref="TimeSpan.MaxValue"/> and <see cref="TimeSpan.MinValue"/> boundaries.
    /// </summary>
    public static TheoryData<string, int, int, int, int, int> ValidBoundaryInputs => new()
    {
        // Large but valid standard format
        { "10675199.02:48:05.477", 10675199, 2, 48, 5, 477 },

        // Large but valid human-readable
        { "10675199d 2h 48m 5s 477ms", 10675199, 2, 48, 5, 477 },

        // Negative large but valid standard format
        { "-10675199.02:48:05.477", -10675199, -2, -48, -5, -477 },

        // Single day boundary
        { "365d", 365, 0, 0, 0, 0 },
        { "365 days", 365, 0, 0, 0, 0 }
    };
}
