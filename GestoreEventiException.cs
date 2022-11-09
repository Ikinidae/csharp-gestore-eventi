//creare classe eccezioni per il programma
public class GestoreEventiException : Exception
{
    public GestoreEventiException()
    {
    }

    public GestoreEventiException(string message) : base(message)
    {
    }
}