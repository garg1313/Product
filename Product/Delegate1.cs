using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product
{
    public delegate void OnUpdate();

    internal class Playeer
    {

        private int _id;
        private string _name;
        private int _score;
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public int Score { get { return _score; } set { _score = value; OnscoreUpdate(); } }
        public event OnUpdate OnScore;
        public Playeer(int id, string name,int score)
        {

            _id = id;
            _name = name;
            _score = score;

        }
        public void details()
        {
            Console.WriteLine($"PlayerName:- {_name}\nPlayerId:- {_id}\nPlayerScore:- {_score}\n");
        }
        private void OnscoreUpdate()
            
        {
            Console.WriteLine($"{_name} Score Updated\n");
            OnScore?.Invoke();
        }

    }
    interface IScoreable
    {
        void UpdateScore(int points);
    }

    class CausalPlayer : Playeer, IScoreable
    {

        public CausalPlayer(int id, string name, int score) : base(id, name,score)
        {

        }

        public void UpdateScore(int points)
        {

            if (points > 8)
            {
                Console.WriteLine("Bonus Points ");
                Score += points + 1;
            }
            else
            {
                Score += points;
            }
            
        }


        
    }
    class ProPlayer : Playeer, IScoreable
    {
        public ProPlayer(int id, string name, int score) : base(id, name,score)
        {



        }
        public void UpdateScore(int points)
        {


            Score += points + 20;
        }

    }
    class GuestPalyer : Playeer, IScoreable
    {
        public GuestPalyer(int id, string name, int score) : base(id, name, score)
        {


        }
        public void UpdateScore(int points)
        {


            Score += points;
        }


    }
    class LeaderBoard()
    {
        private List<Playeer> playerList = new List<Playeer>();
        public void Addplayer(Playeer player) {
            playerList.Add(player);
            player.OnScore += DisplayLeader;
        }
        public void DisplayLeader()

        {
            Console.WriteLine("---LeaderBoard---\n");
            foreach (var play in playerList)

            {
                
                play.details();
            }
        }
    }
        class prog
    {
        /*public static void Main(string[] args)
        {
            {

                CausalPlayer C1 = new CausalPlayer(2, "Rahul", 100);
                ProPlayer p1 = new ProPlayer(4, "Jatin", 100);
                GuestPalyer g1 = new GuestPalyer(5, "Laddi", 100);


                LeaderBoard board = new LeaderBoard();
                board.Addplayer(C1);
                board.Addplayer(p1);
                board.Addplayer(g1);

                C1.UpdateScore(9);
                p1.UpdateScore(12);
                g1.UpdateScore(12);


            }
        }*/

    }
}
