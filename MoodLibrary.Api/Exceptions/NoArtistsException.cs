namespace MoodLibrary.Api.Exceptions
{
    
public class NoArtistsException : Exception
{
    // Parameterless constructor
    public NoArtistsException() 
        : base("No artists were found.")
    {
    }

    // Constructor that accepts a custom message
    public NoArtistsException(string message) 
        : base(message)
    {
    }

    // Constructor that accepts a custom message and an inner exception
    public NoArtistsException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}
}