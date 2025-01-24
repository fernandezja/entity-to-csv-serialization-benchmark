using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fernandezja.EntityToFixedLength.Option4
{
    public class FieldConfig
    {
        public string PropertyName { get; set; }
        public int Length { get; set; }
        public Func<object, string> Formatter { get; set; }
    }
}
