using System;


public class BattleManager
{
    private Character _player;
    private Character _enemy;
    private bool _isPlayerTurn;
    private List<string> _battleUpdates;
    private int _turnCounter = 1;


    public BattleManager(Character player, Character enemy)
    {
        _player = player;
        _enemy = enemy;
        _isPlayerTurn = true;
        _battleUpdates = new List<string>();
    }
    public void DisplayStats(Character player, Character enemy)
        {
            Console.WriteLine($"Turn {_turnCounter}");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{player.GetName()}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"HP: {player.GetHP()}");
            Console.WriteLine($"Evasion: {player.GetEvasion() * 100}%");
            Console.WriteLine($"Resistance: {player.GetResistance() * 100}%");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{enemy.GetName()}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"HP: {enemy.GetHP()}");
            Console.WriteLine($"Evasion: {enemy.GetEvasion() * 100}%");
            Console.WriteLine($"Resistance: {enemy.GetResistance() * 100}%");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            foreach(string update in _battleUpdates)
            {
                Console.WriteLine(update);
            }
            Console.WriteLine("----------------------------------------");
        }
    public void StartBattle()
    {

        _battleUpdates.Add("Battle begins!");
        while (!IsBattleOver())
        {
            DisplayStats(_player, _enemy);
            _battleUpdates.Clear();
            if (_isPlayerTurn)
                PlayerTurn();
            else
                EnemyTurn();

            SwitchTurn();
        }
        DisplayStats(_player, _enemy);
        EndBattle();
    }

    private void PlayerTurn()
    {
        Console.WriteLine($"{_player.GetName()}'s turn!");
        Console.WriteLine("Choose your attack:");
        
        if(_player.IsSpecialAvailable())
        {
            Console.WriteLine($"0: {_player.GetSpecialName()}: (Special Ability)");
        }

        List<Attack> availableAttacks = [];
        foreach(Attack attack in _player.GetAttacks())
        {
            if(!attack.IsOnCooldown())
            {
                availableAttacks.Add(attack);
            }
            else
            {
                attack.ToggleCooldown();
            }
        }
            for(int i = 0; i < availableAttacks.Count(); i++)
            {
                Console.WriteLine($"{i + 1}: {availableAttacks[i].GetName()}");
            }
    
        int choice = HelperFunctions.GetInt(_player.IsSpecialAvailable() ? 0 : 1, availableAttacks.Count());
        if(choice == 0)
        {
            _battleUpdates.AddRange(_player.UseSpecialAbility(_enemy));
            _player.SetSpecialAvailable(false);
            return;
        }
        _battleUpdates.AddRange(_player.PerformAttack(_enemy, availableAttacks[choice - 1]));
        availableAttacks[choice - 1].ToggleCooldown();
    }

    private void EnemyTurn()
    {
        _battleUpdates.Add($"{_enemy.GetName()}'s turn!");

        if(_enemy.IsSpecialAvailable() && HelperFunctions.GetRandDouble() < 0.33)
        {
            _battleUpdates.AddRange(_enemy.UseSpecialAbility(_player));
            _enemy.SetSpecialAvailable(false);
        }
        else
        {
            List<Attack> availableAttacks = new List<Attack>();
            foreach(Attack attack in _enemy.GetAttacks())
            {
                if(!attack.IsOnCooldown())
                {
                    availableAttacks.Add(attack);
                }
                else
                {
                    attack.ToggleCooldown();
                }
            }

            int choice = HelperFunctions.GetRandInt(0, availableAttacks.Count());
            _battleUpdates.AddRange(_enemy.PerformAttack(_player, availableAttacks[choice]));
            availableAttacks[choice].ToggleCooldown();

        }
        Console.Write("> ");
        Console.ReadLine();
    }

    private void SwitchTurn()
    {
        Console.Clear();
        _turnCounter++;
        if(_isPlayerTurn){
            if(_enemy.GetStun() > 0)
            {
                _enemy.SetStun(_enemy.GetStun() - 1);
                return;
            }
        }
        else
        {
            if(_player.GetStun() > 0)
            {
                _player.SetStun(_player.GetStun() - 1);
                return;
            }
        }
        
        _isPlayerTurn = !_isPlayerTurn;
    }

    private bool IsBattleOver()
    {
        return _player.GetHP() <= 0 || _enemy.GetHP() <= 0;
    }

    private void EndBattle()
    {
        Console.WriteLine("Battle is over!");
        if(_player.GetHP() <= 0)
        {
            Console.WriteLine($"{_enemy.GetName()} has defeated {_player.GetName()}!");
        }
        else
        {
            Console.WriteLine($"{_player.GetName()} has defeated {_enemy.GetName()}!");
        }
    }
}