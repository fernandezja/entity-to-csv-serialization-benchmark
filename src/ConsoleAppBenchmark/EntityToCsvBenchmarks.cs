using BenchmarkDotNet.Attributes;
using Iced.Intel;
using ServiceStack.Text;
using Starwars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBenchmark
{
    public class EntityToCsvBenchmarks
    {

        private readonly List<Jedi> _jedis;
        private readonly string[] _properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

        public EntityToCsvBenchmarks()
        {
            _jedis = Generate(1000000);

        }

        /// <summary>
        /// Generate entities jedis
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private List<Jedi> Generate(int count)
        {
            //generate count entities into list 
            var jedis = new List<Jedi>();
            for (int i = 1; i <= count; i++)
            {
                jedis.Add(new Jedi
                {
                    JediId = i,
                    Name = $"Jedi {i}",
                    LightsaberColor = $"Color {i}",
                    Power = 123.45
                });
            }
            return jedis;
        }


        [Benchmark(Baseline = true)]
        public void EntityToCsvOption1()
        {
            _ = fernandezja.EntityToCsv.EntityToCsvOption1<Jedi>.Build(_jedis, _properties);
        }


        [Benchmark]
        public void EntityToCsvOption2()
        {
            _ = fernandezja.EntityToCsv.EntityToCsvOption2<Jedi>.Build(_jedis, _properties);
        }

        [Benchmark]
        public void EntityToCsvOption3()
        {
            _ = fernandezja.EntityToCsv.EntityToCsvOption3<Jedi>.Build(_jedis, _properties);
        }

        [Benchmark]
        public void EntityToCsvOption4()
        {
            _ = fernandezja.EntityToCsv.EntityToCsvOption4<Jedi>.Build(_jedis, _properties);
        }

        [Benchmark(Description = "EntityToCsvOption5 (nuget ServiceStack.Text)")]
        public void EntityToCsvOption5()
        {
           
            _ = fernandezja.EntityToCsv.EntityToCsvOption5<Jedi>.Build(_jedis, _properties);
        }

  
        [Benchmark(Description = "EntityToCsvOption6 (nuget CsvHelper)")]
        public void EntityToCsvOption6()
        {           
            _ = fernandezja.EntityToCsv.EntityToCsvOption6<Jedi>.Build(_jedis, _properties);
        }


        [Benchmark(Description = "EntityToCsvOption7 (nuget FileHelpers)")]
        public void EntityToCsvOption7()
        {
            _ = fernandezja.EntityToCsv.EntityToCsvOption7<Jedi>.Build(_jedis, _properties);
        }
    }
}
