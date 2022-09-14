using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    class FileContentEmptyException : Exception
    {
        public FileContentEmptyException() { }

        public FileContentEmptyException(string message) : base(message) { }

        public FileContentEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
