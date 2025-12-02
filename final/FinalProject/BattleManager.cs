using System;


public class BattleManager
{
    private Character _player;
    private Character _enemy;
    private bool _isPlayerTurn;

    public BattleManager(Character player, Character enemy)
    {
        _player = player;
        _enemy = enemy;
        _isPlayerTurn = true;
    }
    public void DisplayStats(Character player, Character enemy)
        {
            Console.WriteLine("Stats");
            Console.WriteLine($"{player.GetName()} HP: {player.GetHP()}");
            Console.WriteLine($"{enemy.GetName()} HP: {enemy.GetHP()}");

        }
    public void StartBattle()
    {
        Console.WriteLine("Battle begins!");

        while (!IsBattleOver())
        {
            // Console.Clear();
            DisplayStats(_player, _enemy);
            if (_isPlayerTurn)
                PlayerTurn();
            else
                EnemyTurn();

            SwitchTurn();
        }

        EndBattle();
    }

    private void PlayerTurn()
    {
        Console.WriteLine("Player's turn!");
        Console.WriteLine("Choose attack:");
            for(int i = 0; i < _player.GetAttacks().Count(); i++)
            {
                Console.WriteLine($"{i + 1}: {_player.GetAttacks()[i].GetName()}");
            }
        int choice = HelperFunctions.GetInt(1,_player.GetAttacks().Count());
        _player.PerformAttack(_enemy, _player.GetAttacks()[choice - 1]);
    }

    private void EnemyTurn()
    {
        Console.WriteLine("Opponent's turn!");
        _enemy.PerformAttack(_player, _enemy.GetAttacks()[0]);
    }

    private void SwitchTurn()
    {
        _isPlayerTurn = !_isPlayerTurn;
    }

    private bool IsBattleOver()
    {
        return _player.GetHP() <= 0 || _enemy.GetHP() <= 0;
    }

    private void EndBattle()
    {
        Console.WriteLine("Battle is over!");
    }
}

