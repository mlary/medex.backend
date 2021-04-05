namespace Medex.Data.Exception
{
    public class IncorrectAuthenticationDataException : BaseException
    {
        public IncorrectAuthenticationDataException()
        {
        }

        public IncorrectAuthenticationDataException(string message)
            : base(message)
        {
        }

        public IncorrectAuthenticationDataException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
