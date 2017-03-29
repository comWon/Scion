using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scion.MainHard;

namespace UnitTests
{
    [TestClass]
    public class CharDataTests
    {
        //CharDatat Tests:            pass next action, passs speed, attempt action while not ready, get current poisition while ready and not ready.

        [TestMethod]
        public void GenerateFromMonster()
        {
            //arrange
            Monster Mon = new Monster("Skeleton", 0, 7);
            string name = "SkeletonName";

            int expectedInit = 7;

            //act
            CharData testChar = new CharData(Mon, name);

            //Assert
            string failstring = "";
            int fail=0 ;

            if (testChar.Monster == false) { fail = 1; failstring = failstring + "NotSet as Monster   "; }
            if (testChar.Rdy == true) { fail = 1; failstring = failstring + "Set as ready   "  ; }
            if (testChar.Dead == true) { fail = 1; failstring = failstring + "Dead  "; }
            if (testChar.epicDex != Mon.EpicDex) { fail = 1; failstring = failstring + "EpicDex misMatch  "; }
            if (testChar.joinBattle != Mon.Joinbattle ) { fail = 1; failstring = failstring + "JoinBattle MisMatch  "; }
            if (testChar.PlayerName != "NPC") { fail = 1; failstring = failstring + "Incorrect PlayerName  "; }
            if (testChar.ToonName != name) { fail = 1; failstring = failstring + "Instance MisMatch  "; }

            Assert.AreEqual(0, fail, failstring);
        }

        [TestMethod]
        public void GenerateFromPlayer()
        {
            //arrange
            string playerName = "steve";
            string toon = "ming the merciless";
            int EpicDexValue = 1;
            int JoinBattleValue = 6;



            //act
            CharData testChar = new CharData(playerName,toon,JoinBattleValue,EpicDexValue);

            //Assert
            string failstring = "";
            int fail = 0;

            if (testChar.Monster == true) { fail = 1; failstring = failstring + "Set as Monster   "; }
            if (testChar.Rdy == true) { fail = 1; failstring = failstring + "Set as ready   "; }
            if (testChar.Dead == true) { fail = 1; failstring = failstring + "Dead  "; }
            if (testChar.epicDex != EpicDexValue) { fail = 1; failstring = failstring + "EpicDex misMatch  "; }
            if (testChar.joinBattle != JoinBattleValue) { fail = 1; failstring = failstring + "JoinBattle MisMatch  "; }
            if (testChar.PlayerName != playerName) { fail = 1; failstring = failstring + "Incorrect PlayerName  "; }
            if (testChar.ToonName != toon) { fail = 1; failstring = failstring + "Instance MisMatch  "; }

            Assert.AreEqual(0, fail, failstring);
        }

        [TestMethod]
        public void GenerateFromPlayerNoToonName()
        {
            //arrange
            string playerName = "steve";
            string toon = "";
            int EpicDexValue = 1;
            int JoinBattleValue = 6;



            //act
            CharData testChar = new CharData(playerName, JoinBattleValue, EpicDexValue);

            //Assert
            string failstring = "";
            int fail = 0;

            if (testChar.Monster == true) { fail = 1; failstring = failstring + "Set as Monster   "; }
            if (testChar.Rdy == true) { fail = 1; failstring = failstring + "Set as ready   "; }
            if (testChar.Dead == true) { fail = 1; failstring = failstring + "Dead  "; }
            if (testChar.epicDex != EpicDexValue) { fail = 1; failstring = failstring + "EpicDex misMatch  "; }
            if (testChar.joinBattle != JoinBattleValue) { fail = 1; failstring = failstring + "JoinBattle MisMatch  "; }
            if (testChar.PlayerName != playerName) { fail = 1; failstring = failstring + "Incorrect PlayerName  "; }
            if (testChar.ToonName != toon) { fail = 1; failstring = failstring + "Instance MisMatch  "; }

            Assert.AreEqual(0, fail, failstring);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Not A Monster")]
        public void AttemptInitRollPlayer()
        {
            //arrange
            string playerName = "steve";
            string toon = "ming the merciless";
            int EpicDexValue = 1;
            int JoinBattleValue = 6;

            CharData testChar = new CharData(playerName, toon, JoinBattleValue, EpicDexValue);

            //act
            testChar.MonsterInit();

            //Assert
           

        }
        [TestMethod]

        public void ValidInitRollPlayer()
        {
            //arrange
            string playerName = "steve";
            string toon = "ming the merciless";
            int EpicDexValue = 1;
            int JoinBattleValue = 6;

            CharData testChar = new CharData(playerName, toon, JoinBattleValue, EpicDexValue);

            //act
            testChar.RollInitiative(5);
            testChar.trigger(6);
            
            //Assert
            Assert.AreEqual(1, testChar.ReturnPosition(), "No init Set");

        }

        [TestMethod]
        public void AttemptInitMonster()
        {
            //arrange
            Monster Mon = new Monster("Skeleton", 0, 7);
            string name = "SkeletonName";

            CharData testChar = new CharData(Mon, name);

            //act
            testChar.MonsterInit();

            testChar.trigger(12);

            //Assert
            int fail = 0;
            string failstring = "";

            if(testChar.Rdy == false) { fail = 1; failstring = failstring+"Not Set Ready    "; }

            Assert.AreEqual(0, fail, failstring);
        }

        //check that combat starts,
        [TestMethod] 
        public void StartCombat ()
        {
            // Arrange
            CharData testChar = new CharData("Player1", "toon1", 7, 1);
            testChar.RollInitiative(7);

            int expectedPosition = 1;

            //act
            testChar.trigger(8);

            //Assert
            Assert.AreEqual(expectedPosition, testChar.ReturnPosition(), "WronginitPosition");

        }
        [TestMethod]
        public void MoveToNextStage()
        {
            // Arrange
            CharData testChar = new CharData("Player1", "toon1", 7, 1);
            testChar.RollInitiative(7);

            int expectedPosition = 0;

            //act
            testChar.trigger(8);
            testChar.MoveAction();

            //Assert
            Assert.AreEqual(expectedPosition, testChar.ReturnPosition(), "WronginitPosition After Move");

        }

        [TestMethod]
        public void StartCombatWinInit()
        {
            // Arrange
            CharData testChar = new CharData("Player1", "toon1", 7, 1);
            testChar.RollInitiative(7);

            int expectedPosition = 0;

            //act
            testChar.trigger(7);

            //Assert
            Assert.AreEqual(expectedPosition, testChar.ReturnPosition(), "WronginitPosition");

        }

        [TestMethod]
        public void StartCombatLoseInit()
        {
            // Arrange
            CharData testChar = new CharData("Player1", "toon1", 7, 1);
            testChar.RollInitiative(1);

            int expectedPosition = 6;

            //act
            testChar.trigger(10);

            //Assert
            Assert.AreEqual(expectedPosition, testChar.ReturnPosition(), "WronginitPosition");

        }


        [TestMethod]
        public void GetPositionTest()
        {
            CharData testChar = new CharData("Player1", "toon1", 7, 1);
            testChar.RollInitiative(7);

            int expectedPosition = 1;

            //act
            testChar.trigger(8);

            //Assert
            Assert.AreEqual(expectedPosition, testChar.ReturnPosition(), "WronginitPosition After Move");
        }
    }
}
