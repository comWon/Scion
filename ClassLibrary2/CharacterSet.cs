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
                nullChack();

                if (C.Rdy == false) { Exception NotYetReady = null; throw NotYetReady; }
                if (C.Monster == true && C.Successes == -1 ) { C.MonsterInit(); }
                
            }

            int Target = ActiveChars.Aggregate((curMax, x) => (curMax == null || x.Successes > curMax.Successes ? x : curMax)).Successes;
            
            foreach (CharData C in ActiveChars)
            {
                C.trigger(Target);
            }  

        }

        private void nullChack()
        {
            if (ActiveChars == null)
            {
                ActiveChars = new List<CharData>();
            }
        }

        public IEnumerable<CharData> ActiveCharacters ()
        {
            nullChack();

            return ActiveChars.Where(x => x.ReturnPosition() == 0);
        }

        public IEnumerable Listing()
        {

            nullChack();

            return ActiveChars;
        }

        public CharData Next()
        {

            nullChack();

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
            if  (ActiveChars.Count(x => x.ReturnPosition() == 0 && !x.Dead) != 0) { Exception PlayersToGo = null; throw PlayersToGo; }
                        
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

            nullChack();

            if (M.Joinbattle ==0) { Exception MonsterNotSet=null;  throw MonsterNotSet; }
            for (int i = 0; i < Number; i++)
            {
                CharData Mon = new CharData(M, M.Name + i.ToString());
                ActiveChars.Add(Mon);
            }


        }

        public void AddCharacter(CharData c)
        {

            nullChack();

            ActiveChars.Add(c);
        }
    }
}
