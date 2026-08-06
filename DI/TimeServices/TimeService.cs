namespace DI;

public class TimeService
{
    public TimeService()
    {
        Time = DateTime.Now.ToLongTimeString();
    }
    public string Time { get; }
}