using ClockPatienceGame;

class Program
{
    static void Main()
    {
        // with the provided sample input
        // there will be 4 decks
        List<string> decks = new List<string>();

        Console.WriteLine("Enter the decks of cards (separated by spaces, four lines of 13 cards each):");

        // Read input until '#' is encountered
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "#")
                break;
            decks.Add(line);
        }

        Game game = new Game(decks); // Creating an object of type game
        game.Play();                // Play() and OutputResult() are both methods within the game class
        game.OutputResult();
    }
}
