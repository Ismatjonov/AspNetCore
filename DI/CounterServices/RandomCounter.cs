namespace DI.CounterServices;

public class RandomCounter : ICounter
{
    Random rnd = new ();
    private int value;
    public RandomCounter()
    {
        value = rnd.Next(0, 1000000);
    }

    public int Value
    {
        get => value;
    }
}