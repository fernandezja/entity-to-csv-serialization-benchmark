using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv
{
    public static class Util
    {

        public const string COMMA_STRING = ",";
        public const char COMMA_CHAR = ',';
        public const string DOUBLE_QUOTES = "\""; 
        public const string DOUBLE_QUOTES_OPEN_CLOSE = "\"\"";


        /// <summary>
        /// Obtener PropertyInfo de una lista de nombres de propiedades
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfo<T>(IEnumerable<string> propertyNames)
        {
            var propertyInfos = typeof(T).GetProperties()
                                         .Where(p => propertyNames.Contains(p.Name))
                                         .ToDictionary(p => p.Name, p => p);

            return (from propertyName in propertyNames
                    where propertyInfos.ContainsKey(propertyName)
                    select propertyInfos[propertyName]).ToArray();
        }

        /// <summary>
        /// Escapar valores para ser escritos en un archivo CSV
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EscapeCsvValue(string value)
        {
            // Escapar comillas y valores que contienen comas
            if (value.Contains(COMMA_STRING) || value.Contains(DOUBLE_QUOTES))
            {
                value = value.Replace(DOUBLE_QUOTES, DOUBLE_QUOTES_OPEN_CLOSE);
                return $"\"{value}\"";
            }
            return value;
        }
    }
}
