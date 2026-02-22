using System.Globalization;
using System.Text.RegularExpressions;

namespace DurationMancer;

/// <summary>
/// Provides methods for parsing various duration string formats into a <see cref="TimeSpan" />.
/// </summary>
public static partial class DurationTimeParser
{
    private const string DaysPattern = @"(?<days>\d+(?:\.\d+)?)\s*(d|day|days)\b";
    private const string HoursPattern = @"(?<hours>\d+(?:\.\d+)?)\s*(h|hour|hours)\b";
    private const string MillisecondsPattern = @"(?<milliseconds>\d+)\s*(ms|millisecond|milliseconds)\b";
    private const string MinutesPattern = @"(?<minutes>\d+(?:\.\d+)?)\s*(m|min|minute|minutes)\b";
    private const string SecondsPattern = @"(?<seconds>\d+(?:\.\d+)?)\s*(s|sec|second|seconds)\b";

    private const string StandardDurationTimeFormat =
        @"^(?:(?<d>\d+)\.)?(?<hh>[01]\d|2[0-3]):(?<mm>[0-5]\d):(?<ss>[0-5]\d)(?:\.(?<ms>\d{0,3}))?$";

    private const string TimePattern = $"{StandardDurationTimeFormat}|" +
                                       @$"^(?:{DaysPattern})?\s*" +
                                       @$"(?:{HoursPattern})?\s*" +
                                       @$"(?:{MinutesPattern})?\s*" +
                                       @$"(?:{SecondsPattern})?\s*" +
                                       $"(?:{MillisecondsPattern})?$";

    private static readonly Regex TimeRegex = CreateTimeFormatRegex();

    [GeneratedRegex(TimePattern, RegexOptions.IgnoreCase)]
    private static partial Regex CreateTimeFormatRegex();

    /// <summary>
    /// Tries to parse a given input string into a <see cref="TimeSpan" /> representation.
    /// Supports standard duration format and human-readable duration format.
    /// </summary>
    /// <param name="input">The input string that represents a duration in a valid format.</param>
    /// <param name="timeSpan">The parsed <see cref="TimeSpan" /> value if parsing is successful; otherwise <see cref="TimeSpan.Zero" />.</param>
    /// <returns><c>true</c> if the input string was successfully parsed into a valid <see cref="TimeSpan" />; otherwise <c>false</c>.</returns>
    /// <remarks>
    /// Supports two format types:
    /// <para>
    /// 1. Standard duration format:<br />
    /// - [d.]HH:mm:ss[.fff]<br />
    /// 2. Human-readable format with combinations of:<br />
    /// - days: "1d", "2 days"<br />
    /// - hours: "1h", "2 hours"<br />
    /// - minutes: "1m", "5 minutes"<br />
    /// - seconds: "1s", "30 seconds"<br />
    /// - milliseconds: "100ms", "500 milliseconds"<br />
    /// <br />
    /// Examples of valid human-readable formats:<br />
    /// - "1s"<br />
    /// - "5 minutes"<br />
    /// - "3m 10s"<br />
    /// - "1 hour 30 minutes"<br />
    /// - "2 days 4 hours 15m 30s"<br />
    /// </para>
    /// </remarks>
    public static bool TryParse(string? input, out TimeSpan timeSpan)
    {
        timeSpan = TimeSpan.Zero;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        input = input.Trim();

        var match = TimeRegex.Match(input);
        if (!match.Success)
        {
            return false;
        }

        return TryParseDurationFormat(match, out timeSpan) ||
               TryParseHumanReadableDurationFormat(match, out timeSpan);
    }

    /// <summary>
    /// Tries to parse a possibly matched time in duration format [d.]HH:mm:ss[.fff].
    /// </summary>
    /// <param name="match">Possibly RegEx match that contains values to process.</param>
    /// <param name="result">The parsed result object, if successfully parsed; otherwise <see cref="TimeSpan.Zero" />.</param>
    /// <returns><c>true</c> if successfully parsed; otherwise <c>false</c></returns>
    private static bool TryParseDurationFormat(Match match, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        // Caching the group in a variable to avoid multiple string lookups by calling .Success and .Value
        var hoursGroup = match.Groups["hh"];

        // Check if the standard format was used, if so, hours must be given
        if (!hoursGroup.Success)
        {
            return false;
        }

        var daysGroup = match.Groups["d"];
        var minutesGroup = match.Groups["mm"];
        var secondsGroup = match.Groups["ss"];
        var millisecondsGroup = match.Groups["ms"];

        // Use .ValueSpan to avoid string allocations, for better performance
        _ = int.TryParse(daysGroup.ValueSpan, out var days);
        _ = int.TryParse(hoursGroup.ValueSpan, out var hours);
        _ = int.TryParse(minutesGroup.ValueSpan, out var minutes);
        _ = int.TryParse(secondsGroup.ValueSpan, out var seconds);
        _ = int.TryParse(millisecondsGroup.ValueSpan, out var milliseconds);

        result = new TimeSpan(days, hours, minutes, seconds, milliseconds);

        return true;
    }

    /// <summary>
    /// Parses a possibly matched time in human-readable duration format. For instance, like "1h 13m 2s", "5 sec" or "10min 30s".
    /// </summary>
    /// <param name="match">Possibly RegEx match that contains values to process.</param>
    /// <param name="result">The parsed result object, if successfully parsed; otherwise <see cref="TimeSpan.Zero" />.</param>
    /// <returns>The parsed result object.</returns>
    private static bool TryParseHumanReadableDurationFormat(Match match, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        try
        {
            var daysGroup = match.Groups["days"];
            var hoursGroup = match.Groups["hours"];
            var minutesGroup = match.Groups["minutes"];
            var secondsGroup = match.Groups["seconds"];
            var millisecondsGroup = match.Groups["milliseconds"];

            // Use .ValueSpan to avoid string allocations, for better performance
            var days = daysGroup.Success
                ? double.Parse(daysGroup.ValueSpan, CultureInfo.InvariantCulture)
                : 0;

            var hours = hoursGroup.Success
                ? double.Parse(hoursGroup.ValueSpan, CultureInfo.InvariantCulture)
                : 0;

            var minutes = minutesGroup.Success
                ? double.Parse(minutesGroup.ValueSpan, CultureInfo.InvariantCulture)
                : 0;

            var seconds = secondsGroup.Success
                ? double.Parse(secondsGroup.ValueSpan, CultureInfo.InvariantCulture)
                : 0;

            var milliSeconds = millisecondsGroup.Success
                ? int.Parse(millisecondsGroup.ValueSpan, CultureInfo.InvariantCulture)
                : 0;

            var timeSpan = TimeSpan.FromDays(days) +
                           TimeSpan.FromHours(hours) +
                           TimeSpan.FromMinutes(minutes) +
                           TimeSpan.FromSeconds(seconds) +
                           TimeSpan.FromMilliseconds(milliSeconds);

            // As we do not support nanoseconds or ticks, we have to round to the nearest millisecond
            result = RoundOnMilliseconds(timeSpan);
        }
        catch (Exception e) when (e is FormatException or OverflowException)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Rounds a given <see cref="TimeSpan" /> to the nearest milliseconds with a precision of 1 millisecond.
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan" /> instance to round.</param>
    /// <returns>The new rounded <see cref="TimeSpan" /> instance.</returns>
    private static TimeSpan RoundOnMilliseconds(TimeSpan timeSpan)
    {
        var roundedTicks =
            (long)(Math.Round((double)timeSpan.Ticks / TimeSpan.TicksPerMillisecond) * TimeSpan.TicksPerMillisecond);

        return new TimeSpan(roundedTicks);
    }
}
