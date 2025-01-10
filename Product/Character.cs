using System;
class Character
{
    private string _name;
    private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public Character(string name)
    {
        Health = _health;
        _name = name;
    }
    public void Attack()
    {
        Console.WriteLine(" Attacking !!");



    }
    public void take_Damage(int damage)
    {
        Console.WriteLine("Be Carefull " + _name + "! Opponent is attacking");
        _health -= damage;
        if (_health <= 0)
        {
            Console.WriteLine(_name + " Died");

        }

    }


}
class Hero : Character
{
    public Hero(string name) : base(name) { }

    public void IncreaseHealth()
    {
        Console.WriteLine("Hero Special ability activating");
        Health += 10;
    }
}

class Enemy : Character
{
    Hero hero;

    public Enemy(string name) : base(name)
    {
    }

    public void SetHero(Hero hero) => this.hero = hero;

    public void GrabHealth()
    {
        Console.WriteLine("Enemy Special ability activated");
        hero.Health -= 10;
        Health += 10;

    }
}
class program
{
    /*public static void Main(string[] args)
    {
        Hero Shaktimaan = new Hero("Shaktimaan");
        Shaktimaan.Health = 100;
        Console.WriteLine(Shaktimaan.Health);
        Shaktimaan.take_Damage(45);
        Console.WriteLine(Shaktimaan.Health);
        Shaktimaan.IncreaseHealth();
        Console.WriteLine(Shaktimaan.Health);
        Enemy E1 = new Enemy("BlackDog");
        E1.SetHero(Shaktimaan);
        E1.GrabHealth();
        Console.WriteLine(Shaktimaan.Health);
        Console.WriteLine(E1.Health);
        E1.take_Damage(110);



    }*/

}