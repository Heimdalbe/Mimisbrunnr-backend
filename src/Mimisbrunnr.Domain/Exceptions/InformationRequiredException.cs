using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimisbrunnr.Domain.Exceptions
{
    internal class InformationRequiredException<T> : Exception
    {
        private HashSet<T> _exceptions = new HashSet<T>();

        public InformationRequiredException(string message, HashSet<T> exceptions) : base(message)
        {
            _exceptions = exceptions;
        }

        public InformationRequiredException(HashSet<T> exceptions) : this("Cannot create because further information is required", exceptions)
        {
        }

        public HashSet<T> Exceptions => _exceptions;
    }
}
