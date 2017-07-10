using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CSB_Project.src.model.Utils
{
    public static class HashUtils
    {
        /// <summary>
        /// Da stackOverflow
        /// Restituisce l'hash della stringa in ingresso
        /// </summary>
        /// <param name="value">valore con la quale calcolare l'hash</param>
        /// <returns>hash di value</returns>
        public static string ToSHA512(this string value)
        {
            string hash = "";
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(value));
            hash = Encoding.UTF8.GetString(result);
            return hash;
        }
    }
}
