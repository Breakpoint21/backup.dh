using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backup.Core
{
    class Container
    {
        byte[] header;
        byte[] manifest;
        byte[] manifestElement; //20 Byte | 16Byte GUID 4 Byte Offset
    }
}
