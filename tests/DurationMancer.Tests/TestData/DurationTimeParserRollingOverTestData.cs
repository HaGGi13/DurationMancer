namespace DurationMancer.Tests.TestData;

public sealed class DurationTimeParserRollingOverTestData
{
    /// <summary>
    /// Duration inputs where 1000ms should roll over into 1 second.
    /// </summary>
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
    /// Negative duration inputs where -1000ms should roll over into -1 second.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver1000MillisecondsInputs =>
    [
        "-1000ms",
        "-1000 ms",
        "-1000milliseconds",
        "-1000 milliseconds",
        "-0s 1000ms",
        "-0 s 1000 ms",
        "-0m 0s 1000ms",
        "-0 minutes 0 seconds 1000 milliseconds",
        "-0h 0m 0s 1000ms",
        "-0 hours 0 minutes 0 seconds 1000 milliseconds",
        "-0d 0h 0m 0s 1000ms",
        "-0 days 0 hours 0 minutes 0 seconds 1000 milliseconds"
    ];

    /// <summary>
    /// Duration inputs where 1001ms should roll over into 1 second and 1 millisecond.
    /// </summary>
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
    /// Duration inputs where 60 seconds should roll over into 1 minute.
    /// </summary>
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
    /// Negative duration inputs where -60s should roll over into -1 minute.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver60SecondsInputs =>
    [
        "-60s",
        "-60 s",
        "-60sec",
        "-60 seconds",
        "-0m 60s",
        "-0 minutes 60 seconds",
        "-0h 0m 60s",
        "-0 hours 0 minutes 60 seconds",
        "-0d 0h 0m 60s",
        "-0 days 0 hours 0 minutes 60 seconds"
    ];

    /// <summary>
    /// Duration inputs where 65 seconds should roll over into 1 minute and 5 seconds.
    /// </summary>
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
    /// Duration inputs where 60 minutes should roll over into 1 hour.
    /// </summary>
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
    /// Negative duration inputs where -60m should roll over into -1 hour.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver60MinutesInputs =>
    [
        "-60m",
        "-60 m",
        "-60min",
        "-60 minutes",
        "-0h 60m",
        "-0 hours 60 minutes",
        "-0d 0h 60m",
        "-0 days 0 hours 60 minutes"
    ];

    /// <summary>
    /// Duration inputs where 65 minutes should roll over into 1 hour and 5 minutes.
    /// </summary>
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
    /// Duration inputs where 24 hours should roll over into 1 day.
    /// </summary>
    public static TheoryData<string> ValidRollingOver24HoursInputs =>
    [
        "24h",
        "24hour",
        "24hours",
        "24 h",
        "24 hour",
        "24 hours",
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
    /// Negative duration inputs where -24h should roll over into -1 day.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver24HoursInputs =>
    [
        "-24h",
        "-24 h",
        "-24hours",
        "-24 hours",
        "-24h 0m 0s",
        "-24 hours 0 minutes 0 seconds",
        "-0d 24h 0m 0s",
        "-0 days 24 hours 0 minutes 0 seconds"
    ];

    /// <summary>
    /// Duration inputs where 25 hours should roll over into 1 day and 1 hour.
    /// </summary>
    public static TheoryData<string> ValidRollingOver25HoursInputs =>
    [
        "25h",
        "25hour",
        "25hours",
        "25 h",
        "25 hour",
        "25 hours",
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

    /// <summary>
    /// Negative duration inputs where -25h should roll over into -1 day and -1 hour.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver25HoursInputs =>
    [
        "-25h",
        "-25 h",
        "-25hours",
        "-25 hours",
        "-25h 0m 0s",
        "-25 hours 0 minutes 0 seconds",
        "-0d 25h 0m 0s",
        "-0 days 25 hours 0 minutes 0 seconds"
    ];


    /// <summary>
    /// Negative duration inputs where -1001ms should roll over into -1 second and -1 millisecond.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver1001MillisecondsInputs =>
    [
        "-1001ms",
        "-1001 ms",
        "-1001milliseconds",
        "-1001 milliseconds",
        "-0s 1001ms",
        "-0 s 1001 ms",
        "-0m 0s 1001ms",
        "-0 minutes 0 seconds 1001 milliseconds",
        "-0h 0m 0s 1001ms",
        "-0 hours 0 minutes 0 seconds 1001 milliseconds",
        "-0d 0h 0m 0s 1001ms",
        "-0 days 0 hours 0 minutes 0 seconds 1001 milliseconds"
    ];

    /// <summary>
    /// Negative duration inputs where -65s should roll over into -1 minute and -5 seconds.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver65SecondsInputs =>
    [
        "-65s",
        "-65 s",
        "-65sec",
        "-65 seconds",
        "-0m 65s",
        "-0 minutes 65 seconds",
        "-0h 0m 65s",
        "-0 hours 0 minutes 65 seconds",
        "-0d 0h 0m 65s",
        "-0 days 0 hours 0 minutes 65 seconds"
    ];

    /// <summary>
    /// Negative duration inputs where -65m should roll over into -1 hour and -5 minutes.
    /// </summary>
    public static TheoryData<string> ValidNegativeRollingOver65MinutesInputs =>
    [
        "-65m",
        "-65 m",
        "-65min",
        "-65 minutes",
        "-0h 65m",
        "-0 hours 65 minutes",
        "-0d 0h 65m",
        "-0 days 0 hours 65 minutes"
    ];

    /// <summary>
    /// Negative rolling over with non-zero higher components (e.g. "-1m 60s" → -2m, "-1d 24h" → -2d).
    /// </summary>
    public static TheoryData<string, string> ValidNegativeRollingOverWithNonZeroHigherComponentInputs => new()
    {
        // Milliseconds rolling into non-zero seconds
        { "-5s 1000ms", "-00:00:06" },
        { "-5 seconds 1000 milliseconds", "-00:00:06" },
        { "-59s 1000ms", "-00:01:00" },

        // Seconds rolling into non-zero minutes
        { "-1m 60s", "-00:02:00" },
        { "-1 minute 60 seconds", "-00:02:00" },
        { "-5m 65s", "-00:06:05" },
        { "-5 minutes 65 seconds", "-00:06:05" },

        // Minutes rolling into non-zero hours
        { "-1h 60m", "-02:00:00" },
        { "-1 hour 60 minutes", "-02:00:00" },
        { "-2h 65m", "-03:05:00" },
        { "-2 hours 65 minutes", "-03:05:00" },

        // Hours rolling into non-zero days
        { "-1d 24h", "-2.00:00:00" },
        { "-1 day 24 hours", "-2.00:00:00" },
        { "-1d 25h", "-2.01:00:00" },
        { "-1 day 25 hours", "-2.01:00:00" },
        { "-2d 48h", "-4.00:00:00" },
        { "-2 days 48 hours", "-4.00:00:00" }
    };

    /// <summary>
    /// Negative multi-level cascading rolling over (e.g. "-59m 60s" → -1h, "-23h 59m 60s" → -1d).
    /// </summary>
    public static TheoryData<string, string> ValidNegativeMultiLevelCascadingRollingOverInputs => new()
    {
        // Seconds cascade through minutes to hours
        { "-59m 60s", "-01:00:00" },
        { "-59 minutes 60 seconds", "-01:00:00" },
        { "-59m 61s", "-01:00:01" },

        // Seconds cascade through minutes and hours to days
        { "-23h 59m 60s", "-1.00:00:00" },
        { "-23 hours 59 minutes 60 seconds", "-1.00:00:00" },

        // Milliseconds cascade through seconds to minutes
        { "-0m 59s 1000ms", "-00:01:00" },
        { "-0 minutes 59 seconds 1000 milliseconds", "-00:01:00" },

        // Full cascade: milliseconds → seconds → minutes → hours → days
        { "-23h 59m 59s 1000ms", "-1.00:00:00" },
        { "-23 hours 59 minutes 59 seconds 1000 milliseconds", "-1.00:00:00" },

        // Multiple levels with non-zero higher components
        { "-1d 23h 59m 60s", "-2.00:00:00" },
        { "-1 day 23 hours 59 minutes 60 seconds", "-2.00:00:00" },
        { "-1d 23h 60m", "-2.00:00:00" },
        { "-1 day 23 hours 60 minutes", "-2.00:00:00" }
    };

    /// <summary>
    /// Rolling over with non-zero higher components (e.g. "1m 60s" → 2m, "1d 24h" → 2d).
    /// </summary>
    public static TheoryData<string, string> ValidRollingOverWithNonZeroHigherComponentInputs => new()
    {
        // Milliseconds rolling into non-zero seconds
        { "5s 1000ms", "00:00:06" },
        { "5 seconds 1000 milliseconds", "00:00:06" },
        { "59s 1000ms", "00:01:00" },
        { "59 seconds 1001 milliseconds", "00:01:00.001" },

        // Seconds rolling into non-zero minutes
        { "1m 60s", "00:02:00" },
        { "1 minute 60 seconds", "00:02:00" },
        { "5m 65s", "00:06:05" },
        { "5 minutes 65 seconds", "00:06:05" },

        // Minutes rolling into non-zero hours
        { "1h 60m", "02:00:00" },
        { "1 hour 60 minutes", "02:00:00" },
        { "2h 65m", "03:05:00" },
        { "2 hours 65 minutes", "03:05:00" },

        // Hours rolling into non-zero days
        { "1d 24h", "2.00:00:00" },
        { "1 day 24 hours", "2.00:00:00" },
        { "1d 25h", "2.01:00:00" },
        { "1 day 25 hours", "2.01:00:00" },
        { "2d 48h", "4.00:00:00" },
        { "2 days 48 hours", "4.00:00:00" }
    };

    /// <summary>
    /// Multi-level cascading rolling over (e.g. "59m 60s" → 1h, "23h 59m 60s" → 1d).
    /// </summary>
    public static TheoryData<string, string> ValidMultiLevelCascadingRollingOverInputs => new()
    {
        // Seconds cascade through minutes to hours
        { "59m 60s", "01:00:00" },
        { "59 minutes 60 seconds", "01:00:00" },
        { "59m 61s", "01:00:01" },

        // Seconds cascade through minutes and hours to days
        { "23h 59m 60s", "1.00:00:00" },
        { "23 hours 59 minutes 60 seconds", "1.00:00:00" },

        // Milliseconds cascade through seconds to minutes
        { "0m 59s 1000ms", "00:01:00" },
        { "0 minutes 59 seconds 1000 milliseconds", "00:01:00" },
        { "0m 59s 1001ms", "00:01:00.001" },

        // Milliseconds cascade through seconds and minutes to hours
        { "59m 59s 1000ms", "01:00:00" },
        { "59 minutes 59 seconds 1000 milliseconds", "01:00:00" },

        // Full cascade: milliseconds → seconds → minutes → hours → days
        { "23h 59m 59s 1000ms", "1.00:00:00" },
        { "23 hours 59 minutes 59 seconds 1000 milliseconds", "1.00:00:00" },

        // Multiple levels with non-zero higher components
        { "1d 23h 59m 60s", "2.00:00:00" },
        { "1 day 23 hours 59 minutes 60 seconds", "2.00:00:00" },
        { "1d 23h 60m", "2.00:00:00" },
        { "1 day 23 hours 60 minutes", "2.00:00:00" }
    };
}
