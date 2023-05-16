using System;
using System.Collections.Generic;

class ClockPatience
{
    static void Main()
    {
        List<string> decks = new List<string>();
        // Initialize the clock piles
        List<Stack<string>> piles = new List<Stack<string>>();
        int exposedCards = 0;

        Console.WriteLine("Enter the decks of cards (separated by spaces, four lines of 13 cards each):");

        // Read input until '#' is encountered
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "#")
                break;
            decks.Add(line);
        }

        // Create the initial piles
        for (int i = 0; i < 13; i++)
            piles.Add(new Stack<string>());

        // Distribute cards to piles
        foreach (string deck in decks)
        {
            string[] cards = deck.Split(' ');

            Array.Reverse(cards); // Reverse the order of the cards

            for (int i = 0; i < 13; i++)
            {
                Stack<string> currentValue = new Stack<string>();
                while (piles[i].Count > 0)
                {
                    currentValue.Push(piles[i].Pop()); // Remove all values from piles[i] and store them in currentValue
                }

                piles[i].Push(cards[i]); // Add the new value

                while (currentValue.Count > 0)
                {
                    piles[i].Push(currentValue.Pop()); // Put the values from currentValue back into piles[i] to maintain the order
                }
            }
        }

        // Start the game
        string currentCard = piles[12].Pop(); // Top card of the 'king' pile
        exposedCards++;

        // Play the game
        while (true)
        {
            int currentPileIndex = GetPileIndex(currentCard);
            Stack<string> currentPile = piles[currentPileIndex];

            if (currentPile.Count == 0)
                break;

            currentCard = currentPile.Pop();
            exposedCards++;
        }

        // Output the result
        Console.WriteLine($"{exposedCards:D2},{currentCard}");
    }


    // Get the index of the pile corresponding to the card value
    static int GetPileIndex(string card)
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
