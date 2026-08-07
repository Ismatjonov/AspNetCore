namespace DI.GeneratorServices;

public class ValueStorage : IGenerator, IRead
{
    private int value;

    public int GenerateValue()
    {
        value = new Random().Next();
        return value;
    }

    public int ReadValue()
    {
        return value;
    }
}