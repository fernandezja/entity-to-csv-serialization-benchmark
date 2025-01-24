using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv
{
    public static class EntityToCsvOption1<T> where T : class
    {

       
        public static string Build(IEnumerable<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            if (entities == null || !entities.Any())
                return string.Empty;

            

            var sb = new StringBuilder();

            //Header
            //sb.AppendLine(string.Join(Util.COMMA_STRING, properties.Select(p => p.Name)));

            var properties = Util.GetPropertyInfo<T>(propertyNames);

            foreach (var entity in entities)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(entity, null);
                    return value != null ? Convert.ToString(value, provider: CultureInfo.InvariantCulture) : string.Empty;
                });

                sb.AppendLine(string.Join(Util.COMMA_STRING, values));
            }

            return sb.ToString();
        }

    }
}
