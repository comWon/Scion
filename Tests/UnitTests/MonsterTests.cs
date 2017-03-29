using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scion.MainHard;

namespace UnitTests
{
    [TestClass]
    public class MonsterTests
    {
        [TestMethod]
        public void MonsterValidInits()
        {
            //arrange
            string Name = "MonsterName";
            int Join = 4;
            int epicdex = 2;
            int runs = 10000;
            Monster Testy = new Monster(Name, epicdex, Join);

            int expectedmin = epicdex + 0;
            int expectedMax = epicdex + Join * 2;

            int[] results = new int[expectedMax*2];

            int x = 0;
            while  (x < expectedMax*2)
            {
                results[x] = 0;
                x++;
            }

            //act 
            int testcycle = 0;
            while (testcycle < runs) {
                int testVal = Testy.rollit();
                testcycle++;
                results[testVal]++;
                    }

            //assert
            int Belowmin = 0;
            int abovemax = 0;
            int result = 0;

            testcycle = 0;
            while (testcycle < expectedMax*2)
            {
                if (testcycle < expectedmin ) { Belowmin = Belowmin + results[testcycle]; }
                if (testcycle > expectedMax) { abovemax = abovemax + results[testcycle]; }
                if (testcycle  >= expectedmin && testcycle <= expectedMax) { result = result + results[testcycle]; }
                testcycle++;

            }

            Assert.AreEqual(runs, result, "Init Rolls return invalid results");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
         "No Join Battle Roll Was Set")]
        public void monsterFails ()
        {
            //arrange
            Monster Testy = new Monster();

            //act
            int test = Testy.rollit();


        }


    }
}
