using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Normalizar saltos de línea
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NormalizeNewLines(this string value)
        {
            return value
                .Replace("\r\n", "\n")
                .Replace("\n", Environment.NewLine);
        }
    }
}
