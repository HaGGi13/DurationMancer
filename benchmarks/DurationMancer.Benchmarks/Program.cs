using BenchmarkDotNet.Running;
using DurationMancer.Benchmarks;

BenchmarkRunner.Run<DurationTimeParserBenchmarks.Parse>();
BenchmarkRunner.Run<DurationTimeParserBenchmarks.TryParse>();
