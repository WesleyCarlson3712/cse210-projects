public class Skeleton : Character
{
    public Skeleton() : base("Skeleton", 1200, 0.3, 0.1)
    {
        _attacks.Add(new Attack("Boner Smash", 80, 180, 0.1, 1.5));
        _attacks.Add(new Attack("Rattle Strike", 50, 100, 0.1, 3, 1, 1));
        _attacks.Add(new Attack("Skull Slam", 100, 120, 0.3, 2, 0, 0, 1, 0.3));
        _specialName = "Gaster Blaster";
    }

    public override List<string> UseSpecialAbility(Character target)
    {
        return PerformAttack(target, new Attack(_specialName, 200, 200, 1, 2, 1, 1));
    }
}

