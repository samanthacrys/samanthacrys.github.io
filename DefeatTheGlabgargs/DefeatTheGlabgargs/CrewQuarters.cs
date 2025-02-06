namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This class handles the logic to display and process the Crew Quarters.
    /// </summary>
    public class CrewQuarters : Room
    {
        /// <summary>
        /// This is the constructor for the Crew Quarters.
        /// </summary>
        public CrewQuarters()
        {
            Name = "Crew Quarters";
            Visited = false;
        }

        /// <summary>
        /// This displays the room's description and the available menu options that the player can use.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {

            base.Display();
            if (!Visited)
            {
                Console.WriteLine("With the bunk beds riveted to the ground, there was no way they were moving, " +
                    "though for some reason, Grayson left a Bag of Marbles on top of his trunk. " +
                    "The bag stood out in its bright purple color. The bedding on all of the beds was red and white. " +
                    "Maybe that could be useful. There was also the Flash Bang sitting next to Michaels’ bed. " +
                    "Those were unauthorized, maybe it would be best to take them before Michaels’ gets in trouble.\r\n");
                Visited = true;
            }
            
            int maxSelect = 1;
            Console.WriteLine($"{maxSelect}) Go west to the Corridor");

            if (!Program.player.HasMarbles)
            {
                ++maxSelect;
                Console.WriteLine($"{maxSelect}) Take the Bag of Marbles");
            }

            if (Program.player.HasFlashCharge)
            {
                return maxSelect;
            }

            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Take the Flash Bang");

            return maxSelect;
        }

        /// <summary>
        /// This processes the Flash Bang. This is called in multiple places.
        private void TakeFlashCharge()
        {
            Console.WriteLine("You take the Flash Bang. you never know when one of these will come in handy.\r\n");
            Program.player.HasFlashCharge = true;
            Program.player.FlashChargeUsed = false;
            Program.player.Score += 10;
        }
        
        /// <summary>
        /// This gets and processes the menu item selected by the player.
        /// </summary>
        /// <param name="maxSelect">
        /// This shows the max menu items. This is returned from the Display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            switch (selection)
            {
                case GameSelections.MenuItem1:
                    return Program.player.EnterCorridor();
                case GameSelections.MenuItem2:
                    if (!Program.player.HasMarbles)
                    {
                        Console.WriteLine("You take the Bag of Marbles and place it in your pocket. They could be " +
                            "useful, but Grayson may want these back when he survives.\r\n");
                        Program.player.HasMarbles = true;
                        Program.player.MarblesUsed = false;
                        Program.player.Score += 15;
                    }
                    else
                    {
                        TakeFlashCharge();
                    }
                    break;
                case GameSelections.MenuItem3:
                    TakeFlashCharge();
                    break;
            }
            return selection;
        }
    }
}