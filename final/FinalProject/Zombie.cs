public class Zombie : Character
{
    public Zombie() : base("Zombie", 100, 10, 0.02)
    {
        _attacks.Add(new Attack("Bite", 15, 15, 0.05, 1.5, "Infect"));
        _attacks.Add(new Attack("Claw", 12, 12, 0.1, 1.3, null));
        _attacks.Add(new Attack("Lunge", 18, 18, 0.05, 1.4, null));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} regenerates health!");
    }
}

