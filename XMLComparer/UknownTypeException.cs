using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    class UnknownTypeException : Exception
    {
        public UnknownTypeException() { }

        public UnknownTypeException(string message) : base(message)
        {

        }

        public UnknownTypeException(string message, Exception inner) : base(message, inner) { }


    }
}
