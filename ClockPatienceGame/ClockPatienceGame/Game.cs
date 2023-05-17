using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceGame
{
    class Game
    {
        //private List<Stack<string>> piles;
        List<Queue<string>> piles;
        private int exposedCards;
        private string currentCard;

        public Game(List<string> decks)
        {
            //piles = new List<Stack<string>>();
            piles = new List<Queue<string>>();
            exposedCards = 0;

            // Create the initial piles
            for (int i = 0; i < 13; i++)
                piles.Add(new Queue<string>());

            // Distribute cards to piles
            foreach (string deck in decks)
            {
                string[] cards = deck.Split(' ');

                Array.Reverse(cards); // Reverse the order of the cards
                // had an issue when not reversing the order of the cards
                //as the result i was getting was 36,KD instead of 44,KD

                for (int i = 0; i < 13; i++)
                {
                    piles[i].Enqueue(cards[i]); //pushing new value in piles[i]. In this instance piles will only have one value which is the new value   
                }
            }

            currentCard = piles[12].Dequeue(); // Top card of the 'king' pile
            exposedCards++;
        }

        public void Play()
        {
            // Play the game
            while (true)
            {
                int currentPileIndex = GetPileIndex(currentCard); //gets the index form the current card that was popped from pile
                Queue<string> currentPile = piles[currentPileIndex];

                if (currentPile.Count == 0)
                    break;

                currentCard = currentPile.Dequeue(); // current card is removed from that pile
                exposedCards++;
            }
        }

        public void OutputResult()
        {
            // Output the result
            Console.WriteLine($"{exposedCards:D2},{currentCard}");
        }

        private int GetPileIndex(string card)
        {
            char rank = card[0];
            switch (rank)
            {
                case 'A': return 0;
                case '2': return 1;
                case '3': return 2;
                case '4': return 3;
                case '5': return 4;
                case '6': return 5;
                case '7': return 6;
                case '8': return 7;
                case '9': return 8;
                case 'T': return 9;
                case 'J': return 10;
                case 'Q': return 11;
                case 'K': return 12;
                default: return -1;
            }
        }
    }
}
