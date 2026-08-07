namespace DI;

public class Timer : ITimer
{
    public Timer()
    {
        Time = DateTime.Now.ToString("HH:mm:ss");
    }
    public string Time { get; }
}