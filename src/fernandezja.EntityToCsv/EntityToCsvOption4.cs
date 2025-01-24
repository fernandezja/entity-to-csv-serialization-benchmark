using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv
{
    public class EntityToCsvOption4<T> where T : class
    {

        public static string Build(IEnumerable<T> entities, string[] propertyNames,
                                    string separator = Util.COMMA_STRING, 
                                    bool includeHeader = false)
        {

            //var properties = typeof(T).GetProperties(
            //    BindingFlags.Public | BindingFlags.Instance);
            var properties = Util.GetPropertyInfo<T>(propertyNames);

            var sb = new StringBuilder();

            //if (includeHeader)
            //{
            //    WriteHeader(sb, properties);
            //}

            WriteEntities(sb, entities, properties);

            return sb.ToString();

        }

        private static  void WriteHeader(StringBuilder builder, PropertyInfo[] properties)
        {
            Span<char> headerBuffer = stackalloc char[1024];
            int charsWritten = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                var propertyName = properties[i].Name.AsSpan();
                propertyName.CopyTo(headerBuffer.Slice(charsWritten));
                charsWritten += propertyName.Length;

                if (i < properties.Length - 1)
                {
                    headerBuffer[charsWritten++] = ',';
                }
            }

            builder.AppendLine(headerBuffer.Slice(0, charsWritten).ToString());
        }

        private static  void WriteEntities(
            StringBuilder builder,
            IEnumerable<T> entities,
            PropertyInfo[] properties)
        {
            Span<char> buffer = stackalloc char[1024];

            foreach (var entity in entities)
            {
                int charsWritten = 0;

                for (int i = 0; i < properties.Length; i++)
                {
                    var value = properties[i].GetValue(entity);
                    
                    //var valueSpan = (value?.ToString() ?? string.Empty).AsSpan();

                    var valueSpan = (Convert.ToString(value, provider: CultureInfo.InvariantCulture)).AsSpan();
                    /*
                    // Handle CSV escaping
                    bool needsQuoting = valueSpan.Contains(',') ||
                                        valueSpan.Contains('"') ||
                                        valueSpan.Contains('\n');

                    if (needsQuoting)
                    {
                        buffer[charsWritten++] = '"';
                        valueSpan.CopyTo(buffer.Slice(charsWritten));
                        charsWritten += valueSpan.Length;
                        buffer[charsWritten++] = '"';
                    }
                    else
                    {
                        valueSpan.CopyTo(buffer.Slice(charsWritten));
                        charsWritten += valueSpan.Length;
                    }
                    */

                    valueSpan.CopyTo(buffer.Slice(charsWritten));
                    charsWritten += valueSpan.Length;

                    if (i < properties.Length - 1)
                    {
                        buffer[charsWritten++] = Util.COMMA_CHAR;
                    }
                }

                builder.AppendLine(buffer.Slice(0, charsWritten).ToString());
            }
        }
    }
}
