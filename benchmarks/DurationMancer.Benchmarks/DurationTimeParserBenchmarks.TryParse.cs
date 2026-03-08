using BenchmarkDotNet.Attributes;

namespace DurationMancer.Benchmarks;

public static partial class DurationTimeParserBenchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    [Config(typeof(Configuration))]
    public class TryParse
    {
        // --- Standard duration format inputs ---

        [Benchmark(Description = "Standard: HH:mm:ss")]
        public bool Standard_HHmmss()
        {
            return DurationTimeParser.TryParse("12:30:45", out _);
        }

        [Benchmark(Description = "Standard negative: -HH:mm:ss")]
        public bool Standard_NegativeHHmmss()
        {
            return DurationTimeParser.TryParse("-12:30:45", out _);
        }

        [Benchmark(Description = "Standard: d.HH:mm:ss.fff")]
        public bool Standard_Full()
        {
            return DurationTimeParser.TryParse("3.08:15:30.250", out _);
        }

        [Benchmark(Description = "Standard negative: -d.HH:mm:ss.fff")]
        public bool Standard_NegativeFull()
        {
            return DurationTimeParser.TryParse("-3.08:15:30.250", out _);
        }

        // --- Human-readable format inputs ---

        [Benchmark(Description = "Human: single unit (5m)")]
        public bool Human_SingleUnit()
        {
            return DurationTimeParser.TryParse("5m", out _);
        }

        [Benchmark(Description = "Human: single unit negative (-5m)")]
        public bool Human_NegativeSingleUnit()
        {
            return DurationTimeParser.TryParse("-5m", out _);
        }

        [Benchmark(Description = "Human: two units (1h 30m)")]
        public bool Human_TwoUnits()
        {
            return DurationTimeParser.TryParse("1h 30m", out _);
        }

        [Benchmark(Description = "Human: full combo")]
        public bool Human_FullCombo()
        {
            return DurationTimeParser.TryParse("2 days 4 hours 15 minutes 30 seconds 500 milliseconds", out _);
        }

        [Benchmark(Description = "Human: full combo negative")]
        public bool Human_NegativeFullCombo()
        {
            return DurationTimeParser.TryParse("-2 days 4 hours 15 minutes 30 seconds 500 milliseconds", out _);
        }

        [Benchmark(Description = "Human: decimals (1.5h 100ms)")]
        public bool Human_Decimals()
        {
            return DurationTimeParser.TryParse("1.5h 100ms", out _);
        }

        // --- Edge / failure cases ---

        [Benchmark(Description = "Invalid input", Baseline = true)]
        public bool Invalid()
        {
            return DurationTimeParser.TryParse("not a duration", out _);
        }

        [Benchmark(Description = "Null input")]
        public bool Null()
        {
            return DurationTimeParser.TryParse(null, out _);
        }
    }
}
