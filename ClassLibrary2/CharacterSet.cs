using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scion.MainHard
{
    public class CharacterSet : INotifyPropertyChanged
    {
        List<CharData> ActiveChars;

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartCombat()
        {
            foreach (CharData C in ActiveChars)
            {
                nullChack();

                if (C.Rdy == false) { Exception NotYetReady = null; throw NotYetReady; }
                if (C.Monster == true && C.Successes == -1) { C.MonsterInit(); }

            }

            int Target = ActiveChars.Aggregate((curMax, x) => (curMax == null || x.Successes.Value > curMax.Successes ? x : curMax)).Successes.Value;

            foreach (CharData C in ActiveChars)
            {
                C.trigger(Target);
            }

        }

        public int count ()
        {
            return ActiveChars.Count();
        }

        public int CurrentCount()
        {
            return ActiveChars.Where(x => x.Rdy == true).Count();
        }

        private void nullChack()
        {
            if (ActiveChars == null)
            {
                ActiveChars = new List<CharData>();
            }
        }

        public IEnumerable<CharData> ActiveCharacters()
        {
            nullChack();

            return ActiveChars.Where(x => x.ReturnPosition() == 0);
        }

        /// <summary>
        /// Returns Binding List of chars
        /// </summary>
        /// <returns></returns>
        public BindingList<CharData> Listing()
        {

            nullChack();

            BindingList<CharData> dbgs = new BindingList<CharData>();
            foreach (var cd in ActiveChars)
            {
                dbgs.Add(cd);
            }

            return dbgs;

        }

        public CharData Next()
        {

            nullChack();

            CharData Returns = ActiveChars.FirstOrDefault(x => x.ReturnPosition() == 0);

            if (Returns == null)
            {
                this.nextRound();
                return Next();
            }
            else
            {
                return Returns;
            }
        }
        /// <summary>
        /// Check All actions have occured, then starts the next round of combat
        /// </summary>
        public void nextRound()
        {
            if (ActiveChars.Count(x => x.ReturnPosition() == 0 && !x.Dead) != 0) { Exception PlayersToGo = null; throw PlayersToGo; }

            foreach (CharData C in ActiveChars)
            {
                C.NextAction();
            }
        }

        public void Kill(int rowIndex)
        {
            ActiveChars.RemoveAt(rowIndex);
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
        public void AddMonsters(Monster M, int Number)
        {

            nullChack();

            if (M.Joinbattle == 0) { Exception MonsterNotSet = null; throw MonsterNotSet; }
            for (int i = 0; i < Number; i++)
            {
                CharData Mon = new CharData(M, M.Name + i.ToString());
                ActiveChars.Add(Mon);
            }

            this.NotifyPropertyChanged("Monsters");
        }

        public void AddCharacter(CharData c)
        {

            nullChack();

            ActiveChars.Add(c);
            this.NotifyPropertyChanged("CharData");
        }

        public bool Ready()
        {
            foreach (CharData c in ActiveChars)
            {
                if (c.Rdy == false) { return false; }
            }

            return true;
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }

}
