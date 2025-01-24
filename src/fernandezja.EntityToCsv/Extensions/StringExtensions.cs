using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToCsv.Extensions
{
    public static class StringExtensions
    {
     
        private const string NEWLINE_WINDOWS = "\r\n";
        private const string NEWLINE_LINUX_UNIX = "\n";

        /// <summary>
        /// Normalizar saltos de línea (windows/linux) en test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NormalizeNewLines(this string value)
        {
            return value
                     .Replace(NEWLINE_WINDOWS, NEWLINE_LINUX_UNIX)
                     .Replace(NEWLINE_LINUX_UNIX, Environment.NewLine);
        }
    }
}
