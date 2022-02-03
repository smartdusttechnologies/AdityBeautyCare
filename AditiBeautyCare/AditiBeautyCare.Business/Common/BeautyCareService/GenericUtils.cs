﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AditiBeautyCare.Business.Common.BeautyCareService
{
    public static class GenericUtils
    {

        #region Public Methods
        /// <summary>
        /// List is always instantiated even when it is passed as null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> ToNonNullList<T>(this IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }
        #endregion

    }


}
