using ServiceStack.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fernandezja.EntityToCsv
{
    /// <summary>
    /// Use ServiceStack.Text to serialize entities to CSV
    /// Repo: https://github.com/ServiceStack/ServiceStack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EntityToCsvOption5<T> where T : class
    {

       
        public static string Build(IEnumerable<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            CsvConfig<T>.OmitHeaders = true;
            return CsvSerializer.SerializeToCsv(entities);
        }

    }
}
