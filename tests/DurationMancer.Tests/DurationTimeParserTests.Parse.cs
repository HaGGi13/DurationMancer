using AwesomeAssertions;
using DurationMancer.Tests.TestData;

namespace DurationMancer.Tests;

public static partial class DurationTimeParserTests
{
    public sealed class Parse
    {
        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidZeroInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_ZeroInput_ReturnsTrueAndTimeSpanZero(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(TimeSpan.Zero);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.Valid3SecondsInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_ThreeSecondsInput_ReturnsTrueAndTimeSpanWithThreeSeconds(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, 3));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidStandardDurationFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_StandardDurationFormat_ShouldParseCorrectly(string input, int days, int hours, int minutes,
            int seconds,
            int milliseconds)
        {
            // Arrange
            var expected = new TimeSpan(days, hours, minutes, seconds, milliseconds);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidHumanReadableFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_HumanReadableFormat_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Arrange
            parsedResult.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidMixedUnrollingAndRollingOverInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_MixedUnrollingAndRollingOverInput_ReturnsTrueAndTimeSpanWithCorrectValue(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        [Fact]
        public void Parse_NullInput_ReturnsFalseAndTimeSpanZero()
        {
            // Arrange
            // Act
            Action parse = () => DurationTimeParser.Parse(null!);

            // Assert
            parse.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidEmptyInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_EmptyInput_ReturnsFalseAndTimeSpanZero(string? input)
        {
            // Arrange
            // Act
            Action parse = () => DurationTimeParser.Parse(input!);

            // Assert
            parse.Should().Throw<FormatException>();
        }

        #region Invalid input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserInvalidTestData.AllInvalidInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
        public void Parse_InvalidInputs_ReturnsFalseAndTimeSpanZero(string input)
        {
            // Arrange
            // Act
            Action parse = () => DurationTimeParser.Parse(input);

            // Assert
            parse.Should().Throw<FormatException>();
        }

        #endregion

        #region Case insensitivity tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidCaseInsensitiveInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_CaseInsensitiveInput_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Whitespace-padded input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidWhitespacePaddedInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_WhitespacePaddedInput_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Standalone fractional unit tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidStandaloneFractionalUnitInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_StandaloneFractionalUnit_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Boundary value tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidBoundaryInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_BoundaryValues_ShouldParseCorrectly(string input, int days, int hours, int minutes,
            int seconds, int milliseconds)
        {
            // Arrange
            var expected = new TimeSpan(days, hours, minutes, seconds, milliseconds);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expected);
        }

        #endregion

        #region Value rolling over tests that result in next bigger unit

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver1000MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverThousandMillisecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneSecond(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, 1));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver1001MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void
            Parse_RollingOverThousandAndOneMillisecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneSecondAndOneMillisecond(
                string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, 0, 1, 1));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver60SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverSixtySecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneMinute(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 1, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver65SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void
            Parse_RollingOverSixtyFiveSecondsInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneMinuteAndFiveSeconds(
                string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 1, 5));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver60MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverSixtyMinutesInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneHour(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(1, 0, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver65MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverSixtyFiveMinutesInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneHourAndFiveMinutes(
            string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(1, 5, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver24HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverTwentyFourHoursInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneDay(string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(1, 0, 0, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOver25HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverTwentyFiveHoursInNotDurationFormat_ReturnsTrueAndTimeSpanWithOneDayAndOneHour(
            string? input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input!);

            // Assert
            parsedResult.Should().Be(new TimeSpan(1, 1, 0, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidRollingOverWithNonZeroHigherComponentInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_RollingOverWithNonZeroHigherComponents_ReturnsCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidMultiLevelCascadingRollingOverInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_MultiLevelCascadingRollingOver_ReturnsCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Negative rolling over tests

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver1000MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverThousandMilliseconds_ReturnsNegativeOneSecond(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, -1));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver60SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverSixtySeconds_ReturnsNegativeOneMinute(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, -1, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver60MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverSixtyMinutes_ReturnsNegativeOneHour(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(-1, 0, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver24HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverTwentyFourHours_ReturnsNegativeOneDay(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(-1, 0, 0, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver25HoursInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverTwentyFiveHours_ReturnsNegativeOneDayAndOneHour(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(-1, -1, 0, 0));
        }

        #endregion

        #region Valid negative input tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeStandardDurationFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_NegativeStandardDurationFormat_ShouldParseCorrectly(string input, int days, int hours,
            int minutes, int seconds, int milliseconds)
        {
            // Arrange
            var expected = new TimeSpan(days, hours, minutes, seconds, milliseconds);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeHumanReadableFormatInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_NegativeHumanReadableFormat_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Value unrolling tests that result in current and next smaller unit

        [Theory]
        [MemberData(nameof(DurationTimeParserUnrollingTestData.ValidUnrolling3Dot5SecondsInputs),
            MemberType = typeof(DurationTimeParserUnrollingTestData))]
        public void Parse_UnrollFractionalValue_ReturnsTrueAndTimeSpanWithThreeSecondsAndFiveHundredMilliseconds(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, 0, 3, 500));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserUnrollingTestData.ValidUnrollingFractionInputs),
            MemberType = typeof(DurationTimeParserUnrollingTestData))]
        public void Parse_UnrollFractionalValue_ReturnsTrueAndTimeSpanWithCorrectValue(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Negative unrolling tests

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeUnrollingInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_NegativeUnrollingInput_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserValidTestData.ValidNegativeMixedUnrollingAndRollingOverInputs),
            MemberType = typeof(DurationTimeParserValidTestData))]
        public void Parse_NegativeMixedUnrollingAndRollingOverInput_ShouldParseCorrectly(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion

        #region Negative rolling over additional tests

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver1001MillisecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverThousandAndOneMilliseconds_ReturnsNegativeOneSecondAndOneMillisecond(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, 0, 0, -1, -1));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver65SecondsInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverSixtyFiveSeconds_ReturnsNegativeOneMinuteAndFiveSeconds(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(0, -1, -5));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOver65MinutesInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverSixtyFiveMinutes_ReturnsNegativeOneHourAndFiveMinutes(string input)
        {
            // Arrange
            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(new TimeSpan(-1, -5, 0));
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeRollingOverWithNonZeroHigherComponentInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeRollingOverWithNonZeroHigherComponents_ReturnsCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserRollingOverTestData.ValidNegativeMultiLevelCascadingRollingOverInputs),
            MemberType = typeof(DurationTimeParserRollingOverTestData))]
        public void Parse_NegativeMultiLevelCascadingRollingOver_ReturnsCorrectTimeSpan(string input, string result)
        {
            // Arrange
            _ = TimeSpan.TryParse(result, out var expectedResult);

            // Act
            var parsedResult = DurationTimeParser.Parse(input);

            // Assert
            parsedResult.Should().Be(expectedResult);
        }

        #endregion
    }
}
