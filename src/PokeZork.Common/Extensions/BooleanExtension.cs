using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PokeZork.Common.Extensions
{
    public static class BooleanExtension
    {
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }
        public static string ConvertToStringFlag(this bool value)
        {
            return value ? "@TRUE" : "@FALSE";
        }
    }
}
