namespace DI;

public class TimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}