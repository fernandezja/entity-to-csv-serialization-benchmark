using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToFixedLength.Option4
{
    public class EntityToFixedLengthOption4<T> where T : class
    {

        public const string SEPARATOR_COMMA = ",";

        private List<FieldConfig> _fieldConfigs = new List<FieldConfig>();

        private string DefaultFormatter(object value) => value?.ToString() ?? string.Empty;

        public EntityToFixedLengthOption4<T> AddField(string propertyName,
                                                      int length,
                                                      Func<object, string> formatter = null
        )
        {
            _fieldConfigs.Add(new FieldConfig
            {
                PropertyName = propertyName,
                Length = length,
                Formatter = formatter ?? DefaultFormatter
            });
            return this;
        }

        public void SerializeToFile(IEnumerable<T> entities, string filePath)
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

            foreach (var entity in entities)
            {
                Span<char> buffer = stackalloc char[_fieldConfigs.Sum(f => f.Length)];
                buffer.Fill(' ');

                int offset = 0;
                foreach (var config in _fieldConfigs)
                {
                    var propertyInfo = typeof(T).GetProperty(config.PropertyName);
                    var value = propertyInfo?.GetValue(entity);

                    var formattedValue = config.Formatter(value);
                    var valueSpan = formattedValue.AsSpan();

                    valueSpan.Slice(0, Math.Min(valueSpan.Length, config.Length))
                        .CopyTo(buffer.Slice(offset, config.Length));

                    offset += config.Length;
                }

                writer.WriteLine(buffer.ToString());
            }
        }

        // Optional header generation
        public void WriteHeader(StreamWriter writer)
        {
            Span<char> headerBuffer = stackalloc char[_fieldConfigs.Sum(f => f.Length)];
            headerBuffer.Fill(' ');

            int offset = 0;
            foreach (var config in _fieldConfigs)
            {
                var headerSpan = config.PropertyName.AsSpan();
                headerSpan.Slice(0, Math.Min(headerSpan.Length, config.Length))
                    .CopyTo(headerBuffer.Slice(offset, config.Length));
                offset += config.Length;
            }

            writer.WriteLine(headerBuffer.ToString());
        }

    }
}
