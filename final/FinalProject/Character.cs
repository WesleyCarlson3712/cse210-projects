using System;
public abstract class Character
{
    protected string _name;
    protected int _hp;
    protected int _maxHp;
    protected double _resistance;
    protected double _evasion;
    protected List<Attack> _attacks;
    protected int _stunned;
    protected bool _specialAvailable;
    protected string _specialName;

    protected Character(string name, int hp, double resistance, double evasion)
    {
        _name = name;
        _hp = hp;
        _maxHp = hp;
        _resistance = resistance;
        _evasion = evasion;
        _attacks = new List<Attack>();
        _stunned = 0;
        _specialAvailable = false;
        _specialName = "Special Ability";

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
    public void SetStun(int duration)
    {
        _stunned = duration;
    }
    public int GetStun()
    {
        return _stunned;
    }
    public void SetSpecialAvailable(bool available)
    {
        _specialAvailable = available;
    }
    public bool IsSpecialAvailable()
    {
        return _specialAvailable;
    }
    public string GetSpecialName()
    {
        return _specialName;
    }
    public List<string> PerformAttack(Character target, Attack attack)
    {
        return attack.Execute(this, target);
    }
    public List<string> TakeDamage(int damage, double resistanceMod)
    {
        List<string> battleUpdates = new List<string>();
        int startHp = _hp;
        damage = (int)(damage * (1 - (Math.Max(0, _resistance - resistanceMod))));
        _hp = Math.Max(0, _hp - damage);

        if(startHp > _maxHp / 2 && _hp <= _maxHp / 2)
        {
            _specialAvailable = true;
        }

        battleUpdates.Add($"{_name} takes {damage} damage");
        return battleUpdates;
    }

    public abstract List<string> UseSpecialAbility(Character target);
}