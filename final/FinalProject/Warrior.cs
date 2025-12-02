public class Warrior : Character
{
    public Warrior() : base("Warrior", 120, 15, 0.05)
    {
        _attacks.Add(new Attack("Slash", 20, 20, 0.1, 2.0, null));
        _attacks.Add(new Attack("Shield Bash", 15, 15, 0.2, 1.5, "Stun"));
        _attacks.Add(new Attack("Heavy Strike", 30, 30, 0.05, 2.5, null));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} uses Berserk!");
    }
}

