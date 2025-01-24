using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv
{
    public static class EntityToCsvOption2<T> where T : class
    {


        public static string Build(IEnumerable<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            if (entities == null || !entities.Any())
                return string.Empty;


            var sb = new StringBuilder();
            
            var properties = Util.GetPropertyInfo<T>(propertyNames);

            foreach (T entity in entities)
            {
                string line = string.Join(Util.COMMA_STRING, 
                                            properties.Select(p => ToCsvValue(p.GetValue(entity, null))).ToArray());
                sb.AppendLine(line);
            }
            return sb.ToString();
        }

        private static string ToCsvValue<T>(T item)
        {
            if (item == null) 
                return Util.DOUBLE_QUOTES_OPEN_CLOSE;

            if (item is string)
            {
                return string.Format("{0}", Convert.ToString(item, provider: CultureInfo.InvariantCulture).Replace(Util.DOUBLE_QUOTES, "\\\""));
            }

            double dummy;
            if (double.TryParse(Convert.ToString(item, provider: CultureInfo.InvariantCulture), out dummy))
            {
                return string.Format("{0}", Convert.ToString(item, provider: CultureInfo.InvariantCulture));
            }

            return string.Format("\"{0}\"", item);
        }


    }
}
