using Product;

namespace Product
{
    internal class PlayerMain
    {


        public int HealCapacity { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int MeleeDamage { get; set; }
        public int RangeDamage { get; set; }
        public string SpecialAbility { get; set; }

        public PlayerMain(string name, string abilty)    //Player class memebers
        {
            MaxHealth = 100;
            Name = name;
            Health = 100;
            MeleeDamage = 40;
            RangeDamage = 30;

           
            SpecialAbility=abilty;

            HealCapacity = 10;

        }

        public void UpgradeStats()                   // upgrade player data
        {
            MaxHealth += 20;
            Health = MaxHealth;
            MeleeDamage += 5;
            RangeDamage += 3;
            HealCapacity += 2;
        }


        public void Heal()            //healing
        {
            if (Health == MaxHealth)
            {
                Console.WriteLine("Already have Max health");
            }
            else
            {
                Health += HealCapacity;
                Console.WriteLine($"Healing Succesfull.New health is {Health}");
            }
        }


        public void TakeDamage(int damage)   // player take damage
        {

            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} took {damage} damage. Remaining health: {Health}");
            }
            else
            {
                Console.WriteLine($"{Name} took {damage} damage. Remaining health: {Health}");
            }
        }




        public void Attack(PlayerMain damaged, int amount)   //player attack to enemy
        {
            damaged.Health -= amount;
        }





        public void details()
        {
            Console.WriteLine($"PlayerName= {Name}\nHealth={Health}");   //player details
        }



    }


    class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MeleeDamage { get; set; }
        public int Heal { get; set; }

        public Enemy(string name, int health, int meleeDamage, int heal)
        {
            Name = name;
            Health = health;
            MeleeDamage = meleeDamage;
            Heal = heal;
        }

        public void takeDamage(int damage)
        {

            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} took {damage} damage. Remaining health: {Health}");
                Console.WriteLine($"{Name} died");

            }
            else
            {
                Console.WriteLine($"{Name} took {damage} damage. Remaining health: {Health}");
            }


        }

        public void details()
        {
            Console.WriteLine($"PlayerName= {Name}\nHealth={Health}");
        }
    }








    class Game
    {

        private PlayerMain player;
        private List<Enemy> enemies;
        private int currentLevel;


        public Game(PlayerMain player)
        {
            this.player = player;
            enemies = new List<Enemy>();
            currentLevel = 1;
        }

        public void Start()             //Start fight here
        {
            Console.WriteLine($"{player.Name} embarks on a journey to reclaim the village from the Murlocs!");


            Console.WriteLine();
            Console.WriteLine("LOADING....");
            Console.WriteLine();
            Thread.Sleep(6000);
            Console.Clear();
            //  Console.;
            while (currentLevel != 6)
            {

                Console.WriteLine($"\t\t\t\t\t\t------>Level {currentLevel} begins!<------");
                Console.WriteLine();
                SetupLevel();  //for creating the enemies
                BattleLoop();   // fight between player and enmies
                if (currentLevel < 6)
                {
                    player.UpgradeStats();
                }
                currentLevel++;
            }
            if (currentLevel == 6)
            {
                FinalBossFight();
            }
        }



        private void SetupLevel()
        {
            enemies.Clear();
            int numberOfEnemies = currentLevel; // Level 1 ke pass 1 enemy and so on;
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies.Add(new Enemy($"Enemy {i + 1}", 50 + 30 * i, 10 + i * 2, 8 + i));
            }
            Console.WriteLine();
            Console.WriteLine($"You will fight {numberOfEnemies} enemies.");
            Console.WriteLine();
        }


        private void BattleLoop()
        {
            bool levelComplete = false;
            // Random random = new Random();
            int turn = 0;
            while (!levelComplete)
            {

                // int turn = random.Next(2);


                if (turn == 0)
                {
                    turn = 1;
                    Console.WriteLine();
                    Console.WriteLine("Your Turn");

                    foreach (var enemy in enemies)
                    {
                        if (enemy.Health > 0)
                        {
                            PlayerTurn(enemy);
                            if (enemy.Health <= 0)
                            {
                                enemies.Remove(enemy);
                                break;
                            }
                        }
                    }
                }
                else  // 
                {
                    turn = 0;
                    //Console.WriteLine("Enemy Turn");
                    //  Console.WriteLine();
                    foreach (var enemy in enemies)
                    {
                        if (player.Health > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{enemy.Name} Turn");
                            EnemyTurn(enemy);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine($"{player.Name} has died. Game Over.");
                                break;
                            }
                        }
                    }
                }




                levelComplete = CheckLevelCompletion();
            }
        }

        private void PlayerTurn(Enemy enemy)
        {
            Console.WriteLine("\nChoose your action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine();
            string action = Console.ReadLine();
            Random rand= new Random();
            int ProbilityOfSpecialAbility=rand.Next(1,11);  //10 percent probalibity of activation

            if (action == "1")
            {
                if(ProbilityOfSpecialAbility==5)
                {
                    Console.WriteLine($"Player Special Ability -> {player.SpecialAbility} Activated");
                    player.Health = player.MaxHealth;
                }
                int damage = player.MeleeDamage;
                enemy.takeDamage(damage);
            }
            else if (action == "2")
            {
                if(ProbilityOfSpecialAbility == 5)
                {
                    Console.WriteLine($"Player Special Ability -> {player.SpecialAbility} Activated");
                    player.Health = player.MaxHealth;
                }
                player.Heal();
            }
            else
            {
                Console.WriteLine("Invalid action.");
            }
        }

        private void EnemyTurn(Enemy enemy)
        {

            Random rand = new Random();
            int action = rand.Next(2);

            if (action == 0)
            {
                Console.WriteLine($"{enemy.Name} attacks!");
                int damage = enemy.MeleeDamage;
                player.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{enemy.Name} is healing!");
                enemy.Health += 2;

            }
        }
        private bool CheckLevelCompletion()
        {
            bool allEnemiesDefeated = true;
            foreach (var enemy in enemies)
            {
                if (enemy.Health > 0)
                {

                    allEnemiesDefeated = false;
                    break;
                }
            }
            if (allEnemiesDefeated)
            {

                AwardLevelReward();

                Thread.Sleep(3000);
                Console.Clear();
                return true;
            }
            return false;
        }


        private void AwardLevelReward()
        {
            player.UpgradeStats();

            switch (currentLevel)
            {
                case 1:
                    Console.WriteLine("Level 1 complete! You earned a Map.");
                    Console.WriteLine("Next Level Loading");
                    break;
                case 2:
                    Console.WriteLine("Level 2 complete! You earned a Sword (Melee Damage +5).");
                    player.MeleeDamage += 5;
                    Console.WriteLine("Next Level Loading");
                    break;
                case 3:
                    Console.WriteLine("Level 3 complete! You earned a Shield (HealCapacity +5).");
                    player.HealCapacity += 5;
                    Console.WriteLine("Next Level Loading");
                    break;
                case 4:
                    Console.WriteLine("Level 4 complete! You earned Armour (HealCapacity +5).");
                    player.HealCapacity += 5;
                    Console.WriteLine("Next Level Loading");
                    break;
                case 5:
                    Console.WriteLine("Level 5 complete! You earned a Bow (Ranged Damage +5).");
                    player.RangeDamage += 5;
                    Console.WriteLine("Boss Level Loading");
                    break;
                case 6:
                    break;
            }
        }
        private void FinalBossFight()
        {
            Console.WriteLine("\nYou face the mighty Murlocs, the final boss!");

            Enemy boss = new Enemy("Murlocs", 500, 50, 10);

            while (boss.Health > 0 && player.Health > 0)
            {
                PlayerTurn(boss);
                if (boss.Health > 0)
                {
                    MurlocsTurn(boss);
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine("You defeated Murlocs and reclaimed the village!");

            }
            else
            {
                Console.WriteLine("You have been defeated. Game Over.");
            }
        }
        private void MurlocsTurn(Enemy boss)
        {

            Random rand = new Random();
            int move = rand.Next(1, 4);


            switch (move)
            {
                case 1:
                    Console.WriteLine("Murlocs uses Ground Slash! It damage you !");
                    int aDamage = 50;
                    player.Health -= aDamage;
                    Console.WriteLine($"You take {aDamage} damage. Remaining health: {player.Health}");
                    break;
                case 2:
                    Console.WriteLine("Murlocs uses Speed Dash! It bypasses your defence and strikes you!");
                    int speedDashDamage = 70;
                    player.Health -= speedDashDamage;
                    Console.WriteLine($"You take {speedDashDamage} damage. Remaining health: {player.Health}");
                    break;
                case 3:
                    Console.WriteLine("Murlocs regenerates some health!");
                    boss.Health += 30;
                    Console.WriteLine($"Murlocs regenerates health. Current health: {boss.Health}");
                    break;
            }
        }


    }

}



public class mainfield
{
    public static void Main(string[] args)
    {


        string line = "-----------------------------------";
        string message = "Welcome to Jatin Garg Gaming World";

        int consoleWidth = Console.WindowWidth;

        int startPositionLine = (consoleWidth - line.Length) / 2;
        Console.SetCursorPosition(startPositionLine, Console.CursorTop);
        Console.WriteLine(line);


        int startPositionMessage = (consoleWidth - message.Length) / 2;
        Console.SetCursorPosition(startPositionMessage, Console.CursorTop);
        Console.WriteLine(message);


        Console.SetCursorPosition(startPositionLine, Console.CursorTop);
        Console.WriteLine(line);
        Console.Write("Enter your hero's name: ");
        string playerName = Console.ReadLine();

        Console.Clear();

        PlayerMain player = new PlayerMain(playerName, "Healing to MaxHealth");


        Game game = new Game(player);

        game.Start();


    }
}
