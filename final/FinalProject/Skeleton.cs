public class Skeleton : Character
{
    public Skeleton() : base("Skeleton", 85, 12, 0.05)
    {
        _attacks.Add(new Attack("Bone Smash", 20, 20, 0.1, 1.6, null));
        _attacks.Add(new Attack("Rattle Strike", 15, 15, 0.15, 1.4, null));
        _attacks.Add(new Attack("Piercing Jab", 18, 18, 0.1, 1.7, null));
    }

    public override void UseSpecialAbility(Character target)
    {
        Console.WriteLine($"{_name} raises its guard!");
    }
}

