using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product
{
    public delegate void OnUpdate(object source);

    internal class Playeer
    {

        private int _id;
        private string _name;
        private int _score;
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public int Score { get { return _score; } set { _score = value; } }
        public event OnUpdate OnScore;
        public Playeer(int id, string name)
        {

            _id = id;
            _name = name;

        }
        public void details()
        {
            Console.WriteLine($"PlayerName:- {_name} PlayerId:- {_id} PlayerScore:- {_score}");
        }


    }
    interface IScoreable
    {
        void UpdateScore(int points);
    }

    class CausalPlayer : Playeer, IScoreable
    {

        public CausalPlayer(int id, string name) : base(id, name)
        {

        }

        public void UpdateScore(int points)
        {


            Score += points;
            if (points > 8)
            {
                Console.WriteLine("Bonus Points ");
                Score += 1;
            }
        }


        private void CausalPlayer_ScoreUpdate()
        {
            throw new NotImplementedException();
        }
    }
    class ProPlayer : Playeer, IScoreable
    {
        public ProPlayer(int id, string name) : base(id, name)
        {



        }
        public void UpdateScore(int points)
        {


            Score += points + 20;
        }

    }
    class GuestPalyer : Playeer, IScoreable
    {
        public GuestPalyer(int id, string name) : base(id, name)
        {


        }
        public void UpdateScore(int points)
        {


            Score += points;
        }


    }

    class prog
    {
        public static void Main(string[] args)
        {
            {

                CausalPlayer C1 = new CausalPlayer(2, "Jatin");
                C1.details();
                C1.UpdateScore(2);
                C1.details();
            }





        }

    }
}
