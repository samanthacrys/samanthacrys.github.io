namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This is the class for implementing the code that relates to the room labelled Armory
    /// </summary>
    public class Armory : Room
    {
        /// <summary>
        /// This is a constructor for the Armory. This sets the initial values of the room and the visited flag. This
        /// flag is used to show whether the long or short description of the room is displayed.
        /// </summary>
        public Armory()
        {
            Name = "Armory";
            Visited = false;
        }

        /// <summary>
        /// This displays the room's description and the available menu options for the player.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            int maxSelect = 1;

            if (!Visited)
            {
                Console.WriteLine("Upon entering the armory, you see that everything is locked in racks. You’ve never " +
                    "been so happy see that as you are now. Without that, there would have been a huge mess of " +
                    "weapons that  could have done damage. No, you just needed to get your Ray Gun. You look around " +
                    "and see one behind a cage door with a key pad next to it. You can enter the code " +
                    "there and get your weapon.\r\n");
                Visited = true;
            }

            Console.WriteLine($"{maxSelect}) Go north to the Engine Room.\r\n");
            ++maxSelect;
            if (!Program.player.HasRayGun)
            {
                Console.WriteLine($"{maxSelect}) Get the Ray Gun.\r\n");
            }
            
            return maxSelect;
        }
        
        /// <summary>
        /// This gets and processes the menu items that the player can select.
        /// </summary>
        /// <param name="maxSelect">
        /// This is the max menu items shown and it is returned from the display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);

            switch (selection)
            {
                case GameSelections.MenuItem1:
                    Program.player.current = Program.engine;
                    break;
                case GameSelections.MenuItem2:
                    if (Program.player.ReadStickNote)
                    {
                        Console.WriteLine("You enter code the 592730. It takes a moment, but the cage door pops open " +
                            "and you are able to take the Ray Gun.\r\n");
                        Program.player.HasRayGun = true;
                        Program.player.Score += 20;
                    }
                    else
                    {
                        Console.WriteLine("You do not know the code to open the cage. Maybe there's a note that has " +
                            "the code on it located elsewhere.\r\n");
                    }
                    break;
            }
            
            return selection;
        }
    }
}