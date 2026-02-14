using AwesomeAssertions;

namespace DurationMancer.Tests;

public sealed class DurationTimeParserTests
{
    [Theory]
    [InlineData("00:00:00.0")]
    [InlineData("00:00:00.00")]
    [InlineData("00:00:00")]
    [InlineData("0.00:00:00")]
    [InlineData("00.00:00:00")]
    [InlineData("0ms")]
    [InlineData("0millisecond")]
    [InlineData("0milliseconds")]
    [InlineData("0 ms")]
    [InlineData("0 millisecond")]
    [InlineData("0 milliseconds")]
    [InlineData("0s")]
    [InlineData("0sec")]
    [InlineData("0second")]
    [InlineData("0seconds")]
    [InlineData("0 s")]
    [InlineData("0 sec")]
    [InlineData("0 second")]
    [InlineData("0 seconds")]
    [InlineData("0m")]
    [InlineData("0min")]
    [InlineData("0minute")]
    [InlineData("0minutes")]
    [InlineData("0 m")]
    [InlineData("0 min")]
    [InlineData("0 minute")]
    [InlineData("0 minutes")]
    [InlineData("0h")]
    [InlineData("0hour")]
    [InlineData("0hours")]
    [InlineData("0 h")]
    [InlineData("0 hour")]
    [InlineData("0 hours")]
    [InlineData("0d")]
    [InlineData("0day")]
    [InlineData("0days")]
    [InlineData("0 d")]
    [InlineData("0 day")]
    [InlineData("0 days")]
    [InlineData("0d 0h 0m 0s 0ms")]
    [InlineData("0day 0hour 0min 0sec 0ms")]
    [InlineData("0day 0hour 0minute 0second 0millisecond")]
    [InlineData("0days 0hours 0minutes 0seconds 0milliseconds")]
    [InlineData("0 d 0 h 0 m 0 s 0 ms")]
    [InlineData("0 day 0 hour 0 min 0 sec 0 ms")]
    [InlineData("0 day 0 hour 0 minute 0 second 0 millisecond")]
    [InlineData("0 days 0 hours 0 minutes 0 seconds 0 milliseconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 0m 0 s 0ms")]
    [InlineData("0day 0 hour 0min 0 sec 0ms")]
    [InlineData("0day 0 hour 0minute 0 second 0millisecond")]
    [InlineData("0days  0hours 0minutes 0 seconds 0milliseconds")]
    public void TryParse_ZeroInput_ReturnsTrueAndTimeSpanZero(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(TimeSpan.Zero);
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("00:00:03")]
    [InlineData("00:00:03.0")]
    [InlineData("00:00:03.00")]
    [InlineData("0.00:00:03")]
    [InlineData("00.00:00:03")]
    [InlineData("3s")]
    [InlineData("3sec")]
    [InlineData("3second")]
    [InlineData("3seconds")]
    [InlineData("3 s")]
    [InlineData("3 sec")]
    [InlineData("3 second")]
    [InlineData("3 seconds")]
    [InlineData("3s 0ms")]
    [InlineData("3sec 0ms")]
    [InlineData("3second 0millisecond")]
    [InlineData("3seconds 0milliseconds")]
    [InlineData("3 s 0 ms")]
    [InlineData("3 sec 0 ms")]
    [InlineData("3 second 0 millisecond")]
    [InlineData("3 seconds 0 milliseconds")]
    [InlineData("0m 3s")]
    [InlineData("0min 3sec")]
    [InlineData("0minute 3second")]
    [InlineData("0minutes 3seconds")]
    [InlineData("0 m 3 s")]
    [InlineData("0 min 3 sec")]
    [InlineData("0 minute 3 second")]
    [InlineData("0 minutes 3 seconds")]
    [InlineData("0m 3s 0ms")]
    [InlineData("0min 3sec 0ms")]
    [InlineData("0minute 3second 0millisecond")]
    [InlineData("0minutes 3seconds 0milliseconds")]
    [InlineData("0 m 3 s 0 ms")]
    [InlineData("0 min 3 sec 0 ms")]
    [InlineData("0 minute 3 second 0 millisecond")]
    [InlineData("0 minutes 3 seconds 0 milliseconds")]
    [InlineData("0h 0m 3s")]
    [InlineData("0hour 0min 3sec")]
    [InlineData("0hour 0minute 3second")]
    [InlineData("0hours 0minutes 3seconds")]
    [InlineData("0 h 0 m 3 s")]
    [InlineData("0 hour 0 min 3 sec")]
    [InlineData("0 hour 0 minute 3 second")]
    [InlineData("0 hours 0 minutes 3 seconds")]
    [InlineData("0h 0m 3s 0ms")]
    [InlineData("0hour 0min 3sec 0ms")]
    [InlineData("0hour 0minute 3second 0millisecond")]
    [InlineData("0hours 0minutes 3seconds 0milliseconds")]
    [InlineData("0 h 0 m 3 s 0 ms")]
    [InlineData("0 hour 0 min 3 sec 0 ms")]
    [InlineData("0 hour 0 minute 3 second 0 millisecond")]
    [InlineData("0 hours 0 minutes 3 seconds 0 milliseconds")]
    [InlineData("0d 0h 0m 3s")]
    [InlineData("0day 0hour 0min 3sec")]
    [InlineData("0day 0hour 0minute 3second")]
    [InlineData("0days 0hours 0minutes 3seconds")]
    [InlineData("0 d 0 h 0 m 3 s")]
    [InlineData("0 day 0 hour 0 min 3 sec")]
    [InlineData("0 day 0 hour 0 minute 3 second")]
    [InlineData("0 days 0 hours 0 minutes 3 seconds")]
    [InlineData("0d 0h 0m 3s 0ms")]
    [InlineData("0day 0hour 0min 3sec 0ms")]
    [InlineData("0day 0hour 0minute 3second 0millisecond")]
    [InlineData("0days 0hours 0minutes 3seconds 0milliseconds")]
    [InlineData("0 d 0 h 0 m 3 s 0 ms")]
    [InlineData("0 day 0 hour 0 min 3 sec 0 ms")]
    [InlineData("0 day 0 hour 0 minute 3 second 0 millisecond")]
    [InlineData("0 days 0 hours 0 minutes 3 seconds 0 milliseconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 0m 3 s 0ms")]
    [InlineData("0day 0hour 0min 3 sec 0ms")]
    [InlineData("0day 0 hour 0 minute 3second 0millisecond")]
    [InlineData("0days  0hours 0minutes 3 seconds 0milliseconds")]
    public void TryParse_ThreeSecondsInput_ReturnsTrueAndTimeSpanWithThreeSeconds(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 0, 3));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("00:00:00", 0, 0, 0, 0)] // Zero time
    [InlineData("01:00:00", 0, 1, 0, 0)] // Hours only
    [InlineData("00:30:00", 0, 0, 30, 0)] // Minutes only
    [InlineData("00:00:45", 0, 0, 0, 45)] // Seconds only
    [InlineData("1.00:00:00", 1, 0, 0, 0)] // Days only
    [InlineData("00:00:00.500", 0, 0, 0, 0, 500)] // With milliseconds
    [InlineData("1.23:45:56.789", 1, 23, 45, 56, 789)] // Complex case
    public void TryParse_StandardDurationFormat_ShouldParseCorrectly(string input, int days, int hours, int minutes, int seconds,
        int milliseconds = 0)
    {
        // Arrange
        var expected = new TimeSpan(days, hours, minutes, seconds, milliseconds);

        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(expected);
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("1d", "1.00:00:00")]
    [InlineData("2 days", "2.00:00:00")]
    [InlineData("3h", "03:00:00")]
    [InlineData("4 hours", "04:00:00")]
    [InlineData("5m", "00:05:00")]
    [InlineData("6 minutes", "00:06:00")]
    [InlineData("7s", "00:00:07")]
    [InlineData("8 seconds", "00:00:08")]
    [InlineData("100ms", "00:00:00.100")]
    [InlineData("1d 2h 3m 4s 500ms", "1.02:03:04.500")]
    public void TryParse_HumanReadableFormat_ShouldParseCorrectly(string input, string result)
    {
        // Arrange
        _ = TimeSpan.TryParse(result, out var expectedResult);

        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Arrange
        parsedValue.Should().Be(expectedResult);
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("69.5m 0.5s", "01:09:30.500")]
    [InlineData("0.3m 100.07s", "00:01:58.070")]
    [InlineData("0.01h 100.007s", "00:02:16.007")]
    [InlineData("0.0003d", "00:00:25.920")]
    public void TryParse_MixedUnrollingAndRollingOverInput_ReturnsTrueAndTimeSpanWithCorrectValue(string input, string result)
    {
        // Arrange
        _ = TimeSpan.TryParse(result, out var expectedResult);

        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(expectedResult);
        parsedResult.Should().BeTrue();
    }

    #region Invalid input tests

    [Fact]
    public void TryParse_NullInput_ReturnsFalseAndTimeSpanZero()
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(null, out var parsedValue);

        // Assert
        parsedValue.Should().Be(TimeSpan.Zero);
        parsedResult.Should().BeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData(" \n ")]
    public void TryParse_EmptyInput_ReturnsFalseAndTimeSpanZero(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(TimeSpan.Zero);
        parsedResult.Should().BeFalse();
    }

    [Theory]
    [InlineData("Foo")]
    [InlineData(" Bar")]
    [InlineData("Foo 3s")]
    [InlineData("3s Bar")]
    [InlineData("Foo 00:00:03")]
    [InlineData("00:00:03 Bar")]
    [InlineData("Foo 00:00:03 Bar")]
    [InlineData("3house")]
    [InlineData("3 house")]
    [InlineData("3houses")]
    [InlineData("3 houses")]
    [InlineData("invalid")]
    [InlineData("0h0m3s")]
    [InlineData("0m 3s 1m")]
    [InlineData("3s 1h")]
    [InlineData("+3s")]
    [InlineData("-3s")]
    [InlineData("3,5s")]
    [InlineData("3,005s")]
    [InlineData("3,005.0s")]
    [InlineData("3,5 s")]
    [InlineData("1y")]
    [InlineData("1d 2x")]
    [InlineData("00:00")]
    [InlineData("00:00.0")]
    [InlineData("0.00:00")]
    [InlineData("00:00:60")]
    [InlineData("00:00:61")]
    [InlineData("00:60:00")]
    [InlineData("00:61:00")]
    [InlineData("24:00:00")]
    [InlineData("25:00:00")]
    [InlineData("00:00:00.0001")]
    [InlineData("00:00:60.0")]
    [InlineData("00:00:61.0")]
    [InlineData("00:60:00.0")]
    [InlineData("00:61:00.0")]
    [InlineData("24:00:00.0")]
    [InlineData("25:00:00.0")]
    [InlineData("0.00:00:60")]
    [InlineData("0.00:00:61")]
    [InlineData("0.00:60:00")]
    [InlineData("0.00:61:00")]
    [InlineData("0.24:00:00")]
    [InlineData("0.25:00:00")]
    [InlineData("1E+999999999 days")] // The value is too large for double.Parse and will throw OverflowException
    [InlineData("1.2.3 days")] // The double.Parse will throw FormatException due to multiple decimal points
    [InlineData(
        "999999999 days 23 hours 59 minutes 59 seconds")] // This will cause TimeSpan overflow when components are added together
    [InlineData("1 day 2.5ms")] // int.Parse will throw FormatException due to an invalid integer format
    public void TryParse_InvalidInput_ReturnsFalseAndTimeSpanZero(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(TimeSpan.Zero);
        parsedResult.Should().BeFalse();
    }

    #endregion

    #region Value rolling over tests that result in next bigger unit

    [Theory]
    [InlineData("1000ms")]
    [InlineData("1000millisecond")]
    [InlineData("1000milliseconds")]
    [InlineData("1000 ms")]
    [InlineData("1000 millisecond")]
    [InlineData("1000 milliseconds")]
    [InlineData("0s 1000ms")]
    [InlineData("0sec 1000ms")]
    [InlineData("0second 1000millisecond")]
    [InlineData("0seconds 1000milliseconds")]
    [InlineData("0 s 1000 ms")]
    [InlineData("0 sec 1000 ms")]
    [InlineData("0 second 1000 millisecond")]
    [InlineData("0 seconds 1000 milliseconds")]
    [InlineData("0m 0s 1000ms")]
    [InlineData("0min 0sec 1000ms")]
    [InlineData("0minute 0second 1000millisecond")]
    [InlineData("0minutes 0seconds 1000milliseconds")]
    [InlineData("0 m 0 s 1000 ms")]
    [InlineData("0 min 0 sec 1000 ms")]
    [InlineData("0 minute 0 second 1000 millisecond")]
    [InlineData("0 minutes 0 seconds 1000 milliseconds")]
    [InlineData("0h 0m 0s 1000ms")]
    [InlineData("0hour 0min 0sec 1000ms")]
    [InlineData("0hour 0minute 0second 1000millisecond")]
    [InlineData("0hours 0minutes 0seconds 1000milliseconds")]
    [InlineData("0 h 0 m 0 s 1000 ms")]
    [InlineData("0 hour 0 min 0 sec 1000 ms")]
    [InlineData("0 hour 0 minute 0 second 1000 millisecond")]
    [InlineData("0 hours 0 minutes 0 seconds 1000 milliseconds")]
    [InlineData("0d 0h 0m 0s 1000ms")]
    [InlineData("0day 0hour 0min 0sec 1000ms")]
    [InlineData("0day 0hour 0minute 0second 1000millisecond")]
    [InlineData("0days 0hours 0minutes 0seconds 1000milliseconds")]
    [InlineData("0 d 0 h 0 m 0 s 1000 ms")]
    [InlineData("0 day 0 hour 0 min 0 sec 1000 ms")]
    [InlineData("0 day 0 hour 0 minute 0 second 1000 millisecond")]
    [InlineData("0 days 0 hours 0 minutes 0 seconds 1000 milliseconds")]
    public void TryParse_RollingOverThousandMillisecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneSecond(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 0, 1));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("1001ms")]
    [InlineData("1001millisecond")]
    [InlineData("1001milliseconds")]
    [InlineData("1001 ms")]
    [InlineData("1001 millisecond")]
    [InlineData("1001 milliseconds")]
    [InlineData("0s 1001ms")]
    [InlineData("0sec 1001ms")]
    [InlineData("0second 1001millisecond")]
    [InlineData("0seconds 1001milliseconds")]
    [InlineData("0 s 1001 ms")]
    [InlineData("0 sec 1001 ms")]
    [InlineData("0 second 1001 millisecond")]
    [InlineData("0 seconds 1001 milliseconds")]
    [InlineData("0m 0s 1001ms")]
    [InlineData("0min 0sec 1001ms")]
    [InlineData("0minute 0second 1001millisecond")]
    [InlineData("0minutes 0seconds 1001milliseconds")]
    [InlineData("0 m 0 s 1001 ms")]
    [InlineData("0 min 0 sec 1001 ms")]
    [InlineData("0 minute 0 second 1001 millisecond")]
    [InlineData("0 minutes 0 seconds 1001 milliseconds")]
    [InlineData("0h 0m 0s 1001ms")]
    [InlineData("0hour 0min 0sec 1001ms")]
    [InlineData("0hour 0minute 0second 1001millisecond")]
    [InlineData("0hours 0minutes 0seconds 1001milliseconds")]
    [InlineData("0 h 0 m 0 s 1001 ms")]
    [InlineData("0 hour 0 min 0 sec 1001 ms")]
    [InlineData("0 hour 0 minute 0 second 1001 millisecond")]
    [InlineData("0 hours 0 minutes 0 seconds 1001 milliseconds")]
    [InlineData("0d 0h 0m 0s 1001ms")]
    [InlineData("0day 0hour 0min 0sec 1001ms")]
    [InlineData("0day 0hour 0minute 0second 1001millisecond")]
    [InlineData("0days 0hours 0minutes 0seconds 1001milliseconds")]
    [InlineData("0 d 0 h 0 m 0 s 1001 ms")]
    [InlineData("0 day 0 hour 0 min 0 sec 1001 ms")]
    [InlineData("0 day 0 hour 0 minute 0 second 1001 millisecond")]
    [InlineData("0 days 0 hours 0 minutes 0 seconds 1001 milliseconds")]
    public void
        TryParse_RollingOverThousandAndOneMillisecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneSecondAndOneMillisecond(
            string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 0, 0, 1, 1));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("60s")]
    [InlineData("60sec")]
    [InlineData("60second")]
    [InlineData("60seconds")]
    [InlineData("60 s")]
    [InlineData("60 sec")]
    [InlineData("60 second")]
    [InlineData("60 seconds")]
    [InlineData("0m 60s")]
    [InlineData("0min 60sec")]
    [InlineData("0minute 60second")]
    [InlineData("0minutes 60seconds")]
    [InlineData("0 m 60 s")]
    [InlineData("0 min 60 sec")]
    [InlineData("0 minute 60 second")]
    [InlineData("0 minutes 60 seconds")]
    [InlineData("0h 0m 60s")]
    [InlineData("0hour 0min 60sec")]
    [InlineData("0hour 0minute 60second")]
    [InlineData("0hours 0minutes 60seconds")]
    [InlineData("0 h 0 m 60 s")]
    [InlineData("0 hour 0 min 60 sec")]
    [InlineData("0 hour 0 minute 60 second")]
    [InlineData("0 hours 0minutes 60seconds")]
    [InlineData("0d 0h 0m 60s")]
    [InlineData("0day 0hour 0min 60sec")]
    [InlineData("0day 0hour 0minute 60second")]
    [InlineData("0days 0hours 0minutes 60seconds")]
    [InlineData("0 d 0 h 0 m 60 s")]
    [InlineData("0 day 0 hour 0 min 60 sec")]
    [InlineData("0 day 0 hour 0 minute 60 second")]
    [InlineData("0 days 0 hours 0minutes 60 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 0m 60 s 0ms")]
    [InlineData("0day 0hour 0min 60 sec 0ms")]
    [InlineData("0day 0 hour 0 minute 60second 0millisecond")]
    [InlineData("0days  0hours 0minutes 60 seconds 0milliseconds")]
    public void TryParse_RollingOverSixtySecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneMinute(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 1, 0));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("65s")]
    [InlineData("65sec")]
    [InlineData("65second")]
    [InlineData("65seconds")]
    [InlineData("65 s")]
    [InlineData("65 sec")]
    [InlineData("65 second")]
    [InlineData("65 seconds")]
    [InlineData("0m 65s")]
    [InlineData("0min 65sec")]
    [InlineData("0minute 65second")]
    [InlineData("0minutes 65seconds")]
    [InlineData("0 m 65 s")]
    [InlineData("0 min 65 sec")]
    [InlineData("0 minute 65 second")]
    [InlineData("0 minutes 65 seconds")]
    [InlineData("0h 0m 65s")]
    [InlineData("0hour 0min 65sec")]
    [InlineData("0hour 0minute 65second")]
    [InlineData("0hours 0minutes 65seconds")]
    [InlineData("0 h 0 m 65 s")]
    [InlineData("0 hour 0 min 65 sec")]
    [InlineData("0 hour 0 minute 65 second")]
    [InlineData("0 hours 0minutes 65seconds")]
    [InlineData("0d 0h 0m 65s")]
    [InlineData("0day 0hour 0min 65sec")]
    [InlineData("0day 0hour 0minute 65second")]
    [InlineData("0days 0hours 0minutes 65seconds")]
    [InlineData("0 d 0 h 0 m 65 s")]
    [InlineData("0 day 0 hour 0 min 65 sec")]
    [InlineData("0 day 0 hour 0 minute 65 second")]
    [InlineData("0 days 0 hours 0minutes 65 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 0m 65 s 0ms")]
    [InlineData("0day 0hour 0min 65 sec 0ms")]
    [InlineData("0day 0 hour 0 minute 65second 0millisecond")]
    [InlineData("0days  0hours 0minutes 65 seconds 0milliseconds")]
    public void
        TryParse_RollingOverSixtyFiveSecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneMinuteAndFiveSeconds(
            string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 1, 5));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("60m")]
    [InlineData("60min")]
    [InlineData("60minute")]
    [InlineData("60minutes")]
    [InlineData("60 m")]
    [InlineData("60 min")]
    [InlineData("60 minute")]
    [InlineData("60 minutes")]
    [InlineData("60m 0s")]
    [InlineData("60min 0sec")]
    [InlineData("60minute 0second")]
    [InlineData("60minutes 0seconds")]
    [InlineData("60 m 0 s")]
    [InlineData("60 min 0 sec")]
    [InlineData("60 minute 0 second")]
    [InlineData("60 minutes 0 seconds")]
    [InlineData("0h 60m 0s")]
    [InlineData("0hour 60min 0sec")]
    [InlineData("0hour 60minute 0second")]
    [InlineData("0hours 60minutes 0seconds")]
    [InlineData("0 h 60 m 0 s")]
    [InlineData("0 hour 60 min 0 sec")]
    [InlineData("0 hour 60 minute 0 second")]
    [InlineData("0 hours 60 minutes 0 seconds")]
    [InlineData("0d 0h 60m 0s")]
    [InlineData("0day 0hour 60min 0sec")]
    [InlineData("0day 0hour 60minute 0second")]
    [InlineData("0days 0hours 60minutes 0seconds")]
    [InlineData("0 d 0 h 60 m 0 s")]
    [InlineData("0 day 0 hour 60 min 0 sec")]
    [InlineData("0 day 0 hour 60 minute 0 second")]
    [InlineData("0 days 0 hours 60 minutes 0 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 60m 0 s 0ms")]
    [InlineData("0day 0hour 60min 0 sec 0ms")]
    [InlineData("0day 0 hour 60 minute 0second 0millisecond")]
    [InlineData("0days  0hours 60minutes 0 seconds 0milliseconds")]
    public void TryParse_RollingOverSixtyMinutesInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneHour(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(1, 0, 0));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("65m")]
    [InlineData("65min")]
    [InlineData("65minute")]
    [InlineData("65minutes")]
    [InlineData("65 m")]
    [InlineData("65 min")]
    [InlineData("65 minute")]
    [InlineData("65 minutes")]
    [InlineData("65m 0s")]
    [InlineData("65min 0sec")]
    [InlineData("65minute 0second")]
    [InlineData("65minutes 0seconds")]
    [InlineData("65 m 0 s")]
    [InlineData("65 min 0 sec")]
    [InlineData("65 minute 0 second")]
    [InlineData("65 minutes 0 seconds")]
    [InlineData("0h 65m 0s")]
    [InlineData("0hour 65min 0sec")]
    [InlineData("0hour 65minute 0second")]
    [InlineData("0hours 65minutes 0seconds")]
    [InlineData("0 h 65 m 0 s")]
    [InlineData("0 hour 65 min 0 sec")]
    [InlineData("0 hour 65 minute 0 second")]
    [InlineData("0 hours 65 minutes 0 seconds")]
    [InlineData("0d 0h 65m 0s")]
    [InlineData("0day 0hour 65min 0sec")]
    [InlineData("0day 0hour 65minute 0second")]
    [InlineData("0days 0hours 65minutes 0seconds")]
    [InlineData("0 d 0 h 65 m 0 s")]
    [InlineData("0 day 0 hour 65 min 0 sec")]
    [InlineData("0 day 0 hour 65 minute 0 second")]
    [InlineData("0 days 0 hours 65 minutes 0 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 65m 0 s 0ms")]
    [InlineData("0day 0hour 65min 0 sec 0ms")]
    [InlineData("0day 0 hour 65 minute 0second 0millisecond")]
    [InlineData("0days  0hours 65minutes 0 seconds 0milliseconds")]
    public void TryParse_RollingOverSixtyFiveMinutesInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneHourAndFiveMinutes(
        string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(1, 5, 0));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("24h 0m 0s")]
    [InlineData("24hour 0min 0sec")]
    [InlineData("24hour 0minute 0second")]
    [InlineData("24hours 0minutes 0seconds")]
    [InlineData("24 h 0 m 0 s")]
    [InlineData("24 hour 0 min 0 sec")]
    [InlineData("24 hour 0 minute 0 second")]
    [InlineData("24 hours 0 minutes 0 seconds")]
    [InlineData("0d 24h 0m 0s")]
    [InlineData("0day 24hour 0min 0sec")]
    [InlineData("0day 24hour 0minute 0second")]
    [InlineData("0days 24hours 0minutes 0seconds")]
    [InlineData("0 d 24 h 0 m 0 s")]
    [InlineData("0 day 24 hour 0 min 0 sec")]
    [InlineData("0 day 24 hour 0 minute 0 second")]
    [InlineData("0 days 24 hours 0 minutes 0 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 24 h 0m 0 s 0ms")]
    [InlineData("0day 24hour 0min 0 sec 0ms")]
    [InlineData("0day 24 hour 0 minute 0second 0millisecond")]
    [InlineData("0days  24hours 0minutes 0 seconds 0milliseconds")]
    public void TryParse_RollingOverTwentyFourHoursInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneDay(string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(1, 0, 0, 0));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("25h 0m 0s")]
    [InlineData("25hour 0min 0sec")]
    [InlineData("25hour 0minute 0second")]
    [InlineData("25hours 0minutes 0seconds")]
    [InlineData("25 h 0 m 0 s")]
    [InlineData("25 hour 0 min 0 sec")]
    [InlineData("25 hour 0 minute 0 second")]
    [InlineData("25 hours 0 minutes 0 seconds")]
    [InlineData("0d 25h 0m 0s")]
    [InlineData("0day 25hour 0min 0sec")]
    [InlineData("0day 25hour 0minute 0second")]
    [InlineData("0days 25hours 0minutes 0seconds")]
    [InlineData("0 d 25 h 0 m 0 s")]
    [InlineData("0 day 25 hour 0 min 0 sec")]
    [InlineData("0 day 25 hour 0 minute 0 second")]
    [InlineData("0 days 25 hours 0 minutes 0 seconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 25 h 0m 0 s 0ms")]
    [InlineData("0day 25hour 0min 0 sec 0ms")]
    [InlineData("0day 25 hour 0 minute 0second 0millisecond")]
    [InlineData("0days  25hours 0minutes 0 seconds 0milliseconds")]
    public void TryParse_RollingOverTwentyFiveHoursInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneDayAndOneHour(
        string? input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(1, 1, 0, 0));
        parsedResult.Should().BeTrue();
    }

    #endregion

    #region Value unrolling tests that result in current and next smaller unit

    [Theory]
    [InlineData("3.5s")]
    [InlineData("3.5sec")]
    [InlineData("3.5second")]
    [InlineData("3.5seconds")]
    [InlineData("3.5 s")]
    [InlineData("3.5 sec")]
    [InlineData("3.5 second")]
    [InlineData("3.5 seconds")]
    [InlineData("3.5s 0ms")]
    [InlineData("3.5sec 0ms")]
    [InlineData("3.5second 0millisecond")]
    [InlineData("3.5seconds 0milliseconds")]
    [InlineData("3.5 s 0 ms")]
    [InlineData("3.5 sec 0 ms")]
    [InlineData("3.5 second 0 millisecond")]
    [InlineData("3.5 seconds 0 milliseconds")]
    [InlineData("0m 3.5s")]
    [InlineData("0min 3.5sec")]
    [InlineData("0minute 3.5second")]
    [InlineData("0minutes 3.5seconds")]
    [InlineData("0 m 3.5 s")]
    [InlineData("0 min 3.5 sec")]
    [InlineData("0 minute 3.5 second")]
    [InlineData("0 minutes 3.5 seconds")]
    [InlineData("0m 3.5s 0ms")]
    [InlineData("0min 3.5sec 0ms")]
    [InlineData("0minute 3.5second 0millisecond")]
    [InlineData("0minutes 3.5seconds 0milliseconds")]
    [InlineData("0 m 3.5 s 0 ms")]
    [InlineData("0 min 3.5 sec 0 ms")]
    [InlineData("0 minute 3.5 second 0 millisecond")]
    [InlineData("0 minutes 3.5 seconds 0 milliseconds")]
    [InlineData("0h 0m 3.5s")]
    [InlineData("0hour 0min 3.5sec")]
    [InlineData("0hour 0minute 3.5second")]
    [InlineData("0hours 0minutes 3.5seconds")]
    [InlineData("0 h 0 m 3.5 s")]
    [InlineData("0 hour 0 min 3.5 sec")]
    [InlineData("0 hour 0 minute 3.5 second")]
    [InlineData("0 hours 0 minutes 3.5 seconds")]
    [InlineData("0h 0m 3.5s 0ms")]
    [InlineData("0hour 0min 3.5sec 0ms")]
    [InlineData("0hour 0minute 3.5second 0millisecond")]
    [InlineData("0hours 0minutes 3.5seconds 0milliseconds")]
    [InlineData("0 h 0 m 3.5 s 0 ms")]
    [InlineData("0 hour 0 min 3.5 sec 0 ms")]
    [InlineData("0 hour 0 minute 3.5 second 0 millisecond")]
    [InlineData("0 hours 0 minutes 3.5 seconds 0 milliseconds")]
    [InlineData("0d 0h 0m 3.5s")]
    [InlineData("0day 0hour 0min 3.5sec")]
    [InlineData("0day 0hour 0minute 3.5second")]
    [InlineData("0days 0hours 0minutes 3.5seconds")]
    [InlineData("0 d 0 h 0 m 3.5 s")]
    [InlineData("0 day 0 hour 0 min 3.5 sec")]
    [InlineData("0 day 0 hour 0 minute 3.5 second")]
    [InlineData("0 days 0 hours 0 minutes 3.5 seconds")]
    [InlineData("0d 0h 0m 3.5s 0ms")]
    [InlineData("0day 0hour 0min 3.5sec 0ms")]
    [InlineData("0day 0hour 0minute 3.5second 0millisecond")]
    [InlineData("0days 0hours 0minutes 3.5seconds 0milliseconds")]
    [InlineData("0 d 0 h 0 m 3.5 s 0 ms")]
    [InlineData("0 day 0 hour 0 min 3.5 sec 0 ms")]
    [InlineData("0 day 0 hour 0 minute 3.5 second 0 millisecond")]
    [InlineData("0 days 0 hours 0 minutes 3.5 seconds 0 milliseconds")]

    // Mixed w/ spaces and w/o spaces between units
    [InlineData("0d 0 h 0m 3.5 s 0ms")]
    [InlineData("0day 0hour 0min 3.5 sec 0ms")]
    [InlineData("0day 0 hour 0 minute 3.5second 0millisecond")]
    [InlineData("0days  0hours 0minutes 3.5 seconds 0milliseconds")]
    public void TryParse_UnrollFractionalValue_ReturnsTrueAndTimeSpanWithThreeSecondsAndFiveHundredMilliseconds(string input)
    {
        // Arrange
        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(new TimeSpan(0, 0, 0, 3, 500));
        parsedResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("1.25d 1.5h 1.5m 1.5s 7ms", "1.07:31:31.507")]
    [InlineData("1.25d 1.5m 7ms", "1.06:01:30.007")]
    [InlineData("1.5m 13ms", "00:01:30.013")]
    public void TryParse_UnrollFractionalValue_ReturnsTrueAndTimeSpanWithCorrectValue(string input, string result)
    {
        // Arrange
        _ = TimeSpan.TryParse(result, out var expectedResult);

        // Act
        var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

        // Assert
        parsedValue.Should().Be(expectedResult);
        parsedResult.Should().BeTrue();
    }

    #endregion
}
