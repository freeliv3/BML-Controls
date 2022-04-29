using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BML_Controls_Backend.API.Extensions
{
    public static class StringExtentions
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select
                    ( (x, i) => 
                        i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()
                    )
                ).ToLower();
        }
    }
}
