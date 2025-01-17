using Product;

namespace Product
{
    internal class PlayerMain
    {


        public int healcapacity { get; set; }
        public string _name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int MeleeDamage { get; set; }
        public int RangeDamage { get; set; }

        public int Defence { get; set; }

        public List<string> SpecialAbilities { get; set; }
        public List<string> Items { get; set; }

        public PlayerMain(string name, string abilty)    //Player class memebers
        {
            MaxHealth = 100;
            _name = name;
            Health = 100;
            MeleeDamage = 40;
            RangeDamage = 30;
            Defence = 10;
            SpecialAbilities = new List<string>();
            SpecialAbilities.Add(abilty);
            Items = new List<string>();
            healcapacity = 10;
            Items.Add("Hammer");
        }


        public void AddItemToInventory(string item)    //add items 
        {
            Items.Add(item);
            Console.WriteLine($"{_name} obtained {item}!");
        }

        public void UpgradeStats()                   // upgrade player data
        {
            MaxHealth += 20;
            Health = MaxHealth;
            MeleeDamage += 5;
            RangeDamage += 3;
            Defence += 2;
            healcapacity += 2;
        }


        public void Heal()            //healing
        {
            if (Health == MaxHealth)
            {
                Console.WriteLine("Already have Max health");
            }
            else
            {
                Health += healcapacity;
                Console.WriteLine($"Healing Succesfull.New health is{Health}");
            }
        }


        public void takeDamage(int damage)   // player take damage
        {

            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{_name} took {damage} damage. Remaining health: {Health}");
            }
            else
            {
                Console.WriteLine($"{_name} took {damage} damage. Remaining health: {Health}");
            }
        }




        public void Attack(PlayerMain damaged, int amount)   //player attack to enemy
        {
            damaged.Health -= amount;
        }





        public void details()
        {
            Console.WriteLine($"PlayerName= {_name}\nHealth={Health}");   //player details
        }



    }


    class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MeleeDamage { get; set; }
        public int Defence { get; set; }

        public Enemy(string name, int health, int meleeDamage, int defence)
        {
            Name = name;
            Health = health;
            MeleeDamage = meleeDamage;
            Defence = defence;
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
            Console.WriteLine($"{player._name} embarks on a journey to reclaim the village from the Murlocs!");


            Console.WriteLine();
            Console.WriteLine("LOADING....");
            Console.WriteLine();
            Thread.Sleep(5000);
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
                enemies.Add(new Enemy($"Enemy {i + 1}", 50 + 10 * i, 10 + i * 2, 5 + i));
            }
            Console.WriteLine();
            Console.WriteLine($"You will fight {numberOfEnemies} enemies.");
            Console.WriteLine();
        }


        private void BattleLoop()
        {
            bool levelComplete = false;
            Random random = new Random();

            while (!levelComplete)
            {

                int turn = random.Next(2);

                if (turn == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your Turn");

                    foreach (var enemy in enemies)
                    {
                        if (enemy.Health > 0)
                        {
                            PlayerTurn(enemy);
                            if (enemy.Health <= 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else  // 
                {

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
                                Console.WriteLine($"{player._name} has died. Game Over.");
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
            if (action == "1")
            {
                int damage = player.MeleeDamage;
                enemy.takeDamage(damage);
            }
            else if (action == "2")
            {
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
                player.takeDamage(damage);
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
                    Console.WriteLine("Mission failed");
                    allEnemiesDefeated = false;
                    break;
                }
            }
            if (allEnemiesDefeated)
            {

                AwardLevelReward();
                Console.WriteLine("WORKING---------");
                // Thread.Sleep(3000);
                /// Console.Clear();
                return true;
            }
            return false;
        }


        private void AwardLevelReward()
        {
            switch (currentLevel)
            {
                case 1:
                    Console.WriteLine("Level 1 complete! You earned a Map.");
                    player.UpgradeStats();
                    break;
                case 2:
                    Console.WriteLine("Level 2 complete! You earned a Sword (Melee Damage +5).");
                    player.MeleeDamage += 5;
                    break;
                case 3:
                    Console.WriteLine("Level 3 complete! You earned a Shield (Defence +5).");
                    player.Defence += 5;
                    break;
                case 4:
                    Console.WriteLine("Level 4 complete! You earned Armour (Defence +5).");
                    player.Defence += 5;
                    break;
                case 5:
                    Console.WriteLine("Level 5 complete! You earned a Bow (Ranged Damage +5).");
                    player.RangeDamage += 5;
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
                    Console.WriteLine("Murlocs uses Ground Slash! AOE damage!");
                    int aoeDamage = 50;
                    player.Health -= aoeDamage;
                    Console.WriteLine($"You take {aoeDamage} damage. Remaining health: {player.Health}");
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

        // Console.Clear();

        PlayerMain player = new PlayerMain(playerName, "Healing");


        Game game = new Game(player);

        game.Start();


    }
}
