using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]  // Run one class at a time
[assembly: LevelOfParallelism(3)]  // Adjust this based on system resources
