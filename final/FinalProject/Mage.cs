public class Mage : Character
{
    public Mage() : base("Mage", 80, 5, 0.10)
    {
        _attacks.Add(new Attack("Fireball", 25, 25, 0.15, 1.8, null));
        _attacks.Add(new Attack("Ice Spike", 20, 20, 0.2, 1.5, "Slow"));
        _attacks.Add(new Attack("Lightning Bolt", 30, 30, 0.1, 2.0, null, true));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} uses Mana Surge!");
    }
}
