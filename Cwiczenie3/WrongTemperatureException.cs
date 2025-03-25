namespace Cwiczenie3;

public class WrongTemperatureException : Exception
{
    public WrongTemperatureException(string message) : base(message) { }
}