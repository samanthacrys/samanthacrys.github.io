namespace DefeatTheGlabgargs
{
    public class FloorThreeCorridor : Room
    {
        /// <summary>
        /// These are the local menu options. The logic at this point changes based on the order of the player's
        /// selections from a list. The raw menu item number is then used as an index to make sure that the correct
        /// selection logic gets processed.
        /// </summary>
        private enum MenuOptions
        {
            NoOption = 0,
            EnterLift = 1,
            EnterCrewCommons = 2,
            useMarbles = 3,
            useRayGun = 4,
            useFlashCharge = 5
        };

        private readonly List<MenuOptions> options;

        /// <summary>
        /// This is the constructor for the third floor Corridor. This sets teh name,
        /// the visited status, and allocates all of the options available.
        /// </summary>
        public FloorThreeCorridor()
        {
            Name = "Floor Three Corridor";
            Visited = false;
            options = new List<MenuOptions>();
        }

        /// <summary>
        /// This displays the room's description and the available menu options that the player can use.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            if (!Visited)
            {
                Console.WriteLine("You go to exit the Lift, but see that there is a Glabgarg at the end of the " +
                    "corridor. It is currently walking away from you, but who knows when it will turn around and " +
                    "see you.\r\n");
                Visited = true;
            }

            options.Clear();
            options.Add(MenuOptions.NoOption);
            
            int maxSelect = 1;
            Console.WriteLine("1) Enter the Lift.");
            options.Add(MenuOptions.EnterLift);

            ++maxSelect;
            Console.WriteLine("2) Enter the Crew Commons.");
            options.Add(MenuOptions.EnterCrewCommons);

            if ( Program.player.AddMarblesOption(ref maxSelect) )
            {
                options.Add(MenuOptions.useMarbles);
            }

            if ( Program.player.AddRayGunOption(ref maxSelect) )
            {
                options.Add(MenuOptions.useRayGun);
            }

            if (Program.player.AddFlashChargeOption(ref maxSelect))
            {
                options.Add(MenuOptions.useFlashCharge);
            }

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
            if (selection < GameSelections.MenuItem1 || selection > GameSelections.MenuItem5)
            {
                return selection;
            }

            switch (options[(int)selection])
            {
                case MenuOptions.EnterLift:
                    Program.player.current = Program.lift;
                    break;
                case MenuOptions.EnterCrewCommons:
                    Program.player.current = Program.crewCommons;
                    break;
                case MenuOptions.useMarbles:
                    Console.WriteLine("You realize that you were right and the Bag of Marbles can be useful. You throw " +
                        "the marbles at the Glabgarg. It steps on them and slips, causing him to fall. Its head hits " +
                        " the floor and ends up knocking him unconscious. It should not be safe to go through the " +
                        "corridor.\r\n");
                    Program.player.MarblesUsed = true;
                    Program.player.CorridorThreeGlagargUnconscious = true;
                    break;
                case MenuOptions.useFlashCharge:
                    Console.WriteLine("Figuring this is the time to use it, you arm and throw the Flash Bang. " +
                        "The device flies through the air at the Glabgarg and goes off. At least you thought to close " +
                        "your eyes. When the light is gone, you see that the Glabgarg has been stunned. Might be a " +
                        "good idea to get through the corridor before it gets its bearings.\r\n");
                    Program.player.FlashChargeUsed = true;
                    Program.player.CorridorThreeGlagargUnconscious = true;
                    break;
                case MenuOptions.useRayGun:
                    Console.WriteLine("You know your Ray Gun should do the trick, so you grab it and aim at the Glabgarg " +
                        "before it has a chance to turn around and see you. You take the shot and hit it in a way that" +
                        "stuns it. You should get through the corridor before it gets its bearings.\r\n");
                    Program.player.RayGunUsed = true;
                    Program.player.CorridorThreeGlagargUnconscious = true;
                    break;
                case MenuOptions.NoOption:
                    break;
            }
            
            return selection;
        }
        
        
    }
}