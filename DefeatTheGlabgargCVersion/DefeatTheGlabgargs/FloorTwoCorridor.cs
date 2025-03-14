namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This class handles the logic to display and process the Floor Two Corridor.
    /// </summary>
    public class FloorTwoCorridor : Room
    {
        /// <summary>
        /// This is the constructor for the second floor's corridor.
        /// </summary>
        public FloorTwoCorridor()
        { 
            Name = "Floor Two Corridor";
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
                Console.WriteLine("Leaving the lift, you see an empty corridor in front of you. This is the " +
                    "corridor that leads to the crew showers to the west, the sleeping crewQuarters to the east, " +
                    "and the engine room to the south. From the engine room you know the armory is just south of " +
                    "that. It may be useful to check all of the rooms for items. You never know when a Glabgarg " +
                    "could appear.\r\n");
                Visited = true;
            }
            int maxSelect = 1;
            Console.WriteLine($"{maxSelect}) Go west to the Crew Showers.");
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Go east to the Crew Quarters.");
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Go south to the Engine Room.");
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Enter the Lift.");
            
            return maxSelect;
        }

        /// <summary>
        /// This gets and processes the menu items that are selected by the player.
        /// </summary>
        /// <param name="maxSelect">
        /// The Max menu items shown, this is returned from the Display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            Program.player.current = selection switch
            {
                GameSelections.MenuItem1 => Program.showers,
                GameSelections.MenuItem2 => Program.crewQuarters,
                GameSelections.MenuItem3 => Program.engine,
                GameSelections.MenuItem4 => Program.lift,
                _ => Program.player.current
            };
            return selection;
        }
    }
}