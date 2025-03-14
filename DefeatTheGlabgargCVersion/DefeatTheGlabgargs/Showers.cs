namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This class handles the logic to display and process the Crew Showers.
    /// </summary>
    public class Showers : Room
    {
        /// <summary>
        /// This is the Crew Showers. It sets the room's name and initial visit flag.constructor 
        /// </summary>
        public Showers()
        {
            Name = "Crew Showers";
            Visited = false;
        }

        /// <summary>
        /// This displays the room's description and the available menu options that the player can choose from.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            int maxSelect = 1;
            if (!Visited)
            {
                Console.WriteLine("The showers were all communal and the three circular stands were made of metal, " +
                    "always cold to the touch, and had this silly bar that drove everyone nuts. After all, it was " +
                    "on the floor, you step on it and the water turns on in all the shower heads. It was so easy to " +
                    "step on it and turn the showers off again. The only good part of the showers had any merit was " +
                    "that, when you walk in, you had one wall that blocked off the men’s section, another that " +
                    "blocked of the women’s section, and another that blocked off the non-binary area. It is then " +
                    "you see the hand wash area. It looked like someone left a hand mirror there.\r\n");
                Visited = true;
            }

            Console.WriteLine($"{maxSelect}) Go east to the Corridor.");

            if (Program.player.HasMirror)
            {
                return maxSelect;
            }

            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Get Mirror.");

            return maxSelect;
        }

        /// <summary>
        /// This gets and processes the menu items that the player selects.
        /// </summary>
        /// <param name="maxSelect">
        /// This shows the max menu items and it is returned from the display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            switch (selection)
            {
                case GameSelections.MenuItem1:
                    return Program.player.EnterCorridor();
                case GameSelections.MenuItem2:
                    Console.WriteLine("You take the Mirror. This could prove useful.\r\n");
                    Program.player.HasMirror = true;
                    Program.player.Score += 30;
                    break;
            }
            return selection;
        }
    }
}