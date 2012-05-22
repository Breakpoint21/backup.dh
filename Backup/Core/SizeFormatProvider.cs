using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backup.Core
{
    class SizeFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return this;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return "";
        }
    }
}
