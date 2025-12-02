public class Ghoul : Character
{
    public Ghoul() : base("Ghoul", 95, 7, 0.15)
    {
        _attacks.Add(new Attack("Rend", 22, 22, 0.1, 1.8, null));
        _attacks.Add(new Attack("Howl", 10, 10, 0.2, 1.2, "Fear"));
        _attacks.Add(new Attack("Pounce", 20, 20, 0.15, 1.6, null));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} unleashes a terrifying shriek!");
    }
}

