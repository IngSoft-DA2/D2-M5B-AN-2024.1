using System;
namespace starwars.Exceptions.BusinessLogicExceptions
{
    [Serializable]
    public class NotNull : Exception
    {
        public NotNull(string message) : base(message)
        {
        }
    }
}

