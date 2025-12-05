public class Warrior : Character
{
    public Warrior() : base("Warrior", 1200, 0.4, 0.1)
    {
        _attacks.Add(new Attack("Slash", 80, 120, 0.2, 2));
        _attacks.Add(new Attack("Shield Bash", 50, 100, 0, 0, 1, 0, 1, 0.5));
        _attacks.Add(new Attack("Heavy Strike", 100, 150, 0.1, 1.5, 0, 1));
        _specialName = "Finishing Blow";
    }

    public override List<string> UseSpecialAbility(Character target)
    {
        return PerformAttack(target, new Attack(_specialName, 1, 500, 0.33, 10000, 1, 1));
    }
}

