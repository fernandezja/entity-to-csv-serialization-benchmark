// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ConsoleAppBenchmark;

Console.WriteLine("EntityToCsv benchmarks!");

var summary = BenchmarkRunner.Run<EntityToCsvBenchmarks>();

Console.ReadKey();
