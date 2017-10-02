using System;
using System.Diagnostics;

namespace Algorithms.Common.PerformanceAnalyzer
{
    public static class PerformanceAnalyzer
    {
        public static TimeSpan GetExecutionTime(Action action) {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            action();

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
