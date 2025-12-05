using System;

public class Attack
{
    private string _name;
    private int _damageMin;
    private int _damageMax;
    private double _critChance;
    private double _critMultiplier;
    private double _accuracyMod;
    private double _resistanceMod;
    private int _stunDuration;
    private double _stunChance;
    private bool _onCooldown;


    public Attack(string name, int damageMin, int damageMax, double critChance, double critMultiplier, double accuracyMod = 0, double resistanceMod = 0, int stunDuration = 0, double stunChance = 1)
    {
        _name = name;
        _damageMin = damageMin;
        _damageMax = damageMax;
        _critChance = critChance;
        _critMultiplier = critMultiplier;
        _accuracyMod = accuracyMod;
        _resistanceMod = resistanceMod;
        _stunDuration = stunDuration;
        _stunChance = stunChance;
        _onCooldown = false;
    }
    public string GetName()
    {
        return _name;
    }
    public void ToggleCooldown()
    {
        _onCooldown = !_onCooldown;
    }
    public bool IsOnCooldown()
    {
        return _onCooldown;
    }
    public List<string> Execute(Character attacker, Character target)
    {
        List<string> battleUpdates = new List<string>();

        battleUpdates.Add($"{attacker.GetName()} uses {_name} on {target.GetName()}");

        if(HelperFunctions.GetRandDouble() > target.GetEvasion() - _accuracyMod)
        {
            int damage = HelperFunctions.GetRandInt(_damageMin, _damageMax);
            if(HelperFunctions.GetRandDouble() <= _critChance)
            {
                damage = (int)Math.Round(damage * _critMultiplier);

                battleUpdates.Add("Critical hit");
            }
            battleUpdates.AddRange(target.TakeDamage(damage, _resistanceMod));


            if(HelperFunctions.GetRandDouble() <= _stunChance)
            {
                target.SetStun(target.GetStun() + _stunDuration);
            }
        }
        else
        {
            battleUpdates.Add($"{attacker.GetName()}'s {_name} missed");
        }
        return battleUpdates;
        
    }
}

