using System;

namespace Western.Core.Exceptions
{
    public class CantShootException : Exception
    {
        public CantShootException() : base("can not shoot anymore")
        {
        }
    }
}
