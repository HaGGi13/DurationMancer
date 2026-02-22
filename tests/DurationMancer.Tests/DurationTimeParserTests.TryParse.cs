using AwesomeAssertions;
using DurationMancer.Tests.TestData;

namespace DurationMancer.Tests;

public static partial class DurationTimeParserTests
{
    public sealed class TryParse
    {
        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidZeroInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
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
        [MemberData(nameof(DurationTimeParserValidTestData.Valid3SecondsInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
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
        [MemberData(nameof(DurationTimeParserValidTestData.ValidStandardDurationFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_StandardDurationFormat_ShouldParseCorrectly(string input, int days, int hours, int minutes,
            int seconds,
            int milliseconds)
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
        [MemberData(nameof(DurationTimeParserValidTestData.ValidHumanReadableFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
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
        [MemberData(nameof(DurationTimeParserValidTestData.ValidMixedUnrollingAndRollingOverInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
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
        [MemberData(nameof(DurationTimeParserValidTestData.ValidEmptyInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_EmptyInput_ReturnsFalseAndTimeSpanZero(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(TimeSpan.Zero);
            parsedResult.Should().BeFalse();
        }

        #region Invalid input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserInvalidTestData.InvalidMixedFormatInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
        public void TryParse_MixedInputFormats_ReturnsFalseAndTimeSpanZero(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(TimeSpan.Zero);
            parsedResult.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserInvalidTestData.InvalidInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver1000MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver1001MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver60SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver65SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver60MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver65MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver24HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver25HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
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
        [MemberData(nameof(DurationTimeParserUnrollingTestData.ValidUnrolling3Dot5SecondsInputs),
            MemberType = typeof(DurationTimeParserUnrollingTestData))]
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
        [MemberData(nameof(DurationTimeParserUnrollingTestData.ValidUnrollingFractionInputs),
            MemberType = typeof(DurationTimeParserUnrollingTestData))]
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
}
