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
    /// Using CsvHelper
    /// Repo https://github.com/JoshClose/CsvHelper
    /// Docs: https://joshclose.github.io/CsvHelper/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EntityToCsvOption6<T> where T : class
    {

       
        public static string Build(IEnumerable<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            var memoryStream = new MemoryStream();
            TextWriter stringWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);

            var csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = separator,
                HasHeaderRecord = false
            };

            var csvWriter =  new CsvHelper.CsvWriter(stringWriter, csvConfiguration);

            csvWriter.WriteRecords(entities);

            stringWriter.Flush();
            memoryStream.Position = 0;
            var reader = new StreamReader(memoryStream);
            return reader.ReadToEnd();

        }

    }
}
