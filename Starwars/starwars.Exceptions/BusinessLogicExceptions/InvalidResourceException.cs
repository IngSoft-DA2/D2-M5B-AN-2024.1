using System;

namespace starwars.Exceptions.BusinessLogicExceptions
{
    [Serializable]
    public class InvalidResourceException : Exception
    {
        public InvalidResourceException(string message) : base(message)
        {
        }
    }
}

