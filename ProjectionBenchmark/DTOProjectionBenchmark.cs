using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using AutoMapper;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using Nelibur.ObjectMapper;
using BenchmarkDotNet.Configs;

[MemoryDiagnoser]  // Adds memory diagnostics to the benchmark
[RankColumn]       // Adds ranking to the benchmark results
public class DTOProjectionBenchmark
{
	private static IMapper _autoMapper;
	private static TypeAdapterConfig _mapsterConfig;

	private List<SourceClass> _sourceList;

	public DTOProjectionBenchmark()
	{
		// Generate a large list of SourceClass objects for testing
		_sourceList = Enumerable.Range(1, 100_000).Select(i => new SourceClass
		{
			Id = i,
			Name = $"Name {i}",
			Description = $"Description for item {i}"
		}).ToList();

		// AutoMapper Configuration
		var config = new MapperConfiguration(cfg => cfg.CreateMap<SourceClass, DestinationClass>());
		_autoMapper = config.CreateMapper();

		// Mapster Configuration
		_mapsterConfig = new TypeAdapterConfig();
		_mapsterConfig.NewConfig<SourceClass, DestinationClass>();

		// TinyMapper Configuration
		TinyMapper.Bind<SourceClass, DestinationClass>();
	}
	// Basic LINQ Projection (without any external packages)
	[Benchmark]
	public List<DestinationClass> LinqProjection()
	{
		return (from source in _sourceList
				select new DestinationClass
				{
					Id = source.Id,
					Name = source.Name
				}).ToList();
	}
	// AutoMapper ProjectTo (queryable)
	[Benchmark]
	public List<DestinationClass> AutoMapperProjection()
	{
		return _autoMapper.ProjectTo<DestinationClass>(_sourceList.AsQueryable()).ToList();
	}

	

	[Benchmark]
	public List<DestinationClass> MapsterProjection()
	{
		return _sourceList.Adapt<List<DestinationClass>>(_mapsterConfig);
	}

	[Benchmark]
	public List<DestinationClass> TinyMapperProjection()
	{
		// Map each item individually using TinyMapper
		return _sourceList.Select(source => TinyMapper.Map<DestinationClass>(source)).ToList();
	}
}

public class SourceClass
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}

public class DestinationClass
{
	public int Id { get; set; }
	public string Name { get; set; }
}
