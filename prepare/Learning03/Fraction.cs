public class Fraction
{
    private int _neumerator;
    private int _denominator;


    public Fraction()
    {
        _neumerator = 1;
        _denominator = 1;
    }
    public Fraction(int top)
    {
        _neumerator = top;
        _denominator = 1;
    }
    public Fraction(int top, int bottom)
    {
        _neumerator = top;
        _denominator = bottom;
    }

    public int GetNumerator()
    {
        return _neumerator;
    }
    public int GetDenominator()
    {
        return _denominator;
    }
    public void SetNumerator(int top)
    {
        _neumerator = top;
    }
    public void SetDenominator(int bottom)
    {
        _denominator = bottom;
    }
    public string GetFractionString()
    {
        return $"{_neumerator}/{_denominator}";
    }
    public double GetDecimalValue()
    {
        return (double)_neumerator / _denominator;
    }
}