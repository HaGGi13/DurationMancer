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
        [MemberData(nameof(DurationTimeParserInvalidTestData.AllInvalidInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
        public void TryParse_InvalidInputs_ReturnsFalseAndTimeSpanZero(string input)
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

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOverWithNonZeroHigherComponentInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_RollingOverWithNonZeroHigherComponents_ReturnsTrueAndCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(expectedResult);
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidMultiLevelCascadingRollingOverInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_MultiLevelCascadingRollingOver_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Negative rolling over tests

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver1000MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverThousandMilliseconds_ReturnsTrueAndNegativeOneSecond(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(0, 0, -1));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver60SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverSixtySeconds_ReturnsTrueAndNegativeOneMinute(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(0, -1, 0));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver60MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverSixtyMinutes_ReturnsTrueAndNegativeOneHour(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(-1, 0, 0));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver24HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverTwentyFourHours_ReturnsTrueAndNegativeOneDay(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(-1, 0, 0, 0));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver25HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverTwentyFiveHours_ReturnsTrueAndNegativeOneDayAndOneHour(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(-1, -1, 0, 0));
            parsedResult.Should().BeTrue();
        }

        #endregion

        #region Valid negative input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeStandardDurationFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_NegativeStandardDurationFormat_ShouldParseCorrectly(string input, int days, int hours,
            int minutes, int seconds, int milliseconds)
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
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeHumanReadableFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_NegativeHumanReadableFormat_ShouldParseCorrectly(string input, string result)
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


        #region Case insensitivity tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidCaseInsensitiveInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_CaseInsensitiveInput_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Whitespace-padded input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidWhitespacePaddedInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_WhitespacePaddedInput_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Standalone fractional unit tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidStandaloneFractionalUnitInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_StandaloneFractionalUnit_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Negative unrolling tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeUnrollingInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_NegativeUnrollingInput_ReturnsTrueAndCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(expectedResult);
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeMixedUnrollingAndRollingOverInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_NegativeMixedUnrollingAndRollingOverInput_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Negative rolling over additional tests

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver1001MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverThousandAndOneMilliseconds_ReturnsTrueAndNegativeOneSecondAndOneMillisecond(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(0, 0, 0, -1, -1));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver65SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverSixtyFiveSeconds_ReturnsTrueAndNegativeOneMinuteAndFiveSeconds(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(0, -1, -5));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver65MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverSixtyFiveMinutes_ReturnsTrueAndNegativeOneHourAndFiveMinutes(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(new TimeSpan(-1, -5, 0));
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOverWithNonZeroHigherComponentInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeRollingOverWithNonZeroHigherComponents_ReturnsTrueAndCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(expectedResult);
            parsedResult.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeMultiLevelCascadingRollingOverInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void TryParse_NegativeMultiLevelCascadingRollingOver_ReturnsTrueAndCorrectTimeSpan(string input, string result)
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

        #region Boundary value tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidBoundaryInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void TryParse_BoundaryValues_ReturnsTrueAndCorrectTimeSpan(string input, int days, int hours, int minutes,
            int seconds, int milliseconds)
        {
            // Arrange
            var expected = new TimeSpan(days, hours, minutes, seconds, milliseconds);

            // Act
            var parsedResult = DurationTimeParser.TryParse(input, out var parsedValue);

            // Assert
            parsedValue.Should().Be(expected);
            parsedResult.Should().BeTrue();
        }

        #endregion
    }
}
