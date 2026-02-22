using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;

namespace DurationMancer.Benchmarks;

public class Configuration : ManualConfig
{
    public Configuration()
    {
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core80).WithId(".NET 8"));
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core90).WithId(".NET 9"));
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core10_0).WithId(".NET 10"));

        AddColumn(StatisticColumn.P95);

        HideColumns("Job", "Alloc Ratio");
    }
}
