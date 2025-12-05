public class Rogue : Character
{
    public Rogue() : base("Rogue", 800, 0, 0.30)
    {
        _attacks.Add(new Attack("Backstab", 40, 60, 0.75, 4));
        _attacks.Add(new Attack("Quick Slash", 50, 75, 0.3, 2, 0, 0, 1, 0.6));
        _attacks.Add(new Attack("Tranquilizer Dart", 15, 30, 0, 0, -0.3, 0, 2, 1));
        _specialName = "Vanish";
    }

    public override List<string> UseSpecialAbility(Character target)
    {
        List<string> updates = new List<string>();
        updates.Add($"{_name} uses {_specialName}");
        updates.Add($"{_name} can not be targeted for 5 turns");
        PerformAttack(target, new Attack(_specialName, 0, 0, 0, 0, 1, 0, 5, 1));
        return updates;
    }
}

