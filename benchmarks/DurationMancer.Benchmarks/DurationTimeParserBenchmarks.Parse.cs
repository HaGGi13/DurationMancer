using BenchmarkDotNet.Attributes;

namespace DurationMancer.Benchmarks;

public static partial class DurationTimeParserBenchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    [Config(typeof(Configuration))]
    public class Parse
    {
        // --- Standard duration format inputs ---

        [Benchmark(Description = "Standard: HH:mm:ss")]
        public TimeSpan Standard_HHmmss()
            => DurationTimeParser.Parse("12:30:45");

        [Benchmark(Description = "Standard negative: -HH:mm:ss")]
        public TimeSpan Standard_NegativeHHmmss()
            => DurationTimeParser.Parse("-12:30:45");

        [Benchmark(Description = "Standard: d.HH:mm:ss.fff")]
        public TimeSpan Standard_Full()
            => DurationTimeParser.Parse("3.08:15:30.250");

        [Benchmark(Description = "Standard negative: -d.HH:mm:ss.fff")]
        public TimeSpan Standard_NegativeFull()
            => DurationTimeParser.Parse("-3.08:15:30.250");

        // --- Human-readable format inputs ---

        [Benchmark(Description = "Human: single unit (5m)")]
        public TimeSpan Human_SingleUnit()
            => DurationTimeParser.Parse("5m");

        [Benchmark(Description = "Human: single unit negative (-5m)")]
        public TimeSpan Human_NegativeSingleUnit()
            => DurationTimeParser.Parse("-5m");

        [Benchmark(Description = "Human: two units (1h 30m)")]
        public TimeSpan Human_TwoUnits()
            => DurationTimeParser.Parse("1h 30m");

        [Benchmark(Description = "Human: full combo")]
        public TimeSpan Human_FullCombo()
            => DurationTimeParser.Parse("2 days 4 hours 15 minutes 30 seconds 500 milliseconds");

        [Benchmark(Description = "Human: full combo negative")]
        public TimeSpan Human_NegativeFullCombo()
            => DurationTimeParser.Parse("-2 days 4 hours 15 minutes 30 seconds 500 milliseconds");

        [Benchmark(Description = "Human: decimals (1.5h 100ms)")]
        public TimeSpan Human_Decimals()
            => DurationTimeParser.Parse("1.5h 100ms");

        // --- Edge / failure cases ---

        [Benchmark(Description = "Invalid input", Baseline = true)]
        public TimeSpan Invalid()
        {
            try
            {
                // This will throw a FormatException
                return DurationTimeParser.Parse("not a duration");
            }
            catch
            {
                return TimeSpan.Zero;
            }
        }

        [Benchmark(Description = "Null input")]
        public TimeSpan Null()
        {
            try
            {
                // This will throw an ArgumentNullException
                return DurationTimeParser.Parse(null);
            }
            catch
            {
                return TimeSpan.Zero;
            }
        }
    }
}
