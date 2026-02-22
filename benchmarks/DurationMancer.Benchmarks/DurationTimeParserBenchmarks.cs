using BenchmarkDotNet.Attributes;

namespace DurationMancer.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
[Config(typeof(Configuration))]
public class DurationTimeParserBenchmarks
{
    // --- Standard duration format inputs ---

    [Benchmark(Description = "Standard: HH:mm:ss")]
    public bool Standard_HHmmss()
        => DurationTimeParser.TryParse("12:30:45", out _);

    [Benchmark(Description = "Standard: d.HH:mm:ss.fff")]
    public bool Standard_Full()
        => DurationTimeParser.TryParse("3.08:15:30.250", out _);

    // --- Human-readable format inputs ---

    [Benchmark(Description = "Human: single unit (5m)")]
    public bool Human_SingleUnit()
        => DurationTimeParser.TryParse("5m", out _);

    [Benchmark(Description = "Human: two units (1h 30m)")]
    public bool Human_TwoUnits()
        => DurationTimeParser.TryParse("1h 30m", out _);

    [Benchmark(Description = "Human: full combo")]
    public bool Human_FullCombo()
        => DurationTimeParser.TryParse("2 days 4 hours 15 minutes 30 seconds 500 milliseconds", out _);

    [Benchmark(Description = "Human: decimals (1.5h 100ms)")]
    public bool Human_Decimals()
        => DurationTimeParser.TryParse("1.5h 100ms", out _);

    // --- Edge / failure cases ---

    [Benchmark(Description = "Invalid input", Baseline = true)]
    public bool Invalid()
        => DurationTimeParser.TryParse("not a duration", out _);

    [Benchmark(Description = "Null input")]
    public bool Null()
        => DurationTimeParser.TryParse(null, out _);
}
