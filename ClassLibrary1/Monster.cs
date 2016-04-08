using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scion.Main
{
    public class Monster
    {
        public string Name { get; set; }
        public int EpicDex { get; set; }
        public int Joinbattle { get; set; }
        public Random rand = new Random();

        public Monster() { }
        public Monster (string _Name, int _EpicDex, int _joinBattle ):this()
        {
            Name = _Name;
            EpicDex = _EpicDex;
            Joinbattle = _joinBattle;
        }

        public int rollit()
        {
            int temp = EpicDex;

            for (int i = 0; i == Joinbattle; i++)
            {
                int roll = rand.Next(1, 10);

                if (roll > 6) { temp++; }
                if (roll == 10) { temp++; } 
            }

            return temp;

        }

    }
}
