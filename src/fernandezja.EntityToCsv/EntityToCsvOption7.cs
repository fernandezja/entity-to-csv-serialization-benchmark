using FileHelpers;
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
    /// Using FileHelpers 
    /// Repo https://github.com/MarcosMeli/FileHelpers
    /// Docs: https://www.filehelpers.net/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EntityToCsvOption7<T> where T : class
    {
       
        public static string Build(IEnumerable<T> entities, string[] propertyNames, string separator = Util.COMMA_STRING)
        {
            var engine = new FileHelperEngine<T>();

            return engine.WriteString(entities);
        }

    }
}
