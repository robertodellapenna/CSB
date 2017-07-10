using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CSB_Project.src.model.Utils
{
    public static class ParserUtils
    {
        public static T[] RetrieveValues<T>(XmlNode node, string fieldName, int minOccurrences = 1, int maxOccurences = 1) where T : IConvertible
        {
            XmlNodeList xnl = node.SelectNodes(fieldName);
            if (xnl.Count < minOccurrences || xnl.Count > maxOccurences )
                throw new ParsingException("Molteplicità '"+ fieldName + "' non valida. " +
                    "Doveva essere tra " + minOccurrences + " e " + maxOccurences + 
                    " invece è " + xnl.Count );
            T[] result = new T[xnl.Count];
            for (int i = 0; i < xnl.Count; i++)
            {
                try
                {
                    if (String.IsNullOrEmpty(xnl.Item(i).InnerText))
                    {
                        result[i] = default(T);
                    }
                    else
                    {
                        result[i] = (T)Convert.ChangeType(xnl.Item(i).InnerText, typeof(T));
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (InvalidCastException e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    throw new ParsingException("Impossibile convertire l'elemento");
                }
            } // Fine for
            return result;
        }
    }

    [Serializable]
    public class ParsingException : ApplicationException{
        public ParsingException(string msg) : base (msg) { }
    }
}
