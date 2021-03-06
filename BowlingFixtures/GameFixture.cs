﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void ZeroScore()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 20;i++ )
                g.Roll(0);
            Assert.AreEqual(0, g.GetScore());
        }

        
         [TestMethod]
        public void CorrectSpareScore()
        {
            Bowling.Game g = new Bowling.Game();
           g.Roll(5);
             g.Roll(5);
             g.Roll(3);
            Assert.AreEqual(13, g.GetScore());
        }

         [TestMethod]
        public void CorrectStrikeScore()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(10);
            g.Roll(5);
            g.Roll(6);
            Assert.AreEqual(21, g.GetScore());

        }

         [TestMethod]
        public void AllStrikes()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 10; i++)
            {
                g.Roll(10);
               
            }
            Assert.AreEqual(300, g.GetScore());
        }

        [TestMethod]
        public void AllOnes()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 20; i++)
            {
                g.Roll(1);
               
            }
            Assert.AreEqual(20, g.GetScore());
        }

        [TestMethod]
        public void AllNormals()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(3);
            g.Roll(3);
            g.Roll(3);
            g.Roll(3);
            g.Roll(4);
            g.Roll(4);
            g.Roll(4);
            g.Roll(4);
            g.Roll(5);
            g.Roll(5);
            g.Roll(5);
            g.Roll(5);
            g.Roll(6);
            g.Roll(6);
            g.Roll(6);
            g.Roll(6);
            g.Roll(7);
            g.Roll(7);
            g.Roll(7);
            g.Roll(7);
            Assert.AreEqual(111, g.GetScore());
        }
    }
}
