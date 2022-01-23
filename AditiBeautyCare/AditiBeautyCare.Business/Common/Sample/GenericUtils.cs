using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AditiBeautyCare.Business.Common.Sample
{
     public static class GenericUtils
    {
        public static List<T> ToNonNullList<T>(this IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }
    }

}
