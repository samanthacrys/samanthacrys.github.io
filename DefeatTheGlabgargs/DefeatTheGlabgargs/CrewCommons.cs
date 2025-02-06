namespace DefeatTheGlabgargs
{
    public class CrewCommons : Room
    {
        /// <summary>
        /// These are the local menu options. The logic at this point changes based on the order of the player's
        /// selections from a list. The raw menu item number is then used as an index to make sure that the correct
        /// selection logic gets processed.
        /// </summary>
        private enum MenuOptions
        {
            NoOption = 0,
            EnterCorridor = 1,
            useMarbles = 2,
            useRayGun = 3,
            useFlashCharge = 4
        };

        private List<MenuOptions> options;
        
        /// <summary>
        /// This is the constructor for the Crew Commons. This is the final room of the game. This sets up the initial
        /// values for the room and the visited flag, which is used to show either the long or short description.
        /// </summary>
        public CrewCommons()
        {
            Name = "Crew Commons";
            options = new List<MenuOptions>();
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
                Console.WriteLine("You see the crew through the door’s window and know that you need to distract and " +
                    "take out your enemy. From what you saw earlier, there were only 3 Glabgargs and this is the " +
                    "last one. You have to save everyone. Hm, maybe blind it, they have 3 eyes after all. " +
                    "You can then take it out another way.\r\n");
                Visited = true;
            }
            
            options.Clear();
            options.Add(MenuOptions.NoOption);
            
            int maxSelect = 1;
            Console.WriteLine("1) Enter the Corridor.");
            options.Add(MenuOptions.EnterCorridor);

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

            switch (options[(int)selection])
            {
                case MenuOptions.NoOption:
                    break;
                case MenuOptions.EnterCorridor:
                    Program.player.EnterCorridor();
                    break;
                case MenuOptions.useMarbles:
                    Console.WriteLine("You take the marbles out of the bag and toss them at the ground near the" +
                        "Glabgarg's feet. It steps on them and proceeds to slip and fall. Its head hits the ground and" +
                        "it falls unconscious.\r\n");
                    Program.player.Score += 25;
                    Program.player.CrewCommonGlagargStunned = true;
                    Program.player.MarblesUsed = true;
                    Thread.Sleep(100);
                    if (Program.player.HasRayGun && Program.player.RayGunUsed)
                    {
                        Console.WriteLine("You go to use the Ray Gun, but it is out of charges. Why did it only have " +
                            "one charge? With the time it takes you to fail at shooting it, the Glabgarg" +
                            "has the time needed to wake up and instead shoots you with its own blaster.\r\n");
                        Console.WriteLine("With that shot from the blaster, it hits you in the center of your chest and " +
                            "you end up dying. You did not save the crew. Maybe don't use the Ray Gun " +
                            " too early.\r\n");
                        return GameSelections.QuitGame;
                    }
                    break;
                case MenuOptions.useRayGun:
                    if (Program.player.CrewCommonGlagargStunned)
                    {
                        Program.player.Score += 45;
                        Console.WriteLine("You bring up your Ray Gun and take the shot. Your shot hits it and stuns " +
                            "it long enough for you to rescue the crew. Congratulations!\r\n");
                        return GameSelections.QuitGame;
                    }
                    Console.WriteLine("You attempt to bring your Ray Gun up to shoot the Glabgarg, but it sees you with " +
                        "its 3 eyes. It moves before you manage to pull the trigger. Darn it.\r\n");
                    Thread.Sleep(100);
                    Console.WriteLine("With it out of your immeidate range, the Glabgarg raises its blaster and shoots " +
                        "you before you manage to do so. The shot hits you in the heart, killing you immediately." +
                        "You did not rescue the crew, sorry. Maybe trying stunning it first.\r\n");
                    return GameSelections.QuitGame;
                case MenuOptions.useFlashCharge:
                    Console.WriteLine("You use your flash bang and toss it in, closing your eyes. " +
                        "You hear the scream of the Glabgarg and your crewmates, but you mentally apologize to them. " +
                        "It’s not like you had a choice. Now you just need to take it out.\r\n");
                    Program.player.FlashChargeUsed = true;
                    Program.player.CrewCommonGlagargStunned = true;
                    break;
            }
            
            return selection;
        }
    }
}