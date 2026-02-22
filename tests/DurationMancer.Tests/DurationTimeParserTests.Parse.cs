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
        [MemberData(nameof(DurationTimeParserInvalidTestData.InvalidMixedFormatInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
        public void Parse_MixedInputFormats_ReturnsFalseAndTimeSpanZero(string input)
        {
            // Arrange
            // Act
            Action parse = () => DurationTimeParser.Parse(input);

            // Assert
            parse.Should().Throw<FormatException>();
        }

        [Theory]
        [MemberData(nameof(DurationTimeParserInvalidTestData.InvalidInputs),
            MemberType = typeof(DurationTimeParserInvalidTestData))]
        public void Parse_InvalidInput_ReturnsFalseAndTimeSpanZero(string? input)
        {
            // Arrange
            // Act
            Action parse = () => DurationTimeParser.Parse(input!);

            // Assert
            parse.Should().Throw<FormatException>();
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
    }
}
