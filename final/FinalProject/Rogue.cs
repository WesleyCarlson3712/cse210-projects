public class Rogue : Character
{
    public Rogue() : base("Rogue", 90, 8, 0.20)
    {
        _attacks.Add(new Attack("Backstab", 25, 25, 0.25, 2.5, null));
        _attacks.Add(new Attack("Poison Dart", 15, 15, 0.15, 1.2, "Poison"));
        _attacks.Add(new Attack("Quick Slash", 18, 18, 0.3, 1.8, null));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} uses Shadowstep!");
    }
}

