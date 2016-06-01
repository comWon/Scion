using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scion.MainHard
    {
    public class Structural
    {
        public CharacterSet activeCharacters { get; set; }
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

        public static CharacterSet TestCharSet ()
        {
            CharacterSet ac = new CharacterSet();

            foreach (var m in TestMobs())
            {
                ac.AddMonsters(m, 1);
            }
            CharData c = new CharData("Name","_Name",6,6);
            ac.AddCharacter(c);

            return ac;
        }
    }
}
