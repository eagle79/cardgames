using System;
using CardsLib.Cards;

namespace War.WarGameLib
{
    /// <summary>
    /// Represents a War player
    /// </summary>
    public class Player
    {
        //properties
        /// <summary>
        /// Returns the player's current hand as a <see cref="CardStack"/>.
        /// </summary>
        /// <value>The player's current hand.</value>
        public CardStack Hand { get; }

        /// <summary>
        /// Initializes a new War player with the specified initial hand.
        /// </summary>
        /// <param name="initialHand">Player's initial hand.</param>
        public Player(CardStack initialHand)
        {
            if (initialHand.Orientation != CardStackOrientation.FaceDown)
            {
                throw new ArgumentException(
                        "Orientation of player hand must be face down.");
            }

            if (initialHand.Count != 26)
            {
                throw new ArgumentException(
                        "Player hand should contain 26 cards.");
            }

            Hand = initialHand;
        }
    }
}
