namespace MoodLibrary.Api.Exceptions
{
    public class InvalidParamException : Exception
    {
        public InvalidParamException() 
            : base("Invalid parameter.")
        {
        }

        public InvalidParamException(string message) 
            : base($"Invalid parameter: {message}")
        {
        }

        public InvalidParamException(string message, Exception innerException) 
            : base($"Invalid parameter: {message}", innerException)
        {
        }
    }
}