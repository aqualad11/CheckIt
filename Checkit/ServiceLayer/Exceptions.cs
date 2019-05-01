using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.ServiceLayer
{
    public class UserExistsException : Exception
    {
        public UserExistsException() { }

        public UserExistsException(string message) : base(message) { }
    }

    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() { }

        public UserDoesNotExistException(string message) : base(message) { }
    }

    public class TooYoungException : Exception
    {
        public TooYoungException() { }

        public TooYoungException(string message) : base(message) { }
    }

    public class PasswordHackedException : Exception
    {
        public PasswordHackedException() { }

        public PasswordHackedException(string message) : base(message) { }
    }

    public class ClientDoesNotExistException : Exception
    {
        public ClientDoesNotExistException() { }

        public ClientDoesNotExistException(string message) : base(message) { }
    }

    public class InvalidRequestSignature : Exception
    {
        public InvalidRequestSignature() { }

        public InvalidRequestSignature(string message) : base(message) { }
    }
}
