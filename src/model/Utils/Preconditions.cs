using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Utils
{
    /// <summary>
    /// Da StackOverflow
    /// </summary>
    public static class Preconditions
    {
        public static T CheckNotNull<T>(T value) where T : class 
            => value ?? throw new ArgumentNullException("value null");

        public static T CheckNotNull<T>(T value, string msg) where T : class
            => value ?? throw new ArgumentNullException(msg ?? "");
    }
}
