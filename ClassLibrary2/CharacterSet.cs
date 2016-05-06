using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scion.MainHard
{
    public class CharacterSet
    {
        List<CharData> ActiveChars;

        public void StartCombat()
        {
            foreach (CharData C in ActiveChars)
            {
                if (C.Rdy == false) { Exception NotYetReady = null; throw NotYetReady; }
                if (C.Monster == true && C.Successes == -1 ) { C.MonsterInit(); }
                
            }

            int Target = ActiveChars.Aggregate((curMax, x) => (curMax == null || x.Successes > curMax.Successes ? x : curMax)).Successes;
            
            foreach (CharData C in ActiveChars)
            {
                C.trigger(Target);
            }  

        }

        public IEnumerable<CharData> ActiveCharacters ()
        {
            return ActiveChars.Where(x => x.ReturnPosition() == 0);
        }

        public IEnumerable Listing()
        {
            return ActiveChars;
        }

        public CharData Next()
        {
            CharData Returns = ActiveChars.FirstOrDefault(x => x.ReturnPosition() == 0);

            if (Returns==null)
            {
                this.nextRound();
                return Next();
            } else
            {
                return Returns;
            }
        }
        /// <summary>
        /// Check All actions have occured, then starts the next round of combat
        /// </summary>
        public void nextRound ()
        {
            if  (ActiveChars.Count(x => x.ReturnPosition() == 0) != 0) { Exception PlayersToGo = null; throw PlayersToGo; }

            foreach (CharData C in ActiveChars)
            {
                C.NextAction();
            }
        }

        /// <summary>
        /// Removes all Monsters from combat
        /// </summary>
        public void EndCombat()
        {
            ActiveChars = ActiveChars.Where(x => x.Monster == false).ToList();
        }

        /// <summary>
        /// Add a set of monsters
        /// </summary>
        /// <param name="M"> monster to add,</param>
        /// <param name="Number"> Count of Monsters to add</param>
        public void AddMonsters (Monster M, int Number)
        {
            if (M.Joinbattle ==0) { Exception MonsterNotSet=null;  throw MonsterNotSet; }
            for (int i = 0; i < Number; i++)
            {
                CharData Mon = new CharData(M, M.Name + i.ToString());
                ActiveChars.Add(Mon);
            }


        }

        public void AddCharacter(CharData c)
        {
            ActiveChars.Add(c);
        }
    }
}
