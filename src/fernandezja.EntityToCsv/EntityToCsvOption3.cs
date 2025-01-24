using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv
{
    public static class EntityToCsvOption3<T> where T : class
    {

        public static string Build(List<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity", "Value can not be null");
            }

            var builder = new StringBuilder();
            var propertyInfos = Util.GetPropertyInfo<T>(propertyNames);

            foreach (var entity in entities) {
                builder.AppendLine(CsvDataFor(entity, propertyInfos));
            }
                

            return builder.ToString();
        }



        private static string CsvDataFor(object obj, IList<PropertyInfo> propertyInfoList)
        {
            if (obj == null)
                return string.Empty;

            var builder = new StringBuilder();

            for (var i = 0; i < propertyInfoList.Count; i++)
            {
                //builder.Append(propertyInfoList[i].GetValue(obj, index:null));
                builder.Append(Convert.ToString(propertyInfoList[i].GetValue(obj, System.Reflection.BindingFlags.GetProperty, null, null, System.Globalization.CultureInfo.InvariantCulture), System.Globalization.CultureInfo.InvariantCulture));


                if (i < propertyInfoList.Count - 1)
                    builder.Append(Util.COMMA_STRING);
            }

            return builder.ToString();
        }

    }
}
