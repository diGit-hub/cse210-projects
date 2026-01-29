using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction() {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int num)
    {
        _top = num;
        _bottom = 1;
    }

    public Fraction(int num1, int num2)
    {
        _top = num1;
        _bottom = num2;
    }

    public void SetNumerator(int num)
    {
        _top = num;
    }

    public int GetNumerator()
    {
        return _top;
    }

    public void SetDenominator(int num)
    {
        _bottom = num;
    }

    public int GetDenominator()
    {
        return _bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}