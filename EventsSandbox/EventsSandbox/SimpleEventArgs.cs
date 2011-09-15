using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsSandbox
{
    public class SimpleEventArgs<T> : EventArgs
    {
        T item;
        
        /// <summary>
        /// Construct EventArgs with a value.
        /// </summary>
        /// <param name="val">The value</param>
        public SimpleEventArgs(T val)
        {
            item = val;
        }

        public T Item
        {
            get { return item; }
        }
    }
}