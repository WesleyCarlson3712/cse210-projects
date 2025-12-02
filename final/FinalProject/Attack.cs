using System;

public class Attack
{
    private string _name;
    private int _damageMin;
    private int _damageMax;
    private double _critChance;
    private double _critMultiplier;
    private string _specialEffect;
    private bool _alwaysHits;


    public Attack(string name, int damageMin, int damageMax, double critChance, double critMultiplier, string specialEffect, bool alwaysHits = false)
    {
        _name = name;
        _damageMin = damageMin;
        _damageMax = damageMax;
        _critChance = critChance;
        _critMultiplier = critMultiplier;
        _specialEffect = specialEffect;
        _alwaysHits = alwaysHits;
    }
    public string GetName()
    {
        return _name;
    }
    public void Execute(Character attacker, Character target)
    {
        if(_alwaysHits || HelperFunctions.GetRandDouble() > target.GetEvasion())
        {
            int damage = HelperFunctions.GetRandInt(_damageMin, _damageMax);
            if(HelperFunctions.GetRandDouble() <= _critChance)
            {
                damage += (int)Math.Round(damage * _critMultiplier);
                Console.WriteLine($"damage in attack is {damage}");
            }
            target.TakeDamage(damage);
        }
    }
}

