public class Ghoul : Character
{
    public Ghoul() : base("Ghoul", 800, 0, 0.25)
    {
        _attacks.Add(new Attack("Rend", 160, 180, 0, 0, 0, 1));
        _attacks.Add(new Attack("Pounce", 100, 130, 0.5, 1.3, 1, 1));
        _attacks.Add(new Attack("Spirit Drain", 50, 70, 0, 0, 1, 1, 1, 0.5));
        _specialName = "possess";
    }

    public override List<string> UseSpecialAbility(Character target)
    {
        List<string> updates = new List<string>();
        updates.Add($"{_name} uses {_specialName}");
        updates.Add($"{_name} possesses {target.GetName()} to use an attack against themself");
        updates.AddRange(PerformAttack(target, target.GetAttacks()[0]));
        PerformAttack(target, new Attack(_specialName, 0, 0, 0, 0, 1, 0, 2, 1));
        updates.Add($"{target.GetName()} is stunned and cannot act for 2 turns");
        return updates;
    }
}

