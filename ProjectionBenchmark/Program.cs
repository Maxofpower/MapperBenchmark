using BenchmarkDotNet.Running;

class Program
{
	static void Main(string[] args)
	{
		// Run the benchmark and output the results to the console
		var summary = BenchmarkRunner.Run<DTOProjectionBenchmark>();

	
	}
}