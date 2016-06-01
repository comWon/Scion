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
            m.rollit();
            Monster n = new Monster("zombie", 0, 4);
            n.rollit();
            Monster o = new Monster("GangMember", 0, 6);
            o.rollit();

            testMobs.Add(m);
            testMobs.Add(n);
            testMobs.Add(o);

            return testMobs;
        }

        public static CharacterSet testToons () {

            CharacterSet returnthis = new CharacterSet();

            CharData Ton1 = new CharData("Player", "Roderic Weeble", 6, 1);
            CharData Ton2 = new CharData("Player2", "micky Noname", 8, 0);

            returnthis.AddCharacter(Ton1);
            returnthis.AddCharacter(Ton2);

            Ton1.RollInitiative( 4);
            Ton2.RollInitiative(6);

            return returnthis;
        }

        public static CharacterSet TestCombat()
        {
            CharacterSet returnthis = testToons();

            foreach (var m in TestMobs()) {
                returnthis.AddMonsters(m, 1);
                    }

            return returnthis;
        }
    }
}
