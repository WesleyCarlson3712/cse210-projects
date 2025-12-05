public class Program
    {
        
        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("Choose your class:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");

            Character player = null;
            Character enemy = null;
            int choice = HelperFunctions.GetInt(1,3);

            switch (choice)
            {
                case 1:
                    player = new Warrior();
                    break;
                case 2:
                    player = new Mage();
                    break;
                case 3:
                    player = new Rogue();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Choose your opponent:");
            Console.WriteLine("1. Zombie");
            Console.WriteLine("2. Skeleton");
            Console.WriteLine("3. Ghoul");

            choice = HelperFunctions.GetInt(1,3);
            switch (choice)
            {
                case 1:
                    enemy = new Zombie();
                    break;
                case 2:
                    enemy = new Skeleton();
                    break;
                case 3:
                    enemy = new Ghoul();
                    break;
            }
            
            Console.Clear();
            BattleManager battle = new BattleManager(player, enemy);
            battle.StartBattle();
        }
    }
