namespace Product
{
    enum level
    {
        Low,
        Medium,
        High

    }
    internal class Player
    {
        private string _name;
        private int _health;
        private level _level;
        public Player(string name, int health, level level)
        {
            _name = name;
            _health = health;
            _level = level;
        }

        public string Name { get { return _name; } }
        public int Health { get { return _health; } }
        public level Level { get { return _level; } }

        public void Levelup(level level)
        {
            _level = (level)(((int)_level + 1) % Enum.GetValues(typeof(level)).Length);
        }
    }

    class run
    {
        /* public static void Main(string[] args)
         {
             Player P1 = new Player("Jatin Garg",100,level.Medium);
             Console.WriteLine(P1.Name);
             Console.WriteLine(P1.Level);
             Console.WriteLine(P1.Health);
             Console.WriteLine("Wait for level up");
             P1.Levelup(P1.Level);
             Thread.Sleep(5000);
             Console.WriteLine("Level Up Successful");
             Console.WriteLine($"New Level of {P1.Name} is {P1.Level}");



         }*/
    }
}
