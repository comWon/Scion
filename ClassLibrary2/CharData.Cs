﻿using System;
using System.ComponentModel;

/// <summary>
/// Data store for active characters and Mobs, 
/// </summary>

namespace Scion.MainHard
{
    /// <summary>
    /// Object to hold char base data
    /// </summary>
    public class CharData : INotifyPropertyChanged
    {
        /// <summary>
        /// Variables named by function in SCION by White Wolf
        /// </summary>
        public string ToonName { get; set; }
        public string PlayerName { get; set; }
        public int joinBattle { get; set; }
        private int _currentStep;
        public int currentStep
        {
            get { return _currentStep; }
            set { _currentStep = value; }
        }
        public int epicDex { get; set; }
        public int speed { get; set; }
        public bool Monster { get; set; }
        public int? Successes;
        public int SuccessesSetUp { get; set; }
        public static Monster PlayerMonster = new Monster("Player", 0, 0);

        private Monster MonsterType;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool Ready { get; set; }
        public bool Rdy { get { return Ready; } }

        public void Action(int ticks)
        {
            currentStep = currentStep + ticks;
        }
        public void move()
        {
            _currentStep--;
        }

        public CharData()
        {
            ToonName = "Nonny mouse the Monster";
            PlayerName = "NPC";
            this.speed = 6;
            this.currentStep = 0;
            Monster = true;
            Ready = false;
            MonsterType = new Monster();
            Successes = null;
        }

        public CharData(string Player, int joinBattleIn, int epicDexIn) : this()
        {
            Monster = false;
            PlayerName = Player;
            Ready = false;
            epicDex = epicDexIn;
            joinBattle = joinBattleIn;
            ToonName = "";
            MonsterType = PlayerMonster;
        }

        public CharData(string Player, string _name, int joinBattleIn, int epicDexIn) : this(Player, joinBattleIn, epicDexIn)
        {
            ToonName = _name;
        }

        public CharData(Monster m, string refrence) : this()
        {
            ToonName = refrence;
            epicDex = m.EpicDex;
            joinBattle = m.Joinbattle;
            MonsterType = m;
        }

        public string ReturnJoinBattle()
        {
            string temp;
            temp = joinBattle.ToString();
            if (epicDex > 0)
            {
                temp = temp + "  +" + epicDex.ToString();
            }
            return temp;
        }

        public void MonsterInit()
        {
            if (Monster == false) { Exception NotAMonster = new Exception("Not A Monster"); throw NotAMonster; }
            MonsterType.Joinbattle = this.joinBattle;
            Successes = MonsterType.rollit();
            //Ready = true;
        }

        public void RollInitiative(int SuccessesIn)
        {
            Successes = SuccessesIn;
            Ready = true;
        }

        /// <summary>
        /// Enter Combat
        /// </summary>
        /// <param name="HighestSucceses"> the highest no of successes rolled</param>
        public void trigger(int HighestSucceses)
        {
            if (Successes == null)
            {
                if (Monster == true) { MonsterInit(); } else { Exception e = new Exception("Not ready Yet"); throw e; }
            }
           
            if (HighestSucceses < Successes) { Exception InvalidStartException = null; throw InvalidStartException; }

            speed = HighestSucceses - Successes.Value;
            if (speed > 6)
            { speed = 6; }

            currentStep = speed;
            Ready = true;
        }

        /// <summary>
        /// Remove Combat Status
        /// </summary>
        public void EndCombat()
        {
            if (Ready == false) { Exception NotInCombat = null; throw NotInCombat; }
            Successes = -1;
            speed = 0;
            currentStep = 0;
            Ready = false;

        }
        public int ReturnPosition()
        {
            return currentStep;
        }

        public void NextAction()
        {
            move();
        }

        public void setPosition(int pos)
        {
            speed = pos;

            currentStep = speed;
        }

        public void MoveAction()
        {
            if (currentStep > 0) { move(); }
        }

        /// <summary>
        /// To Hold file name of image Generated by interface; 
        /// </summary>
        public string Image { get; set; }


        private bool _dead;
        /// <summary>
        /// To remove from combat.
        /// 
        /// </summary>
        
        public bool Dead { get { return _dead; } set { _dead = Dead;NotifyPropertyChanged("Dead"); } }

        private void NotifyPropertyChanged(string name)
        {

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}