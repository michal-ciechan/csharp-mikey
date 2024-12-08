namespace InterfacesEverywhere.Services;

public class Calculator : ICalculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
}