public class Zombie : Character
{
    private int _regen;

    public Zombie() : base("Zombie", 1800, 0, 0.1)
    {
        _attacks.Add(new Attack("Bite", 50, 60, 0.15, 8));
        _attacks.Add(new Attack("Claw", 80, 120, 0.1, 2));
        _attacks.Add(new Attack("Lunge", 120, 150, 0, 0, 0.1));
        _specialName = "Regenerate";
        _regen = 400;
    }

    public override List<string> UseSpecialAbility(Character target)
    {

        _hp += _regen;
        _maxHp += _regen * 2; // increases maxhp just so that it doesnt regenerate to over half and regain its ability use when it drops below half again
        List<string> updates = new List<string>();
        updates.Add($"{_name} uses {_specialName}!");
        updates.Add($"{_name} regenerates {_regen} HP");
        return updates;
    }
}

