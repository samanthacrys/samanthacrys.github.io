namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This class Displays and processes the logic for the Engine Room.
    /// </summary>
    public class Engine : Room
    {
        /// <summary>
        /// This is the constructor for the Engine Room. It sets the name and visited flag to their default values.
        /// </summary>
        public Engine()
        {
            Name = "Engine Room";
            Visited = false;
        }
        
        /// <summary>
        /// This displays the room's description and the options from the menu for the user.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            if (!Visited)
            {
                Console.WriteLine("The room is loud as the engine still runs the ship, keeping all of the life " +
                    "support active. You’re shocked that there are no Glabgarg in there. Are they really " +
                    "that ridiculous as to think that nobody is going to be coming in there? It’s hard to tell, but " +
                    "you do know that there’s a computer that can help. While you could not get any signatures on the " +
                    "crew from the bridge, the computer could help you. You can also use this to get to the armory, " +
                    "but you’ll need the codes to get a ray gun from there. You’re pretty sure there’s something " +
                    "that should tell you what they are around here somewhere.\r\n");
                Visited = true;
            }

            int maxSelect = 1;
            Console.WriteLine($"{maxSelect}) Go north to the Corridor.");
            
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Go south to the Armory.");

            if (!Program.player.UsedComputer)
            {
                ++maxSelect;
                Console.WriteLine($"{maxSelect}) Use Computer.");
            }
            else if ( !Program.player.ReadStickNote)
            {
                ++maxSelect;
                Console.WriteLine($"{maxSelect}) Read Sticky Note.");
            }

            return maxSelect;
        }
        
        /// <summary>
        /// This gets and processes the menu item that is selected by the plaer.
        /// </summary>
        /// <param name="maxSelect">
        /// Shows the max menu items. This is returned from the Display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            switch (selection)
            {
                case GameSelections.MenuItem1:
                    return Program.player.EnterCorridor();
                case GameSelections.MenuItem2:
                    Program.player.current = Program.armory;
                    break;
                case GameSelections.MenuItem3:
                    if (!Program.player.UsedComputer)
                    {
                        Console.WriteLine("You check the computer to see if it can help you, as you know there are " +
                            "special components to the Engine Room's system. From there you see the heat signatures that " +
                            "indicate the crew being in the Crew Commons. They are blue, having been registered with " +
                            "your system. There are 3 other signatures in red. Those are likely the Glabgargs. It is " +
                            "after this that you notice a Sticky Note stuck to the monitor. It might contain something " +
                            "important.\r\n");
                        Program.player.UsedComputer = true;
                        Program.player.Score += 10;
                    }
                    else if ( !Program.player.ReadStickNote)
                    {
                        Console.WriteLine("You read the note. It has a code on it which reads 592730. " +
                            "This could be important.\r\n");
                        Program.player.ReadStickNote = true;
                        Program.player.Score += 25;
                    }
                    break;
            }
            return selection;
        }
    }
}