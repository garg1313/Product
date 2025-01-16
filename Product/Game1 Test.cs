using System.Xml.Linq;

namespace Product
{
    internal class PlayerMain
    {
       
        private int _meleeDamage;
        private int _rangeDamage;
        private int _defence;
        private List<string> _specialAbilities;
        private List<string> _Items;
        public int healcapacity { get; set; }
        public string _name { get; set; }
        public int Health { get; set; }
        public int MeleeDamage { get { return _meleeDamage; } set { _meleeDamage = value; } }
        public int RangeDamage { get { return _rangeDamage; } set { _rangeDamage = value; } }

        public int Defence { get { return _defence; } set { _defence = value; } }
        public List<string> SpecialAbilities { get { return _specialAbilities; } set { _specialAbilities = value; } }
        public List<string> Items { get; set; }

        public PlayerMain(string name, int meleeDamage, int rangeDamage, int defence, string abilty, string item)
        {
            _name = name;
            Health = 100;
            _meleeDamage = meleeDamage;
            _rangeDamage = rangeDamage;
            _defence = defence;
            _specialAbilities = new List<string>();
            _specialAbilities.Add(abilty);
            _Items = new List<string>();
            healcapacity = 10;
            _Items.Add(item);
        }


        protected void Attack(PlayerMain damaged, int amount)
        {
            damaged.Health -= amount;
        }
        protected void Heal(PlayerMain player, int amount)
        {
            player.Health += amount;
        }
        public void details()
        {
            Console.WriteLine($"PlayerName= {_name}\nHealth={Health}");
        }
        public void takeDamge(int damage)
        {

            Health -= damage;
        }
    }


    class Enemy
    {
         public int healcapacity { get; set; }
    
        public string name { get; set; }
        public int health { get; set; }
        public int meleeDamage { get; set; }
        public int rangeDamage { get; set; }
        public Enemy(string name, int meleeDamage, int rangeDamage)
        {
            this.name = name;
            health = 100;
            this.meleeDamage = meleeDamage;
            this.rangeDamage = rangeDamage;
            healcapacity = 5;
        }
        public void takeDamge(int damage)
        {

            health -= damage;
        }
            public void details()
        {
            Console.WriteLine($"PlayerName= {name}\nHealth={health}");
        }
    }
    

    class Levels
    {
        public int level;
        PlayerMain Player;
        public Levels(PlayerMain playe)
        {
            Player = playe;
            level = 1;
        }
        private void getLevel(int level)
        {
            fight f=new fight();
            switch (level)
            {
                case 1:
                    Enemy enemy1 = new Enemy("Thanos", 20, 40);
                    f.StartFight(Player, enemy1);
                    
                    break;
                case 2:
                    return;
            }
        }

    }
    class fight
    {

        public void StartFight(PlayerMain player, Enemy enemy)
        {
            Random rand=new Random();
           
            while (player.Health > 0 && enemy.health > 0)
            {
                int turn = rand.Next(1, 3);
                if (turn == 1)
                {
                    Console.WriteLine($"{player._name} Turn");
                    Console.WriteLine("Choose your Action");
                    Console.WriteLine("1.Attack");
                    Console.WriteLine("2.Heal");
                    int ch = int.Parse(Console.ReadLine());
                    if (ch == 1)
                    {
                        enemy.takeDamge(player.MeleeDamage);
                        enemy.details();

                    }
                    else if (ch == 2)
                    {
                        player.Health += player.healcapacity;
                        player.details();
                    }
                     turn = rand.Next(1, 3);

                }
                else
                {
                    Console.WriteLine($"{enemy.name} Turn");
                    Console.WriteLine("Choose your Action");
                    Console.WriteLine("1.Attack");
                    Console.WriteLine("2.Heal");
                    int ch = int.Parse(Console.ReadLine());
                    if (ch == 1)
                    {
                        player.takeDamge(enemy.meleeDamage);
                        player.details();

                    }
                    else if (ch == 2)
                    {
                        enemy.health += enemy.healcapacity;
                        enemy.details();
                    }
                    turn = rand.Next(1, 3);

                }
            }
                if (player.Health <= 0)
            {
                Console.WriteLine("Player  lost");


            }
            else
                {
                    Console.WriteLine("Enemy Won");
                }
            
        }
    }



    public class mainfield
    {
        public static void Main(string[] args)
        {
            PlayerMain p1 =new PlayerMain("Jatin",30,50,10,"Healing2x","Hammer");
            Enemy e1 = new Enemy("Thanos", 20, 30);
            fight f1=new fight();
            f1.StartFight(p1,e1);

        }
    }






}
