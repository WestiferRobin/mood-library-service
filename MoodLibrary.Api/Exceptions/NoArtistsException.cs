namespace MoodLibrary.Api.Exceptions
{
    public class NoArtistsException : Exception
    {
        public NoArtistsException() 
            : base("No artists were found.")
        {
        }

        public NoArtistsException(string message) 
            : base(message)
        {
        }
        
        public NoArtistsException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}