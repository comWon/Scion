using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scion.MainHard
    {
    public class Structural
    {
        public CharacterSet activeCharacters = new CharacterSet();
        public List<Monster> MonsterSet = new List<Monster>();

        public static List<Monster> TestMobs()
        {
            List<Monster> testMobs = new List<Monster>();

            Monster m = new Monster("skeleton", 0, 5);
            Monster n = new Monster("zombie", 0, 4);
            Monster o = new Monster("GangMember", 0, 6);

            testMobs.Add(m);
            testMobs.Add(n);
            testMobs.Add(o);

            return testMobs;
        }
    }
}
