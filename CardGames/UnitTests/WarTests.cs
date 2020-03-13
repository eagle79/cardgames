using System;
using System.Collections.Generic;
using CardsLib.Cards;
using War.WarGameLib;
using NUnit.Framework;

namespace WarTests
{
    [TestFixture()]
    public class TestClass_Player
    {
        [Test()]
        public void TestInstantiation()
        {
            CardStack deck = CardStack.GetSortedStandardDeck(
                    CardStackOrientation.FaceDown);

            List<Card> hand = deck.Draw(26);

            //create a player
            Player player;
            player = new Player(
                    CardStack.FromList(hand, CardStackOrientation.FaceDown));
            Assert.AreEqual(26, player.Hand.Count);

            //initial hand cannot be face up
            Assert.Throws<ArgumentException>(() => 
                    player = new Player(CardStack.FromList(
                            hand, CardStackOrientation.FaceUp)));

            //initial hand must have exactly 26 cards
            hand.Add(new Card(CardSuit.Hearts, CardRank.Ace));
            Assert.Throws<ArgumentException>(() => 
                    player = new Player(CardStack.FromList(
                            hand, CardStackOrientation.FaceDown)));
            hand.RemoveAt(0);
            hand.RemoveAt(0);
            Assert.AreEqual(25, hand.Count);
            Assert.Throws<ArgumentException>(() =>
                    player = new Player(CardStack.FromList(
                            hand, CardStackOrientation.FaceDown)));
        }
    }
}
