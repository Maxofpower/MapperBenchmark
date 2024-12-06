# DTO Projection Benchmark

## Overview

This project contains benchmarks comparing different techniques for projecting data to Data Transfer Objects (DTOs) in C#. The goal is to evaluate the performance, memory usage, and overhead of different libraries and methods for data projection.

### Projection Techniques Tested
- **LinqProjection**: Using LINQ to project data into DTOs.
- **AutoMapperProjection**: Using AutoMapper for DTO mapping.
- **MapsterProjection**: Using Mapster for DTO mapping.
- **TinyMapperProjection**: Using TinyMapper for DTO mapping.

### Benchmark Objective
The objective of this benchmark is to compare the performance (execution time) and memory usage of different DTO projection methods in a real-world scenario.



## Tools and Libraries Used

- **BenchmarkDotNet**: The benchmarking framework used to measure the performance.
- **AutoMapper**: A popular library for object-object mapping in .NET.
- **Mapster**: A flexible and high-performance mapping library.
- **TinyMapper**: A fast and lightweight mapping library for .NET.
- **LINQ**: Language Integrated Query, used to perform data transformation.

## Setup and Running the Benchmark

To run the benchmark locally:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repository-url.git
   cd your-repository-folder
