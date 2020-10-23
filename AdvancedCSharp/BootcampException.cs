using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp {
    class BootcampException : Exception {       //Always inherit base class Exception when making exceptions

        public BootcampException() : base() { }     //Create base constructor   --All 3 are needed to fit the exception format
        public BootcampException(string message) : base(message) { }
        public BootcampException(string message, Exception innerException) : base(message, innerException) { }

    }
}
