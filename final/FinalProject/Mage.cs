public class Mage : Character
{
    public Mage() : base("Mage", 1000, 0, 0.1)
    {
        _attacks.Add(new Attack("Fireball", 100, 180, 0.15, 1.5));
        _attacks.Add(new Attack("Ice Spike", 60, 70, 0.3, 1.7, 0, 1, 1, 0.5));
        _attacks.Add(new Attack("Lightning Bolt", 150, 150, 0, 0, 1, 1));
        _specialName = "Elemental Blast";
    }

    public override List<string> UseSpecialAbility(Character target)
    {
        List<string> updates = new List<string>();
        updates.Add($"{_name} uses {_specialName}");
        updates.Add("Unleashes all elemental forces");
        foreach(Attack attack in _attacks)
        {
            updates.AddRange(PerformAttack(target, attack));
        }
        return updates;
    }
}
