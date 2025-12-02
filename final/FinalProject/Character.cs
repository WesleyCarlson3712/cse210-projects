using System;
public abstract class Character
{
    protected string _name;
    protected int _hp;
    protected double _resistance;
    protected double _evasion;
    protected List<Attack> _attacks;

    protected Character(string name, int hp, double resistance, double evasion)
    {
        _name = name;
        _hp = hp;
        _resistance = resistance;
        _evasion = evasion;
        _attacks = new List<Attack>();
    }

    public string GetName()
    {
        return _name;
    }
    public int GetHP()
    {
        return _hp;
    }
    public double GetResistance()
    {
        return _resistance;
    }
    public double GetEvasion()
    {
        return _evasion;
    }
    public List<Attack> GetAttacks()
    {
        return _attacks;
    }

    public void PerformAttack(Character target, Attack attack)
    {
        attack.Execute(this, target);
    }
    public void TakeDamage(int damage)
    {
        damage -= (int)Math.Round(damage * _resistance);
        _hp = Math.Max(0, _hp - damage);
        Console.WriteLine($"damage in takedamage is {damage}");
    }

    public abstract void UseSpecialAbility(Character target);
}