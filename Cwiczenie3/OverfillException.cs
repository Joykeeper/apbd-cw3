namespace Cwiczenie3;

// Custom Exception for Overfilling Containers
public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}
