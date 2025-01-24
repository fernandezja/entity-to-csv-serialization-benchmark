using fernandezja.EntityToCsv.Extensions;
using ServiceStack.Text;
using Starwars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv.Tests
{
    public class EntityToCsvOptionsTests
    {
        [Fact]
        public void Build_Option1_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

            var result = fernandezja.EntityToCsv.EntityToCsvOption1<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }



        [Fact]
        public void Build_Option2_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

            var result = fernandezja.EntityToCsv.EntityToCsvOption2<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }

        [Fact]
        public void Build_Option3_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

            var result = fernandezja.EntityToCsv.EntityToCsvOption3<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }


        [Fact]
        public void Build_Option4_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

            var result = fernandezja.EntityToCsv.EntityToCsvOption4<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }


        [Fact]
        public void Build_Option5_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };

            CsvConfig<Jedi>.OmitHeaders = true;
            var result = fernandezja.EntityToCsv.EntityToCsvOption5<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }


        [Fact]
        public void Build_Option6_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };


            var result = fernandezja.EntityToCsv.EntityToCsvOption6<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }


        [Fact]
        public void Build_Option7_Test()
        {
            var entity = new Jedi
            {
                JediId = 1,
                Name = "Luke Skywalker",
                LightsaberColor = "Blue",
                Power = 123.45
            };

            var entities = new List<Jedi> { entity };
            var properties = new string[] { "JediId", "Name", "LightsaberColor", "Power" };


            var result = fernandezja.EntityToCsv.EntityToCsvOption7<Jedi>.Build(entities, properties);

            Assert.Equal("1,Luke Skywalker,Blue,123.45\r\n".NormalizeNewLines(), result.NormalizeNewLines());

        }

    }
}
